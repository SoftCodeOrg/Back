using Hakaton.Application.Domain.Subjects.Model;
using Hakaton.Application.Domain.Subjects.Services;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Infrastruct.Services;

public class SubjectsService: ISubjectService
{
    private readonly DataContext _dataContext;

    public SubjectsService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Subject>> GetAll()
    {
        return await _dataContext.Subjects.ToListAsync();
    }
}