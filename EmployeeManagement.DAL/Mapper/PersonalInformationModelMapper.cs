namespace EmployeeManagement.DAL.Mapper;

public static class PersonalInformationModelMapper
{
    public static PersonalInformationModel ToDomain(this PersonalInformationReply reply)
    {
        return reply.Id > 0 ? new PersonalInformationModel()
        {
            Id = reply.Id,
            FullName = reply.FullName,
            Address = reply.Address,
            Email = reply.Email,
            HomeNumber = reply.HomeNumber,
            PhoneNumber = reply.PhoneNumber,
            PostalCode = reply.PostalCode,
            SocialSecurityNumber = reply.SocialSecurityNumber,
            ImageUrl = reply.ImageUrl,
            CreateDate = reply.CreateDate.ToDateTime(),
            UpdateDate = reply.UpdateDate.ToDateTime()
        } : null!;
    }
}
