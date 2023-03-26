namespace EMS.JobInformation.DAL.Repositories.DepartmentRepositories;

public class EfDepartmentRepository : IDepartmentRepository
{
    private readonly JobInformationContext _context;
    private readonly ILogger<EfDepartmentRepository> _logger;

    public EfDepartmentRepository(JobInformationContext context, ILogger<EfDepartmentRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<DepartmentModel>> GetAllAsync() =>
        await Task.FromResult(_context.Departments.AsNoTracking().Select(d => d.ToDomain()));

    public async Task<DepartmentModel> GetAsync(int id) =>
        (await _context.Departments.AsNoTracking().FirstOrDefaultAsync(d => d.Id.Equals(id)))!.ToDomain();

    public async Task<int> CreateAsync(CreateDepartmentModel model)
    {
        try
        {
            Department department = new(model.Name, model.Description, model.ManagerId, null);
            await _context.Departments.AddAsync(department);
            await SaveChangeAsync();
            return department.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error when creating new Departmetn.");
            return -1;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            var model = await GetAsync(id);
            if (model is not null)
            {
                _context.Entry(model).State = EntityState.Deleted;
                return await SaveChangeAsync();
            }
            return -1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"error when deleting department with id: \"{id}\"");
            return -1;
        }
    }

    public async Task<int> UpdateAsync(UpdateDepartmentModel model)
    {
        try
        {
            Department department = new(model.Id, model.Name, model.Description, model.ManagerId, DateTime.MinValue, DateTime.Now);
            _context.Entry(department).Property(p => p.Name).IsModified = true;
            _context.Entry(department).Property(p => p.Description).IsModified = true;
            _context.Entry(department).Property(p => p.ManagerId).IsModified = true;
            _context.Entry(department).Property(p => p.UpdateDate).IsModified = true;
            return await SaveChangeAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"error when updating department with id: \"{model.Id}\"");
            return -1;
        }
    }

    private async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
}
