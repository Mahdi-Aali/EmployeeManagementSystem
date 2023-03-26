namespace EMS.JobInformation.BLL.Services;

public class DepartmentService : IDepartmentService
{

    private readonly IDepartmentRepository _repository;

    public DepartmentService(IDepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DepartmentModel>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<DepartmentModel> GetAsync(int id) => await _repository.GetAsync(id);

    public async Task<int> CreateAsync(CreateDepartmentModel model) =>
        await _repository.CreateAsync(model);

    public async Task<bool> DeleteAsync(int id) => await _repository.DeleteAsync(id) > 0 ? true : false;

    public async Task<int> UpdateAsync(UpdateDepartmentModel model) => await _repository.UpdateAsync(model);
}
