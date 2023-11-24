using Hakaton_UUNIT.Dtos;
using Hakaton.Application.Domain.Subjects.Services;
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
        return (await _subjectService.GetAll()).Select(it=> new SubjectModel
        {
            Title = it.Title,
            Description = it.Description,
            ImgUrl = it.ImageUrl,
            CurrentProgress = 0,
            MaxProgress = it.Tests is not null ? it.MaxProgress.Value : 1
        }).ToList();
    }

    [HttpPost]
    public async Task<SubjectModel> AddSubject(SubjectAddModel model)
    {
        var subject = await _subjectService.Add(model.Title, model.Description, model.ImageUrl);
        return new SubjectModel
        {
            Title = subject.Title,
            Description = subject.Description,
            ImgUrl = subject.ImageUrl,
            CurrentProgress = 0,
            MaxProgress = 1
        };
    }
}