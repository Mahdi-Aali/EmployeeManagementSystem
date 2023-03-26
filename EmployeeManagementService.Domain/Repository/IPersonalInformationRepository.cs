namespace EmployeeManagementService.Domain.Repository;

public interface IPersonalInformationRepository
{
    public IAsyncEnumerable<PersonalInformationModel> GetAllAsync();
    public Task<PersonalInformationModel> GetAsync(int id);
    public IAsyncEnumerable<CreatedPersonalInformationModel> CreateAsync(IEnumerable<CreatePersonalInformationModel> personalInformations);
    public Task UpdateAsync(UpdatePersonalInformationModel model);
    public Task DeleteAsync(int id);
}
