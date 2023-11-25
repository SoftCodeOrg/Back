using Hakaton.Application.Domain.Subjects.Model;
using Hakaton.Application.Helpers;

namespace Hakaton.Application.Domain.Subjects.Services;

public interface ISubjectService
{
    public Task<List<Subject>> GetAllAsync();
    public Task<OperationResultEntity<Subject>> AddAsync(
        string title,
        string description,
        string imageUrl);
    public Task<OperationResult> RemoveAsync(Guid id);
}