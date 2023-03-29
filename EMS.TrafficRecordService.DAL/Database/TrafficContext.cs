namespace EMS.TrafficRecordService.DAL.Database;

public class TrafficContext : DbContext
{
    public TrafficContext(DbContextOptions<TrafficContext> options) : base(options)
    {

    }

    public DbSet<Traffic> Traffics => Set<Traffic>();

}
