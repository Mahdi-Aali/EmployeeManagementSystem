namespace EMS.PersonalInformation.Domain.Repository;

public interface IPersonalInformationRepository
{
    public Task<IEnumerable<PersonalInfromationModel>> GetAllAsync();
    public Task<PersonalInfromationModel> GetAsync(int id);
    public Task<int> CreateAsync(CreatePersonalInformationModel model);
    public Task<int> DeleteAsync(int id);
    public Task<int> UpdateAsync(UpdatePersonalInformationModel model);
}
