namespace EmployeeManagementService.Domain.Models.TrafficRecorderModels;

public record TrafficModel
{
    public DateTime TrafficDate { get; set; }
    public int Count { get; set; }
}
