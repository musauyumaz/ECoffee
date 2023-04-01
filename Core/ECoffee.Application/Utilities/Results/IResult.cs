namespace ECoffee.Application.Utilities.Results
{
    public interface IResult
    {
        string Message { get; }
        bool IsSucceeded { get; }
    }
}
