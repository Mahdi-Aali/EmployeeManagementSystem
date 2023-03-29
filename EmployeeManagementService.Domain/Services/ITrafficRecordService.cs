namespace EmployeeManagementService.Domain.Services;

public interface ITrafficRecordService
{
    public IAsyncEnumerable<TrafficModel> GetAllTrafficsAsync();
    public IAsyncEnumerable<TrafficModel> GetTrafficsInSpecifyDayAsync(DateTime day);
    public Task CreateTrafficAsync(DateTime date);
}
