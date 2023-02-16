using Bogus;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Generation;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Application.Services;

public class UserService
{
    private readonly DatabaseContextBase _context;
    private readonly Faker<User> _userGenerator;

    public UserService(DatabaseContextBase context)
    {
        _context = context;
        _userGenerator = EntityGenerator.UserGenerator;
    }

    public async Task<User> AddUserAsync()
    {
        var user = _userGenerator.Generate();

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<IReadOnlyCollection<User>> AddUsersAsync(int count)
    {
        List<User> users = _userGenerator.Generate(count);

        _context.Users.AddRange(users);
        await _context.SaveChangesAsync();

        return users;
    }

    public async Task<IReadOnlyCollection<User>> GetUsersAsync()
        => await _context.Users.ToListAsync();
}