namespace Hakaton.Application.Helpers;

public class OperationResultEntity<T>: OperationResult
{
    public T? Value { get; set; }
    
    public OperationResultEntity(string error)
    {
        Error = error;
    }

    public OperationResultEntity(T entity)
    {
        Value = entity;
    }

    public OperationResultEntity()
    {
    }
}