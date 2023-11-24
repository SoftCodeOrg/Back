using Hakaton.Application.Domain.Subjects.Model;
using Hakaton.Application.Domain.Users;

namespace Hakaton.Application.Domain.Progress;

public class TestProgress
{
    public Guid Id { get; set; }
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public Subject? Subject { get; set; }
    public Guid SubjectId { get; set; }
    public int Progress { get; set; }

    public TestProgress(
        Guid userId,
        Guid subjectId)
    {
        UserId = userId;
        SubjectId = subjectId;
        Progress = 0;
    }
}