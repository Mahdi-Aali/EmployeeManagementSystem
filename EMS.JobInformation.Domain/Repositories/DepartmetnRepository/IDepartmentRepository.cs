using EMS.JobInformation.Domain.Models.DepartmentModels;

namespace EMS.JobInformation.Domain.Repositories.DepartmetnRepository;

public interface IDepartmentRepository
{
    public Task<IEnumerable<DepartmentModel>> GetAllAsync();
    public Task<DepartmentModel> GetAsync(int id);
    public Task<int> CreateAsync(CreateDepartmentModel model);
    public Task<int> DeleteAsync(int id);
    public Task<int> UpdateAsync(UpdateDepartmentModel model);
}
