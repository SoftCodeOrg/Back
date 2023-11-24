namespace Hakaton.Application.Helpers;

public class OperationResultEntity<T>: OperationResult
{
    public T? Value { get; set; }
}