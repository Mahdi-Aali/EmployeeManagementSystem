namespace EMS.PersonalInformation.Domain.Services;

public interface IPersonalInformationServices
{
    public Task<IEnumerable<PersonalInfromationModel>> GetAllAsync();
    public Task<PersonalInfromationModel> GetAsync(int id);
    public Task<int> CreateAsync(CreatePersonalInformationModel model);
    public Task<bool> UpdateAsync(UpdatePersonalInformationModel model);
    public Task<bool> DeleteAsync(int id);
}
