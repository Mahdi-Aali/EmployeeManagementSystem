namespace EMS.PersonalInformation.Domain.Models;

public record CreatePersonalInformationModel
{
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string HomeNumber { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SocialSecurityNumber { get; set; } = string.Empty;
    public byte[] Image { get; set; } = Array.Empty<byte>();
    public string ImageType { get; set; } = string.Empty;
}
