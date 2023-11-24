using Hakaton.Application.Domain.Subjects.Model;
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
    [ProducesResponseType(typeof(List<Subject>),200)]
    public async Task<List<Subject>> AllSubjects()
    {
        return await _subjectService.GetAll();
    }
}