using EMS.JobInformation.DAL.Database.Entities;

namespace EMS.JobInformation.DAL.Database;

public class JobInformationContext : DbContext
{
	public JobInformationContext(DbContextOptions<JobInformationContext> options) : base (options)
	{

	}

	public DbSet<Department> Departments => Set<Department>();

}
