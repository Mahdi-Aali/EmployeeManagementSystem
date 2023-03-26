namespace EMS.PersonalInformation.DAL.Database;

public class PersonalInformationDataContext : DbContext
{
	public PersonalInformationDataContext(DbContextOptions<PersonalInformationDataContext> options) : base(options)
	{

	}

	public DbSet<Entities::PersonalInformation> PersonalInformations => Set<Entities::PersonalInformation>();

}
