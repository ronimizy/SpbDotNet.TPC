using Bogus;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Generation;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.Users;

namespace ronimizy.SpbDotNet.TPC.Application.Services;

public class EmployeeService
{
    private readonly DatabaseContextBase _context;
    private readonly Faker _faker;

    public EmployeeService(DatabaseContextBase context, Faker faker)
    {
        _context = context;
        _faker = faker;
    }

    public async Task<Employee> CreateEmployeeAsync(User user)
    {
        var employee = GenerateEmployee(user);

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public Task<IReadOnlyCollection<Employee>> CreateEmployeesAsync(IReadOnlyCollection<User> users)
    {
        Employee[] employees = GenerateEmployees(users);
        return CreateEmployeesAsync(employees);
    }

    public async Task<IReadOnlyCollection<Employee>> CreateEmployeesAsync(IReadOnlyCollection<Employee> employees)
    {
        _context.Employees.AddRange(employees);
        await _context.SaveChangesAsync();

        return employees;
    }

    public async Task<IReadOnlyCollection<Employee>> GetEmployeesAsync()
        => await _context.Employees.ToListAsync();

    public async Task<IReadOnlyCollection<Subordinate>> GetSubordinatesAsync()
        => await _context.Employees.OfType<Subordinate>().ToListAsync();

    public async Task<IReadOnlyCollection<Intern>> GetInternsAsync()
        => await _context.Employees.OfType<Intern>().ToListAsync();

    public async Task<Manager> LoadFirstManagerWithEmployees()
    {
        return await _context.Employees
            .OfType<Manager>()
            .Include(x => x.Employees)
            .Where(x => x.Employees.Any())
            .FirstAsync();
    }

    public Employee[] GenerateEmployees(IEnumerable<User> users)
    {
        Employee[] employees = users.Select(GenerateEmployee).ToArray();

        Manager[] managers = employees.OfType<Manager>().ToArray();

        IEnumerable<(Subordinate employee, Manager manager)> subordinates = employees
            .OfType<Subordinate>()
            .Select((employee, number) => (employee, number))
            .Select(x => (x.employee, manager: managers[x.number % managers.Length]));

        foreach (var (employee, manager) in subordinates)
        {
            employee.Manager = manager;
        }

        Manager[] subManagers = _faker.PickRandom(managers, managers.Length / 2).ToArray();

        foreach (var subManager in subManagers)
        {
            var superior = _faker.PickRandom(managers.Except(subManagers));
            subManager.Manager = superior;
        }

        return employees;
    }

    private Employee GenerateEmployee(User user)
    {
        var number = _faker.Random.Int(0, 2);

        Employee employee = number switch
        {
            0 => EntityGenerator.InternGenerator.Generate(),
            1 => EntityGenerator.SubordinateGenerator.Generate(),
            2 => EntityGenerator.ManagerGenerator.Generate(),
            _ => EntityGenerator.InternGenerator.Generate(),
        };

        employee.User = user;

        return employee;
    }
}