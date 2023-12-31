using Hakaton.Application.Domain.Subjects.Model;
using Hakaton.Application.Domain.Subjects.Services;
using Hakaton.Application.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Infrastruct.Services;

public class SubjectsService: ISubjectService
{
    private readonly DataContext _dataContext;

    public SubjectsService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Subject>> GetAllAsync()
    {
        return await _dataContext.Subjects.Include(it=>it.Questions).ToListAsync();
    }

    public async Task<OperationResultEntity<Subject>> AddAsync(string title, string description, string imageUrl)
    {
        if (await _dataContext.Subjects.AnyAsync(
                it => it.Title == title && it.Description == description && it.ImageUrl == imageUrl))
        {
            return new OperationResultEntity<Subject>("Подобный предмет уже существует.");
        }
        
        var subject = new Subject
        {
            Id = Guid.NewGuid(),
            Description = description,
            Title = title,
            ImageUrl = imageUrl
        };

        await _dataContext.Subjects.AddAsync(subject);
        await _dataContext.SaveChangesAsync();

        return new OperationResultEntity<Subject>(subject);
    }

    public async Task<OperationResult> RemoveAsync(Guid id)
    {
        var subject = await _dataContext.Subjects.FirstOrDefaultAsync(it => it.Id == id);

        if (subject is null)
        {
            return new OperationResult("Не найден предмет с таким Id");
        }

        _dataContext.Subjects.Remove(subject);
        await _dataContext.SaveChangesAsync();
        return new OperationResult();
    }
}