var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddGrpc(opt =>
{
    opt.CompressionProviders = new List<ICompressionProvider>()
    {
        new BrotliCompression(CompressionLevel.Optimal)
    };
    opt.EnableDetailedErrors = true;
    opt.ResponseCompressionAlgorithm = "br";
});

services.AddDbContext<JobInformationContext>(opt =>
{
    opt.UseSqlServer(configuration.GetConnectionString("default"), options =>
    {
        options.MigrationsAssembly("EMS.JobInformation.gRPC");
    });
});

services.AddSingleton<ProtoExposeService>();
services.AddScoped<IDepartmentRepository, EfDepartmentRepository>();
services.AddScoped<IDepartmentService, BLL::DepartmentService>();

services.Configure<RouteOptions>(opt =>
{
    opt.ConstraintMap.Add("string", typeof(StringRouteConstraint));
});

var app = builder.Build();

app.MapGrpcService<Services::DepartmentService>();
app.MapGet("/", () => "Hello World!");

app.MapGet("/Protos", ([FromServices] ProtoExposeService service) =>
{
    return Results.Ok(service.GetAll());
});
app.MapGet("/Protos/{version:string}/{name:string}", ([FromServices] ProtoExposeService service, [FromRoute] string version, [FromRoute] string name) =>
{
    return Results.File(service.Get(version, name));
});
app.MapGet("/Protos/{version:string}/{name:string}/view", async ([FromServices] ProtoExposeService service, [FromRoute] string version, [FromRoute] string name) =>
{
    return Results.Text(await service.ViewAsync(version, name));
});



JobInformationSeedData.InitialDatabase(app.Services);

app.Run();
