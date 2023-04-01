namespace ECoffee.Application.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(message, false) { }
        public ErrorResult() : base(false) { }
    }

}
