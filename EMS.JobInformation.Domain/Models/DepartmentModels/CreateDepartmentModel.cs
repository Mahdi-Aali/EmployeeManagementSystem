namespace EMS.JobInformation.Domain.Models.DepartmentModels;

public record CreateDepartmentModel
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ManagerId { get; set; }
}
