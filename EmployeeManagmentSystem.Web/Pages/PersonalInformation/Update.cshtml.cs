using EmployeeManagement.Utitlities.Validator;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeManagementSystem.Web.Pages.PersonalInformation;

[ValidateAntiForgeryToken]
public class UpdateModel : PageModel
{
    private readonly IPersonalInformationService _service;

    public UpdateModel(IPersonalInformationService service)
    {
        _service = service;
    }

    [BindProperty]
    [FromForm]
    public UpdatePersonalInformationModel UpdatePersonalInformationModel { get; set; } = null!;

    [FromRoute]
    public int id { get; set; }

    [BindNever]
    public string ProfilePicture { get; set; } = string.Empty;

    [FromForm]
    [BindProperty]
    public IFormFile personImage { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var model = await _service.GetAsync(id);
        if (model is null)
        {
            return NotFound();
        }
        UpdatePersonalInformationModel = new()
        {
            Id = model.Id,
            FullName = model.FullName,
            Address = model.Address,
            Email = model.Email,
            HomeNumber = model.HomeNumber,
            PhoneNumber = model.PhoneNumber,
            PostalCode = model.PostalCode,
            SocialSecurityNumber = model.SocialSecurityNumber
        };
        ProfilePicture = model.ImageUrl;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (personImage is not null)
        {
            string imageType = Path.GetExtension(personImage.FileName).Replace(".", "");
            if (ImageValidator.IsValid(imageType))
            {
                MemoryStream ms = new();
                await personImage.CopyToAsync(ms);
                UpdatePersonalInformationModel.Image = ms.ToArray();
                UpdatePersonalInformationModel.ImageType = imageType;
            }
            else
            {
                ModelState.AddModelError("All", "Image format is not valid! Please enter valid format");
            }
        }
        if (ModelState.IsValid)
        {
            UpdatePersonalInformationModel.Id = id;
            await _service.UpdateAsync(UpdatePersonalInformationModel);
            return RedirectToPage("/PersonalInformation/Detail", new { id = UpdatePersonalInformationModel.Id });
        }
        return Page();
    }
}
