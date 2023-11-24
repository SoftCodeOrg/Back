using System.Text.Json.Serialization;
using Hakaton.Application.Domain.Questions;

namespace Hakaton.Application.Domain.Tests;

public class Test
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    public List<Question>? Questions { get; set; }
    public int? MaxProgress => Questions.Count;
}