namespace EMS.PersonalInformation.Domain.Models;

public record PersonalInfromationModel
{
    public int Id { get; init; }
    public string FullName { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public string HomeNumber { get; init; } = string.Empty;
    public string PhoneNumber { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string SocialSecurityNumber { get; init; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreateDate { get; init; }
    public DateTime? UpdateDate { get; init; }
}
