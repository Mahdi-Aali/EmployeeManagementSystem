namespace EmployeeManagementService.Domain.Services;

public interface IPersonalInformationService
{
    public Task<IEnumerable<PersonalInformationModel>> GetAllAsync();
    public Task<PersonalInformationModel> GetAsync(int id);
    public Task CreateAsync(IEnumerable<CreatePersonalInformationModel> models);
    public Task UpdateAsync(UpdatePersonalInformationModel model);
    public Task DeleteAsync(int id);
}
