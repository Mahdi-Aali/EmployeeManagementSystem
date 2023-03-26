using Microsoft.Extensions.DependencyInjection;

namespace EMS.JobInformation.DAL.Database;

public static class JobInformationSeedData
{
    public static void InitialDatabase(IServiceProvider service)
    {
        InitialDatabaseAsync(service).Wait();
    }

    private static async Task InitialDatabaseAsync(IServiceProvider service)
    {
        var context = service.CreateAsyncScope().ServiceProvider.GetRequiredService<JobInformationContext>();
        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            await context.Database.MigrateAsync();
        }
    }
}
