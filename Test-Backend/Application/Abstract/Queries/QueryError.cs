namespace Test_Backend.Application.Abstract.Queries
{
    public class QueryError<T> : IError where T : IQuery, new()
    {
        public string ErrorMessage { get; set; }
    }
}