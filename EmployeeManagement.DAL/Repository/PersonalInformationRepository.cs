using Google.Protobuf;

namespace EmployeeManagement.DAL.Repository;

public class PersonalInformationRepository : IPersonalInformationRepository
{

    private readonly PersonalInformationServiceClient _client;

    public PersonalInformationRepository(PersonalInformationServiceClient client) => _client = client;

    public async IAsyncEnumerable<CreatedPersonalInformationModel> CreateAsync(IEnumerable<CreatePersonalInformationModel> personalInformations)
    {
        using(var bidirectionStream = _client.Create())
        {
            foreach(var item in personalInformations)
            {
                await bidirectionStream.RequestStream.WriteAsync(new PersonalInformationCreateRequest()
                {
                    FullName = item.FullName,
                    Address = item.Address,
                    Email = item.Email,
                    HomeNumber = item.HomeNumber,
                    PhoneNumber = item.PhoneNumber,
                    PostalCode = item.PostalCode,
                    SocialSecurityNumber = item.SocialSecurityNumber,
                    Image = ByteString.CopyFrom(item.Image),
                    ImageType = item.ImageType
                });
            }

            await bidirectionStream.RequestStream.CompleteAsync();

            while (await bidirectionStream.ResponseStream.MoveNext(default))
            {
                var current = bidirectionStream.ResponseStream.Current;
                yield return new CreatedPersonalInformationModel()
                {
                    Id = current.Id,
                    FullName = current.FullName
                };
            }
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _client.DeleteAsync(new PersonalInformationIdRequest() { Id = id });
        await Task.CompletedTask;
    }

    public async IAsyncEnumerable<PersonalInformationModel> GetAllAsync()
    {
        using (var serverStream = _client.GetAll(new EmptyMessage()))
        {
            while(await serverStream.ResponseStream.MoveNext(default))
            {
                yield return serverStream.ResponseStream.Current.ToDomain();
            }
        }
    }

    public async Task<PersonalInformationModel> GetAsync(int id) => 
        (await _client.GetAsync(new PersonalInformationIdRequest()
        { 
            Id = id
        })).ToDomain();

    

    public async Task UpdateAsync(UpdatePersonalInformationModel model)
    {
        await _client.UpdateAsync(new PersonalInformationUpdateRequest()
        { 
            Id = model.Id,
            FullName = model.FullName,
            Address = model.Address,
            HomeNumber = model.HomeNumber,
            PhoneNumber = model.PhoneNumber,
            PostalCode = model.PostalCode,
            Email = model.Email,
            SocialSecurityNumber = model.SocialSecurityNumber,
            Image = ByteString.CopyFrom(model.Image),
            ImageType = model.ImageType
        });

        await Task.CompletedTask;
    }
}
