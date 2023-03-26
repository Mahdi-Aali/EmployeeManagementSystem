namespace EMS.PersonalInformation.gRPC.Services
{
    public class ProtoExposeService
    {
        private IWebHostEnvironment _env;
        private string rootPath = string.Empty;

        public ProtoExposeService(IWebHostEnvironment env)
        {
            _env = env;
            rootPath = Path.Combine(env.ContentRootPath, "Protos");
        }

        public IDictionary<string, IEnumerable<string>> GetAll()
        {
            return Directory
                .GetDirectories(rootPath)
                .Select(s => new
                { 
                    Version = s,
                    Protos = Directory.GetFiles(s).Select(Path.GetFileName)
                })
                .ToDictionary(o => Path.GetRelativePath("Protos", o.Version), o => o.Protos)!;
        }

        public string Get(string version, string name)
        {
            string path = Path.Combine(rootPath, version, name);
            return File.Exists(path) ? path : null!;
        }

        public async Task<string> ViewAsync(string version, string name)
        {
            var path = Path.Combine(rootPath, version, name);

            return File.Exists(path) ? await File.ReadAllTextAsync(path) : null!;
        }
    }
}
