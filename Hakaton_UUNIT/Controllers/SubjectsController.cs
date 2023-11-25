using Hakaton_UUNIT.Dtos;
using Hakaton.Application.Domain.Subjects.Services;
using Hakaton.Application.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Hakaton_UUNIT.Controllers;

[ApiController]
[Route("subjects")]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<SubjectModel>),200)]
    public async Task<List<SubjectModel>> AllSubjects()
    {
        return (await _subjectService.GetAllAsync()).Select(it=> new SubjectModel
        {
            Title = it.Title,
            Description = it.Description,
            ImgUrl = it.ImageUrl,
            CurrentProgress = 0,
            MaxProgress = it.Questions is not null ? it.MaxProgress.Value : 1
        }).ToList();
    }

    [HttpPost]
    public async Task<IActionResult> AddSubject(SubjectAddModel model)
    {
        var result = await _subjectService.AddAsync(model.Title, model.Description, model.ImageUrl);

        if (!result.IsOk)
        {
            return BadRequest(result.Error);
        }

        var subject = result.Value;
        
        return Ok( new SubjectModel
        {
            Title = subject.Title,
            Description = subject.Description,
            ImgUrl = subject.ImageUrl,
            CurrentProgress = 0,
            MaxProgress = 1
        });
    }

    [HttpDelete("id:guid")]
    public async Task<OperationResult> Remove(Guid id)
    {
        return await _subjectService.RemoveAsync(id);
    }
}