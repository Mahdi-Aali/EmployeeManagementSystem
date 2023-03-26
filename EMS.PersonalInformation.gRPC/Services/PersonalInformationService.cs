namespace EMS.PersonalInformation.gRPC.Services;

public class PersonalInformationService : PersonalInformationServiceBase
{
    private readonly IPersonalInformationServices _service;
    private readonly IDistributedCache _cache;
    private const string cacheKey = "PI_CacheKey";

    public PersonalInformationService(IPersonalInformationServices service, IDistributedCache cache)
    {
        _service = service;
        _cache = cache;
    }

    public override async Task GetAll(EmptyMessage request, IServerStreamWriter<PersonalInformationReply> responseStream, ServerCallContext context)
    {
        var cachedList = JsonConvert.DeserializeObject<IEnumerable<PersonalInfromationModel>>(await _cache.GetStringAsync(cacheKey) ?? "");
        if (cachedList is not null)
        {
            foreach(var item in cachedList)
            {
                await responseStream.WriteAsync(item.ToReply());
            }
        }
        else
        {
            var list = await _service.GetAllAsync();
            foreach (var item in list)
            {
                await responseStream.WriteAsync(item.ToReply());
            }
            await _cache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(list), new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });
        }
        await Task.CompletedTask;
    }

    public override async Task<PersonalInformationReply> Get(PersonalInformationIdRequest request, ServerCallContext context) =>
        (await _service.GetAsync(request.Id)).ToReply();

    public override async Task Create(IAsyncStreamReader<PersonalInformationCreateRequest> requestStream, IServerStreamWriter<PersonalInformationCreateReply> responseStream, ServerCallContext context)
    {
        await foreach (var item in requestStream.ReadAllAsync())
        {
            int currentInformationId = await _service.CreateAsync(new CreatePersonalInformationModel()
            {
                FullName = item.FullName,
                Address = item.Address,
                HomeNumber = item.HomeNumber,
                PhoneNumber = item.PhoneNumber,
                PostalCode = item.PostalCode,
                Email = item.Email,
                SocialSecurityNumber = item.SocialSecurityNumber,
                Image = item.Image.ToByteArray(),
                ImageType = item.ImageType
            });

            await responseStream.WriteAsync(new PersonalInformationCreateReply()
            {
                Id = currentInformationId,
                FullName = item.FullName
            });
        }
        await ClearCache();
        await Task.CompletedTask;
    }

    public override async Task<EmptyMessage> Update(PersonalInformationUpdateRequest request, ServerCallContext context)
    {
        bool updateResult = await _service.UpdateAsync(new UpdatePersonalInformationModel()
        {
            Id = request.Id,
            FullName = request.FullName,
            Address = request.Address,
            Email = request.Email,
            HomeNumber = request.HomeNumber,
            PhoneNumber = request.PhoneNumber,
            PostalCode = request.PostalCode,
            SocialSecurityNumber = request.SocialSecurityNumber,
            Image = request.Image.ToByteArray(),
            ImageType = request.ImageType
        });
        await ClearCache();
        return updateResult ? new EmptyMessage() : throw new RpcException(new Status(StatusCode.NotFound, $"Information with id:{request.Id} Not Found!"));
    }

    public override async Task<EmptyMessage> Delete(PersonalInformationIdRequest request, ServerCallContext context)
    {
        bool deleteResult = await _service.DeleteAsync(request.Id);
        await ClearCache();
        return deleteResult ? new EmptyMessage() : throw new RpcException(new Status(StatusCode.NotFound, $"Information with id:{request.Id} han't beed found!"));
    }

    private async Task ClearCache() => await _cache.RemoveAsync(cacheKey);
}
