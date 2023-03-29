namespace EMS.TrafficRecordService.Domain.Services;

public interface ITrafficRecordService
{
    public Task<IDictionary<DateTime, int>> GetAllAsync();

    public Task<IDictionary<DateTime, int>> GetTrafficByDay(DateTime day);

    public Task<bool> CreateTraffic(DateTime date);
}
