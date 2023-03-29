using EMS.TrafficRecordService.Domain.Repository;
using EMS.TrafficRecordService.Domain.Services;

namespace EMS.TrafficRecordService.BLL.Services;

public class TrafficRecordService : ITrafficRecordService
{
    private readonly ITrafficRepository _repository;

    public TrafficRecordService(ITrafficRepository repository)
    {
        _repository = repository;
    }

    public async Task<IDictionary<DateTime, int>> GetAllAsync() => await _repository.GetAllTraffics();

    public async Task<IDictionary<DateTime, int>> GetTrafficByDay(DateTime day) => await _repository.GetTrafficInSpecifyDay(day);

    public async Task<bool> CreateTraffic(DateTime date) => await _repository.CreateTraffic(date);
}
