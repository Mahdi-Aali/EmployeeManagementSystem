namespace EmployeeManagmentSystem.Web.Pages.PersonalInformation;

public class IndexModel : PageModel
{
    private readonly IPersonalInformationService _service;

    public IndexModel(IPersonalInformationService service)
    {
        _service = service;
    }

    public IEnumerable<PersonalInformationModel> Data { get; set; } = Enumerable.Empty<PersonalInformationModel>();

    public async Task OnGetAsync()
    {
        Data = await _service.GetAllAsync();
    }
}