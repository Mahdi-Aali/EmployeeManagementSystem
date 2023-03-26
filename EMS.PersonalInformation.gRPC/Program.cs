using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;


services.AddGrpc(opt =>
{
    opt.EnableDetailedErrors = true;
    opt.CompressionProviders = new List<ICompressionProvider>()
    {
        new BrotliCompressionProvider(CompressionLevel.Optimal)
    };
    opt.ResponseCompressionLevel = CompressionLevel.Optimal;
    opt.ResponseCompressionAlgorithm = "br";
});

services.AddDbContext<PersonalInformationDataContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("defualt"), opt =>
    {
        opt.MigrationsAssembly("EMS.PersonalInformation.gRPC");
    });
});

services.Configure<RouteOptions>(opt =>
{
    opt.ConstraintMap.Add("string", typeof(StringRouteConstraint));
});

services.AddScoped<IPersonalInformationServices, BllService::PersonalInformationService>();
services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();
services.AddSingleton<Services::ProtoExposeService>();

services.AddDistributedMemoryCache();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Images")),
    RequestPath = "/Images"
});


app.MapGrpcService<Services::PersonalInformationService>();
app.MapGet("/", () => "Hello World!");

app.MapGet("/protos", ([FromServices] Services::ProtoExposeService service) =>
{
    return Results.Ok(service.GetAll());
});
app.MapGet("/protos/{version:string}/{name:string}", ([FromServices] Services::ProtoExposeService service, [FromRoute] string version, [FromRoute] string name) =>
{
    return Results.File(service.Get(version, name));
});
app.MapGet("/protos/{version:string}/{name:string}/view", async ([FromServices] Services::ProtoExposeService service, [FromRoute] string version, [FromRoute] string name) =>
{
    return Results.Text(await service.ViewAsync(version, name));
});

PersonalInformationSeedData.InitialDatabase(app.Services);

app.Run();
