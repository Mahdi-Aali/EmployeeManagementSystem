using EMS.TrafficRecordService.gRPC.Compression;
using Services = EMS.TrafficRecordService.gRPC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();
var services = builder.Services;
var configuration = builder.Configuration;

services.AddGrpc(opt =>
{
    opt.CompressionProviders = new List<ICompressionProvider>()
    {
        new BrotliCompressionProvider(CompressionLevel.Optimal)
    };
    opt.EnableDetailedErrors = true;
    opt.ResponseCompressionAlgorithm = "br";
});

services.AddDbContext<TrafficContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("default"), options =>
    {
        options.MigrationsAssembly("EMS.TrafficRecordService.gRPC");
    });
});

services.AddScoped<ITrafficRepository, EfTrafficRepository>();
services.AddScoped<ITrafficRecordService, TrafficRecordService>();
services.AddSingleton<ProtoExposeService>();

var app = builder.Build();


//app.MapGrpcService<GreeterService>();
app.MapGrpcService<Services::TrafficService>();
app.MapGet("/", () => "Hello World");
app.MapGet("/Protos", ([FromServices] ProtoExposeService service) =>
{
    return Results.Ok(service.GetAll());
});
app.MapGet("/Protos/{version}/{name}", ([FromServices] ProtoExposeService service, [FromRoute] string version, [FromRoute] string name) =>
{
    return Results.File(service.Get(version, name));
});
app.MapGet("/Protos/{version}/{name}/view",async ([FromServices] ProtoExposeService service, [FromRoute] string version, [FromRoute] string name) =>
{
    return Results.Text(await service.ViewAsync(version, name));
});

TrafficServiceSeedData.InitialDatabase(app.Services);

app.Run();
