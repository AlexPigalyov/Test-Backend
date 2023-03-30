using OneOf;
using Test_Backend.Application.Abstract.Commands;

namespace Test_Backend.Infrastructurre.Abstract
{
    public class CommandHandlerBase
    {
        protected async Task<OneOf<TResult, CommandError<T>>> TryAsync<T, TResult>(T command,
            Func<T, Task<TResult>> function)
            where T : ICommand, new()
        {
            try
            {
                return await function(command);
            }
            catch (Exception e)
            {
                return new CommandError<T>
                {
                    ErrorMessage = e.Message
                };
            }
        }
    }
}
