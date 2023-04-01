using ECoffee.Application.Abstractions.DTO;

namespace ECoffee.Application.Utilities.Results
{
    public interface IDataResult<T> : IResult where T : class, IDTO, new()
    {
        T Data { get; }
    }
}
