using EMS.JobInformation.Domain.Models.DepartmentModels;

namespace EMS.JobInformation.Domain.Services.DepartmentService;

public interface IDepartmentService
{
    public Task<IEnumerable<DepartmentModel>> GetAllAsync();
    public Task<DepartmentModel> GetAsync(int id);
    public Task<int> CreateAsync(CreateDepartmentModel model);
    public Task<bool> DeleteAsync(int id);
    public Task<int> UpdateAsync(UpdateDepartmentModel model);
}
