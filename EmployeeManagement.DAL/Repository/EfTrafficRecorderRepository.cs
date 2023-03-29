using static EMS.TrafficRecordService.gRPC.Protos.V1.TrafficService;

namespace EmployeeManagement.DAL.Repository;

public class EfTrafficRecorderRepository : ITrafficRecorderRepository
{
    private readonly TrafficServiceClient _client;

    public EfTrafficRecorderRepository(TrafficServiceClient client)
    {
        _client = client;
    }

    public async Task CreateTrafficAsync(DateTime date)
    {
        await _client.CreateAsync(new CreateTrafficRequest()
        {
            Date = Timestamp.FromDateTime(DateTime.SpecifyKind(date, DateTimeKind.Utc))
        });
    }

    public async IAsyncEnumerable<TrafficModel> GetAllAsync()
    {
        await foreach(var item in _client.GetAll(new EMS.TrafficRecordService.gRPC.Protos.V1.EmptyMessage()).ResponseStream.ReadAllAsync())
        {
            yield return new TrafficModel()
            { 
                TrafficDate = item.Date.ToDateTime(),
                Count = item.Count
            };
        }
    }

    public async IAsyncEnumerable<TrafficModel> GetTrafficsInSpecifyDayAsync(DateTime date)
    {
        await foreach(var item in _client.GetSpecifyDayTraffic(new GetSpecifyDayTrafficRequest()
        {
            Date = Timestamp.FromDateTime(DateTime.SpecifyKind(date, DateTimeKind.Utc))
        }).ResponseStream.ReadAllAsync())
        {
            yield return new TrafficModel()
            {
                TrafficDate = item.Date.ToDateTime(),
                Count = item.Count
            };
        }
    }
}
