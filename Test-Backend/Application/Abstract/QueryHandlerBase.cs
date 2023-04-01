using OneOf;

using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

using Test_Backend.API.Dtos;
using Test_Backend.Application.Abstract.Queries;

namespace Test_Backend.Application.Abstract
{
    public class QueryHandlerBase
    {
        protected async Task<OneOf<TResult, QueryError<T>>> TryAsync<T, TResult>(T command, Func<T, Task<TResult>> function)
            where T : IQuery, new()
        {
            try
            {
                return await function(command);
            }
            catch (Exception e)
            {
                return new QueryError<T>
                {
                    ErrorMessage = e.Message
                };
            }
        }

        protected void ApplySort<T>(ref IQueryable<T> list, string orderBy) where T : new()
        {

            if (string.IsNullOrEmpty(orderBy))
                return;

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            var propertyFromQueryName = orderBy.Split("_")[0];
            var objectProperty = properties.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

            if (objectProperty == null)
                return;

            var sortingOrder = orderBy.EndsWith("_desc") ? "descending" : "ascending";

            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
                return;

            list = list.OrderBy(orderQuery);
        }
    }
}
