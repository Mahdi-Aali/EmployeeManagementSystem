using static EMS.JobInformation.gRPC.Protos.V1.DepartmentService;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.
services.AddRazorPages();
services.AddControllersWithViews();
services.AddServerSideBlazor();

services.AddGrpcClient<PersonalInformationServiceClient>(opt =>
{
    opt.Address = new Uri(configuration.GetSection("PersonalInformationServiceUri").Value);
}).ConfigureChannel(o =>
{
    o.CompressionProviders = new List<ICompressionProvider>()
    { 
        new BrotliCompressionProvider(CompressionLevel.Optimal)
    };
});


services.AddGrpcClient<DepartmentServiceClient>(opt =>
{
    opt.Address = new Uri(configuration.GetSection("DepartmentServiceUri").Value);
}).ConfigureChannel(options =>
{
    options.CompressionProviders = new List<ICompressionProvider>()
    { 
        new BrotliCompressionProvider(CompressionLevel.Optimal)
    };
});


services.AddScoped<IPersonalInformationService, PersonalInformationService>();
services.AddScoped<IPersonalInformationRepository, PersonalInformationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
