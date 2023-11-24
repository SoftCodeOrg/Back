using Hakaton.Application.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Infrastruct.Services;

public class UsersService: IUsersService
{
    private readonly DataContext _dataContext;

    public UsersService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User> Registration(
        string username,
        string password)
    {
        var newUser = new User(username, password);
        await _dataContext.Users.AddAsync(newUser);
        await _dataContext.SaveChangesAsync();
        return newUser;
    }

    public async Task<User> Authorization(
        string username,
        string password)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(it => it.Username == username);
        if (user is null)
        {
            throw new Exception("Пользователя с таким username не найдено");
        }

        if (user.Password != password)
        {
            throw new Exception("Неверный username или пароль");
        }

        return user;
    }
}