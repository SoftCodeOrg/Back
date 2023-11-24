using Hakaton.Application.Domain.Subjects.Model;

namespace Hakaton.Application.Domain.Subjects.Services;

public interface ISubjectService
{
    public Task<List<Subject>> GetAll();
}