using Bogus;
using Microsoft.EntityFrameworkCore;
using ronimizy.SpbDotNet.TPC.Application.Generation;
using ronimizy.SpbDotNet.TPC.DataAccess.Contexts;
using ronimizy.SpbDotNet.TPC.Model.Employees;
using ronimizy.SpbDotNet.TPC.Model.ProjectItems;
using ronimizy.SpbDotNet.TPC.Model.Projects;

namespace ronimizy.SpbDotNet.TPC.Application.Services;

public class ProjectService
{
    private readonly DatabaseContextBase _context;
    private readonly Faker _faker;

    public ProjectService(DatabaseContextBase context, Faker faker)
    {
        _context = context;
        _faker = faker;
    }

    public async Task<Project> CreateProjectAsync()
    {
        var project = EntityGenerator.ProjectGenerator.Generate();

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return project;
    }

    public async Task PopulateProjectAsync(Project project, int itemCount)
    {
        ProjectItem[] items = Enumerable.Range(0, itemCount)
            .Select(i => GenerateProjectItem(project, i))
            .ToArray();

        ProjectStage[] stages = items.OfType<ProjectStage>().ToArray();

        IEnumerable<(ProjectTask task, ProjectStage stage)> tasks = items
            .OfType<ProjectTask>()
            .Select((task, number) => (task, number))
            .Select(x => (x.task, stage: stages[x.number % stages.Length]));

        foreach (var (task, stage) in tasks)
        {
            task.Parent = stage;
        }

        ProjectStage[] subStages = _faker.PickRandom(stages, stages.Length / 2).ToArray();

        foreach (var subStage in subStages)
        {
            var parent = _faker.PickRandom(stages.Except(subStages));
            subStage.Parent = parent;
        }

        _context.ProjectItems.AddRange(items);
        await _context.SaveChangesAsync();
    }

    public async Task AddProjectClientsAsync(Project project, IEnumerable<Employee> clients)
    {
        foreach (var client in clients)
        {
            project.Clients.Add(client);
        }

        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<ProjectItem>> GetProjectItemsAsync(Project project)
    {
        return await _context.ProjectItems
            .Include(x => (x as ProjectStage)!.Children)
            .Where(x => x.Project.Equals(project))
            .Where(x => x.Parent == null)
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<ProjectItem>> GetProjectItemsSimpleAsync(Project project)
    {
        return await _context.ProjectItems
            .Where(x => x.Project.Equals(project))
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Employee>> GetProjectClientsAsync(Guid projectId)
    {
        return await _context.Projects
            .Where(x => x.Id.Equals(projectId))
            .SelectMany(x => x.Clients)
            .ToListAsync();
    }

    private static ProjectItem GenerateProjectItem(Project project, int index)
    {
        ProjectItem item = (index % 2) switch
        {
            0 => EntityGenerator.ProjectTaskGenerator.Generate(),
            1 => EntityGenerator.ProjectStageGenerator.Generate(),
            _ => EntityGenerator.ProjectTaskGenerator.Generate(),
        };

        item.Project = project;

        return item;
    }
}