using Bogus;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Generation;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.EmployeeUniforms;

namespace ronimizy.SpbDotNet.TPC.Application.Services;

public class EmployeeUniformService
{
    private readonly DatabaseContextBase _context;
    private readonly Faker<CasualEmployeeUniform> _casualEmployeeUniformFaker;
    private readonly Faker<OfficialEmployeeUniform> _officialEmployeeUniformFaker;
    private readonly Faker<DisplayEmployeeUniform> _displayEmployeeUniformFaker;

    public EmployeeUniformService(DatabaseContextBase context)
    {
        _context = context;

        _casualEmployeeUniformFaker = EntityGenerator.CasualEmployeeUniformGenerator;
        _officialEmployeeUniformFaker = EntityGenerator.OfficialEmployeeUniformGenerator;
        _displayEmployeeUniformFaker = EntityGenerator.DisplayEmployeeUniformGenerator;
    }

    public async Task AddEmployeeUniformsAsync(int count)
    {
        IEnumerable<EmployeeUniform> uniforms = Enumerable.Range(0, count).Select<int, EmployeeUniform>(i =>
        {
            return (i % 3) switch
            {
                0 => _casualEmployeeUniformFaker.Generate(),
                1 => _officialEmployeeUniformFaker.Generate(),
                2 => _displayEmployeeUniformFaker.Generate(),
                _ => throw new InvalidOperationException()
            };
        });

        _context.EmployeeUniforms.AddRange(uniforms);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<EmployeeUniform>> GetEmployeeUniformsAsync()
        => await _context.EmployeeUniforms.ToListAsync();

    public async Task<IReadOnlyCollection<T>> GetEmployeeUniformsAsync<T>() where T : EmployeeUniform
        => await _context.EmployeeUniforms.OfType<T>().ToListAsync();
}