namespace EMS.PersonalInformation.DAL.Mapper;

public static class PersonalInformationModelMapper
{
    public static PersonalInfromationModel ToDomain(this Entities::PersonalInformation personalInformation)
    {
        return new PersonalInfromationModel()
        {
            Id = personalInformation.Id,
            FullName = personalInformation.FullName,
            Address = personalInformation.Address,
            PostalCode = personalInformation.PostalCode,
            Email = personalInformation.Email,
            HomeNumber = personalInformation.HomeNumber,
            PhoneNumber = personalInformation.PhoneNumber,
            SocialSecurityNumber = personalInformation.SocialSecurityNumber,
            ImageUrl = personalInformation.ImageUrl,
            CreateDate = personalInformation.CreateDate,
            UpdateDate = personalInformation.UpdateDate
        };
    }
}
