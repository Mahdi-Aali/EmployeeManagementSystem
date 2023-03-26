namespace EMS.JobInformation.DAL.Database.Entities;

public partial class Department
{
	public Department()
	{

	}

	public Department(int id, string name, string description, int managerId, DateTime createDate, DateTime? updateDate)
	{
		Id = id;
		Name = name;
		Description = description;
		ManagerId = managerId;
		CreateDate = CreateDate;
		UpdateDate = updateDate;
	}

	public Department(string name, string description, int managerId, DateTime? updateDate) 
		: this(0, name, description, managerId, DateTime.Now, updateDate)
	{

	}

}
