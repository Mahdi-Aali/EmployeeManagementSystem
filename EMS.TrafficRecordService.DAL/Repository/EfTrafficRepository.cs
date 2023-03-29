using System.Linq;

namespace EMS.TrafficRecordService.DAL.Repository;

public class EfTrafficRepository : ITrafficRepository
{
    private readonly TrafficContext _context;
    private readonly ILogger<EfTrafficRepository> _logger;

    public EfTrafficRepository(TrafficContext context, ILogger<EfTrafficRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<IDictionary<DateTime, int>> GetAllTraffics()
    {
        return await _context.Traffics
            .AsNoTracking().ToDictionaryAsync(o => o.TrafficDate, o => o.Count);

    }

    public async Task<IDictionary<DateTime, int>> GetTrafficInSpecifyDay(DateTime date)
    {
        return await _context.Traffics
            .AsNoTracking()
            .Where(o => o.TrafficDate.ToShortDateString() == date.ToShortDateString())
            .ToDictionaryAsync(o => o.TrafficDate, o => o.Count);
    }


    public async Task<bool> CreateTraffic(DateTime date)
    {
        try
        {
            var traffic = await _context.Traffics
                .FirstOrDefaultAsync(t => t.TrafficDate == new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0, 0));

            if (traffic is not null)
            {
                traffic.Count++;
                _context.Entry(traffic).Property(p => p.Count).IsModified = true;
            }
            else
            {
                await _context.Traffics.AddAsync(new()
                {
                    TrafficDate = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0, 0),
                    Count = 1
                });
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "some thing went wrong when adding new traffic to data base.");
            return false;
        }
    }

}
