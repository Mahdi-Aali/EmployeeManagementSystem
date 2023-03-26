namespace EMS.PersonalInformation.DAL.Database.Entities;

public partial class PersonalInformation
{
	public PersonalInformation()
	{

	}

	public PersonalInformation(int id, string fullName, string address, string postalCode, string homeNumber,
		string phoneNumber, string email, string socialSecurityNumber, string imageUrl, DateTime createDate, DateTime? updateDate)
	{
		Id = id;
		FullName = fullName;
		Address = address;
		PostalCode = postalCode;
		HomeNumber = homeNumber;
		PhoneNumber = phoneNumber;
		Email = email;
		SocialSecurityNumber = socialSecurityNumber;
		ImageUrl = imageUrl;
		CreateDate = createDate;
		UpdateDate = updateDate;
	}

	public PersonalInformation(string fullName, string address, string postalCode, string homeNumber,
        string phoneNumber, string email, string socialSecurityNumber, string imageUrl, DateTime createDate, DateTime? updateDate)
		: this(0, fullName, address, postalCode, homeNumber, phoneNumber, email, socialSecurityNumber, imageUrl, createDate, updateDate)
	{

	}
}
