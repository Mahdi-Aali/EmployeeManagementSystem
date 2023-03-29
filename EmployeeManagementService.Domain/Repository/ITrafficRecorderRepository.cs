namespace EmployeeManagementService.Domain.Repository;

public interface ITrafficRecorderRepository
{
    public IAsyncEnumerable<TrafficModel> GetAllAsync();
    public IAsyncEnumerable<TrafficModel> GetTrafficsInSpecifyDayAsync(DateTime date);
    public Task CreateTrafficAsync(DateTime date);
}
