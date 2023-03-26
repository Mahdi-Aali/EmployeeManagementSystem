namespace EMS.PersonalInformation.BLL.Services;

public class PersonalInformationService : IPersonalInformationServices
{
    private readonly IPersonalInformationRepository _repository;

    public PersonalInformationService(IPersonalInformationRepository repository) => _repository = repository;

    public async Task<IEnumerable<PersonalInfromationModel>> GetAllAsync() =>
    await _repository.GetAllAsync();

    public async Task<PersonalInfromationModel> GetAsync(int id) =>
        await _repository.GetAsync(id);

    public async Task<int> CreateAsync(CreatePersonalInformationModel model) =>
        await _repository.CreateAsync(model);

    public async Task<bool> UpdateAsync(UpdatePersonalInformationModel model) =>
    await _repository.UpdateAsync(model) > 0;

    public async Task<bool> DeleteAsync(int id) =>
        await _repository.DeleteAsync(id) > 0;
}
