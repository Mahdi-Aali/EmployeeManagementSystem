namespace EMS.PersonalInformation.DAL.Database;

public class PersonalInformationSeedData
{
    public static void InitialDatabase(IServiceProvider service)
    {
        InitialDatabaseAsync(service.CreateAsyncScope().ServiceProvider).Wait();
    }

    private static async Task InitialDatabaseAsync(IServiceProvider service)
    {
        var context = service.GetRequiredService<PersonalInformationDataContext>();

        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            await context.Database.MigrateAsync();
        }
    }
}
