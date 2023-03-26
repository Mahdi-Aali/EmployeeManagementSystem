namespace EMS.JobInformation.Domain.Models.DepartmentModels;

public record UpdateDepartmentModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ManagerId { get; set; }
}
