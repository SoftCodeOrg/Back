using Hakaton.Application.Domain.Tests;

namespace Hakaton.Application.Domain.Questions;

public class Question
{
    public Guid Id { get; set; }
    public Guid TestId { get; set; }
    public Test? Test { get; set; }
    
    public string Title { get; set; }
    public string[] Responses { get; set; }
}