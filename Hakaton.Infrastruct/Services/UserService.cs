using Hakaton.Application.Domain.Progress;
using Hakaton.Application.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Hakaton.Infrastruct.Services;

public class UserService: IUserService
{
    private readonly DataContext _dataContext;

    public UserService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<User> Registration(
        string username,
        string password)
    {
        if (await _dataContext.Users.AnyAsync(it => it.Username == username))
        {
            throw new Exception("Пользователь с таким username зарегестрирован");
        }
        
        var newUser = new User(username, password);
        await _dataContext.Users.AddAsync(newUser);

        var subjectsProgress =
            await _dataContext.Subjects.Select(it => new TestProgress(newUser.Id, it.Id)).ToListAsync();

        await _dataContext.UserTestProgresses.AddRangeAsync(subjectsProgress);
            
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