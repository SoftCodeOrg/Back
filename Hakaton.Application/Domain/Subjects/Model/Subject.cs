using System.Text.Json.Serialization;
using Hakaton.Application.Domain.Tests;

namespace Hakaton.Application.Domain.Subjects.Model;

public class Subject
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public List<Test>? Tests { get; set; }
    public int? MaxProgress => Tests.Count;
}