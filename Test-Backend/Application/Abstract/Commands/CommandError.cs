using System.Windows.Input;

namespace Test_Backend.Application.Abstract.Commands
{
    public class CommandError<T> : IError where T : ICommand, new()
    {
        public string ErrorMessage { get; set; }
    }
}
