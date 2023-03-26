namespace EmployeeManagementSystem.BLL.Services;

public class PersonalInformationService : IPersonalInformationService
{
    private readonly IPersonalInformationRepository _repository;

    public PersonalInformationService(IPersonalInformationRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PersonalInformationModel>> GetAllAsync()
    {
        var list = new List<PersonalInformationModel>();

        await foreach(var item in _repository.GetAllAsync())
        {
            list.Add(item);
        }

        return list;
    }

    public async Task<PersonalInformationModel> GetAsync(int id) =>
        await _repository.GetAsync(id);

    public async Task CreateAsync(IEnumerable<CreatePersonalInformationModel> models)
    {
        await foreach(var item in _repository.CreateAsync(models))
        {
            Console.WriteLine($"Personal Information with Id: {item.Id} and full name: {item.FullName} created.");
        }
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(UpdatePersonalInformationModel model)
    {
        await _repository.UpdateAsync(model);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
        await Task.CompletedTask;
    }
}
