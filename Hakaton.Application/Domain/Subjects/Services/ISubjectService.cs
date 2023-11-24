using Hakaton.Application.Domain.Subjects.Model;

namespace Hakaton.Application.Domain.Subjects.Services;

public interface ISubjectService
{
    public Task<List<Subject>> GetAll();
    public Task<Subject> Add(string title, string description, string imageUrl);
}