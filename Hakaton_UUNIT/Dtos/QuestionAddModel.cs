namespace Hakaton_UUNIT.Dtos;

public class QuestionAddModel
{
    public string Title { get; set; }
    public string[] Response { get; set; }
    public int TrueResponseIndex { get; set; }
}