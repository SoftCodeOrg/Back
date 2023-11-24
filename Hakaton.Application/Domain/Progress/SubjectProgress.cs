using Hakaton.Application.Domain.Subjects.Model;
using Hakaton.Application.Domain.Users;

namespace Hakaton.Application.Domain.Progress;

public class SubjectProgress
{
    public User? User { get; set; }
    public Guid UserId { get; set; }
    public Subject? Subject { get; set; }
    public Guid SubjectId { get; set; }
    public int Progress { get; set; }
}