namespace EmployeeManagementSystem.Web.Pages.PersonalInformation;

public class DeleteModel : PageModel
{
    private readonly IPersonalInformationService _service;

    public DeleteModel(IPersonalInformationService service)
    {
        _service = service;
    }

    [FromRoute]
    public int id { get; set; }

    public async Task<IActionResult> OnGet()
    {
        await _service.DeleteAsync(id);
        return RedirectToPage("/PersonalInformation/Index");
    }
}
