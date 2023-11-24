namespace Hakaton.Application.Helpers;

public class OperationResult
{
    public bool IsOk => Error is null;
    public string? Error { get; }

    public OperationResult()
    {
    }

    public OperationResult(string error)
    {
        Error = error;
    }
}