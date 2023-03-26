namespace EMS.JobInformation.gRPC.Services;

public class ProtoExposeService
{
    private readonly string basePath = string.Empty;

    public ProtoExposeService(IWebHostEnvironment env)
    {
        basePath = Path.Combine(env.ContentRootPath, "Protos");
    }


    public IDictionary<string, IEnumerable<string>> GetAll()
    {
        return Directory.GetDirectories(basePath).Select(d => new
        { 
            Version = d,
            Protos = Directory.GetFiles(d).Select(Path.GetFileName)
        }).ToDictionary(o => Path.GetRelativePath("Protos", o.Version), o => o.Protos);
    }


    public string Get(string version, string name)
    {
        string path = Path.Combine(basePath, version, name);
        return File.Exists(path) ? path : null!;
    }

    public async Task<string> ViewAsync(string version, string name)
    {
        string path = Path.Combine(basePath, version, name);
        return File.Exists(path) ? await File.ReadAllTextAsync(path) : null!;
    }
}
