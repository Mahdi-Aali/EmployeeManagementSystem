namespace EMS.PersonalInformation.Utilities.FileManagement;

public static class ImageSaver
{
    private static string rootPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
    public static async Task<string> SaveAsync(byte[] buffer, FileType type)
    {
        string imageName = Guid.NewGuid().ToString().Replace("-", "") + "." + Enum.GetName(type);
        string filePath = Path.Combine(rootPath, imageName);
        using (FileStream fs = File.Create(filePath))
        {
            await fs.WriteAsync(buffer);
        }
        return imageName;
    }
}
