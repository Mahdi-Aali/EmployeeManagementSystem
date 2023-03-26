using Google.Protobuf.WellKnownTypes;

namespace EMS.PersonalInformation.gRPC.Mapper;

public static class PersonalInformationMapper
{
    public static PersonalInformationReply ToReply(this PersonalInfromationModel model)
    {
        return model is not null ? new PersonalInformationReply()
        { 
            Id = model.Id,
            FullName = model.FullName,
            Address = model.Address,
            HomeNumber = model.HomeNumber,
            PhoneNumber = model.PhoneNumber,
            PostalCode = model.PostalCode,
            Email = model.Email,
            SocialSecurityNumber = model.SocialSecurityNumber,
            ImageUrl = model.ImageUrl,
            CreateDate = Timestamp.FromDateTime(DateTime.SpecifyKind(model.CreateDate, DateTimeKind.Utc)),
            UpdateDate = Timestamp.FromDateTime(DateTime.SpecifyKind(model.UpdateDate ?? DateTime.MinValue, DateTimeKind.Utc))
        } : new();
    }
}
