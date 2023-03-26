using EmployeeManagement.Utitlities.Validator;
using Google.Protobuf;
using System.IO.Pipelines;

namespace EmployeeManagementSystem.Web.Pages.PersonalInformation;

[AutoValidateAntiforgeryToken]
public class CreateModel : PageModel
{
    private readonly IPersonalInformationService _services;

    public CreateModel(IPersonalInformationService services) => _services = services;


    [BindProperty]
    [FromForm]
    public CreatePersonalInformationModel Model { get; set; } = new();

    [BindProperty]
    [FromForm]
    public IFormFile personImage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (personImage is null)
        {
            ModelState.AddModelError("All", "Person image can't be null!");
        }
        else
        {
            MemoryStream ms = new();
            await personImage.CopyToAsync(ms);
            Model.Image = ms.ToArray();
            Model.ImageType = Path.GetExtension(personImage.FileName).Replace(".", "").ToString();
        }
        if (ImageValidator.IsValid(Model.ImageType))
        {
            ModelState.AddModelError("All", "Image format is not valid!");
        }
        if (ModelState.IsValid)
        {
            await _services.CreateAsync(new List<CreatePersonalInformationModel>()
            { 
                Model
            });
            TempData["Success"] = Model.FullName;
            return RedirectToPage("/PersonalInformation/Index");
        }
        return Page();
    }
}
