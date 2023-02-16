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
    private readonly Faker<Intern> _internGenerator;
    private readonly Faker<Subordinate> _subordinateGenerator;
    private readonly Faker<Manager> _managerGenerator;

    public EmployeeService(DatabaseContextBase context, Faker faker)
    {
        _context = context;
        _faker = faker;
        
        _internGenerator = EntityGenerator.InternGenerator;
        _subordinateGenerator = EntityGenerator.SubordinateGenerator;
        _managerGenerator = EntityGenerator.ManagerGenerator;
    }

    public async Task<Employee> CreateEmployeeAsync(User user)
    {
        var employee = GenerateEmployee(user, 0);

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
    
    public async Task<IReadOnlyCollection<Manager>> GetManagersAsync()
        => await _context.Employees.OfType<Manager>().ToListAsync();

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

    private Employee GenerateEmployee(User user, int index)
    {
        Employee employee = (index % 3) switch
        {
            0 => _internGenerator.Generate(),
            1 => _subordinateGenerator.Generate(),
            2 => _managerGenerator.Generate(),
            _ => _internGenerator.Generate(),
        };

        employee.User = user;

        return employee;
    }
}