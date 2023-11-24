using System.Text.Json.Serialization;

namespace Hakaton.Application.Domain.Subjects.Model;

public class Subject
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}