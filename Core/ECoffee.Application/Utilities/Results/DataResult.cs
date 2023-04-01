using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T> where T : class, IDTO, new()
    {
        public DataResult(string message, bool isSucceeded, T data) : base(message, isSucceeded) => this.Data = data;

        public DataResult(bool isSucceeded, T data) : base(isSucceeded) => this.Data = data;

        public T Data { get; }
    }
}
