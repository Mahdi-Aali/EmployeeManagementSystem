namespace EmployeeManagementService.Domain.Models;

public record CreatedPersonalInformationModel
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
}
