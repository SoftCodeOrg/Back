namespace Hakaton.Application.Domain.Users;

public interface IUserService
{
    public Task<User> Registration(
        string username,
        string password);

    public Task<User> Authorization(
        string username,
        string password);
}