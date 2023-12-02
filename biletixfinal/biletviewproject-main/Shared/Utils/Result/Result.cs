namespace Shared.Utils.Result
{
    public interface ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public interface ICommandResult<T> : ICommandResult
    {
        T Data { get; }
    }

    #region # void types
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public CommandResult(bool success, string message) : this(success)
        {
            Message = message;
        }
        public CommandResult(bool success)
        {
            Success = success;
        }
    }

    public class SuccessCommandResult : CommandResult
    {
        public SuccessCommandResult() : base(true) { }
        public SuccessCommandResult(string message) : base(true, message) { }
    }

    public class ErrorCommandResult : CommandResult
    {
        public ErrorCommandResult() : base(false) { }
        public ErrorCommandResult(string message) : base(false, message) { }
    }
    #endregion

    #region # generic types
    public class CommandResult<T> : CommandResult, ICommandResult<T>
    {
        public T Data { get; }

        public CommandResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public CommandResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
    }

    public class SuccessCommandResult<T> : CommandResult<T>
    {
        public SuccessCommandResult(T data, string message) : base(data, true, message) { }
        public SuccessCommandResult(T data) : base(data, true) { }
        public SuccessCommandResult(string message) : base(default, true, message) { }
        public SuccessCommandResult() : base(default, true) { }
    }

    public class ErrorCommandResult<T> : CommandResult<T>
    {
        public ErrorCommandResult(T data, string message) : base(data, false, message) { }
        public ErrorCommandResult(T data) : base(data, false) { }
        public ErrorCommandResult(string message) : base(default, false, message) { }
        public ErrorCommandResult() : base(default, false) { }
    }
    #endregion
}
