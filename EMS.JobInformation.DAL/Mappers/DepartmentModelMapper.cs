namespace EMS.JobInformation.DAL.Mappers;

public static class DepartmentModelMapper
{
    public static DepartmentModel ToDomain(this Department department)
    {
        return new()
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ManagerId = department.ManagerId,
            CreateDate = department.CreateDate,
            UpdateDate = department.UpdateDate
        };
    }
}