namespace EmployeeManagementSystem.Web.Pages.PersonalInformation;

public class DetailModel : PageModel
{
    private readonly IPersonalInformationService _services;

    public DetailModel(IPersonalInformationService services)
    {
        _services = services;
    }

    public PersonalInformationModel PersonalInformation { get; set; } = null!;

    [FromRoute]
    public int id { get; set; }
    public async Task<IActionResult> OnGet()
    {
        PersonalInformation = await _services.GetAsync(id);
        if (PersonalInformation is null)
        {
            return NotFound();
        }
        return Page();
    }
}
