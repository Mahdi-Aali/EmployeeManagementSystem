namespace EmployeeManagementSystem.BLL.Services;

public class TrafficRecordService : ITrafficRecordService
{
    private readonly ITrafficRecorderRepository _repository;

    public TrafficRecordService(ITrafficRecorderRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateTrafficAsync(DateTime date)
    {
        await _repository.CreateTrafficAsync(date);
        await Task.CompletedTask;
    }

    public async IAsyncEnumerable<TrafficModel> GetAllTrafficsAsync()
    {
        await foreach(var item in _repository.GetAllAsync())
        {
            yield return item;
        }
    }

    public async IAsyncEnumerable<TrafficModel> GetTrafficsInSpecifyDayAsync(DateTime day)
    {
        await foreach(var item in _repository.GetTrafficsInSpecifyDayAsync(day))
        {
            yield return item;
        }
    }
}
