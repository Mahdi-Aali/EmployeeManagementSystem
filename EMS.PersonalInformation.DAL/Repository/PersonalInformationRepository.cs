using EMS.PersonalInformation.DAL.Mapper;
using EMS.PersonalInformation.Utilities.FileManagement;

namespace EMS.PersonalInformation.DAL.Repository;

public class PersonalInformationRepository : IPersonalInformationRepository
{
    private readonly PersonalInformationDataContext _context;
    private readonly ILogger<PersonalInformationRepository> _logger;

    public PersonalInformationRepository(PersonalInformationDataContext context,
        ILogger<PersonalInformationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<PersonalInfromationModel>> GetAllAsync() =>
       await Task.FromResult(_context.PersonalInformations.AsNoTracking().Select(s => s.ToDomain()));

    public async Task<PersonalInfromationModel> GetAsync(int id) =>
        (await _context.PersonalInformations.AsNoTracking().FirstOrDefaultAsync(pi => pi.Id.Equals(id)))?.ToDomain() ?? null!;

    public async Task<int> CreateAsync(CreatePersonalInformationModel model)
    {
        try
        {
            FileType fileType = model.ImageType switch
            {
                "png" => FileType.png,
                "jpg" => FileType.jpg,
                "jpeg" => FileType.jpeg,
                "jfif" => FileType.jfif,
                "pjpeg" => FileType.pjpeg,
                "pjp" => FileType.pjp,
                _ => throw new Exception("File type is not valid!")
            };
            string imageName = await ImageSaver.SaveAsync(model.Image, fileType);

            var personalInformation = new Entities::PersonalInformation(model.FullName,
            model.Address, model.PostalCode, model.HomeNumber,
            model.PhoneNumber, model.Email, model.SocialSecurityNumber, imageName, DateTime.Now, null);

            await _context.PersonalInformations.AddAsync(personalInformation);
            await SaveChangeAsync();
            return personalInformation.Id;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error when creating personal information.");
            return -1;
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            var personalInformation = await _context.PersonalInformations.FindAsync(id) ?? null!;
            ArgumentNullException.ThrowIfNull(personalInformation);
            _context.Entry(personalInformation).State = EntityState.Deleted;
            return await SaveChangeAsync();
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogWarning(ex, $"personal infortmation with id:{id} not found for deleting.");
            return -1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error when deleting personal information with id: {id}");
            return -1;
        }
    }

    public async Task<int> UpdateAsync(UpdatePersonalInformationModel model)
    {
        try
        {
            string imageName = string.Empty;
            if (model.Image?.Length > 0)
            {
                FileType fileType = model.ImageType switch
                {
                    "png" => FileType.png,
                    "jpg" => FileType.jpg,
                    "jpeg" => FileType.jpeg,
                    "jfif" => FileType.jfif,
                    "pjpeg" => FileType.pjpeg,
                    "pjp" => FileType.pjp,
                    _ => throw new Exception("File type is not valid!")
                };
                File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", (await _context.PersonalInformations.AsNoTracking().FirstAsync(pi => pi.Id == model.Id))!.ImageUrl));
                imageName = await ImageSaver.SaveAsync(model.Image, fileType);
            }
            var personalInformation = new Entities::PersonalInformation(model.Id, model.FullName, model.Address, model.PostalCode, model.HomeNumber
            , model.PhoneNumber, model.Email, model.SocialSecurityNumber, imageName, DateTime.MinValue, DateTime.Now);

            _context.Entry(personalInformation).Property(p => p.FullName).IsModified = true;
            _context.Entry(personalInformation).Property(p => p.Address).IsModified = true;
            _context.Entry(personalInformation).Property(p => p.PostalCode).IsModified = true;
            _context.Entry(personalInformation).Property(p => p.HomeNumber).IsModified = true;
            _context.Entry(personalInformation).Property(p => p.PhoneNumber).IsModified = true;
            _context.Entry(personalInformation).Property(p => p.Email).IsModified = true;
            _context.Entry(personalInformation).Property(p => p.SocialSecurityNumber).IsModified = true;
            _context.Entry(personalInformation).Property(p => p.UpdateDate).IsModified = true;
            if (!string.IsNullOrEmpty(imageName))
            {
                _context.Entry(personalInformation).Property(p => p.ImageUrl).IsModified = true;
            }
            return await SaveChangeAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error when updating personal information with id:{model.Id}. it maybe removed.");
            return -1;
        }
    }

    public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
}
