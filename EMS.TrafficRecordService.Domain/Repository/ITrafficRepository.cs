namespace EMS.TrafficRecordService.Domain.Repository;

public interface ITrafficRepository
{
    public Task<IDictionary<DateTime, int>> GetAllTraffics();
    public Task<IDictionary<DateTime, int>> GetTrafficInSpecifyDay(DateTime date);
    public Task<bool> CreateTraffic(DateTime date);
}
