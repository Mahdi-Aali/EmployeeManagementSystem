using System.Text;

namespace EmployeeManagementSystem.Web.Components;

public class FullTrafficViewComponent : ViewComponent
{
    private readonly ITrafficRecordService _service;

	public FullTrafficViewComponent(ITrafficRecordService service) => _service = service;


    public async Task<IViewComponentResult> InvokeAsync()
    {
        StringBuilder dates = new();
        StringBuilder counts = new();
        await foreach(var item in _service.GetAllTrafficsAsync())
        {
            dates.Append(@$"'{item.TrafficDate.ToShortTimeString()}', ");
            counts.Append($"{item.Count},");
        }
        ViewBag.Dates = dates.ToString().Remove(dates.Length - 2, 1);
        ViewBag.Counts = counts.ToString().Remove(counts.Length - 2, 2);
        return View();
    }
}
