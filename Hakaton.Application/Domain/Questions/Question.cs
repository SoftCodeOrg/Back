using Hakaton.Application.Domain.Subjects.Model;
using Hakaton.Application.Domain.Tests;

namespace Hakaton.Application.Domain.Questions;

public class Question
{
    public Guid Id { get; set; }
    public Guid SubjectId { get; set; }
    public Subject? Subject { get; set; }
    
    public string Title { get; set; }
    public string[] Responses { get; set; }
    
    public int TrueResponseIndex { get; set; }

    public Question()
    {
        
    }

    public Question(
        string title,
        string[] responses,
        int trueResponseIndex)
    {
        Title = title;
        Responses = responses;
        TrueResponseIndex = trueResponseIndex;
    }
}