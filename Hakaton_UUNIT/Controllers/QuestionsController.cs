using Hakaton_UUNIT.Dtos;
using Hakaton.Application.Domain.Questions;
using Hakaton.Infrastruct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hakaton_UUNIT.Controllers;

[ApiController]
[Route("questions")]
public class QuestionsController : ControllerBase
{
    private readonly DataContext _dataContext;

    public QuestionsController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    [HttpGet("/subject/subjectId:guid/questions")]
    public async Task<IActionResult> GetQuestions([FromQuery]Guid subjectId)
    {
        var subject = await _dataContext.Subjects.Include(it => it.Questions).FirstOrDefaultAsync(it=>it.Id == subjectId);

        if (subject == null)
        {
            return NotFound("Не найден");
        }

        return Ok(subject.Questions);
    }

    [HttpPost("/subject/subjectId:guid/questions")]
    public async Task<IActionResult> AddQuestion([FromQuery] Guid subjectId, [FromBody] QuestionAddModel model)
    {
        var subject = await _dataContext.Subjects.Include(it => it.Questions).FirstOrDefaultAsync(it=>it.Id == subjectId);

        if (subject == null)
        {
            return NotFound("Не найден");
        }

        var question = new Question(model.Title, model.Response, model.TrueResponseIndex);
        
        subject.Questions.Add(question);

        await _dataContext.SaveChangesAsync();
        return Ok(subject); 
    }
}