namespace EmployeeManagementService.Domain.Models;

public record UpdatePersonalInformationModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "the field full name can't be null")]
    [MaxLength(50, ErrorMessage = "you can't enter more than 50 characters for full name")]
    [MinLength(3, ErrorMessage = "you can't enter less than 3 characters for full name")]
    public string FullName { get; set; } = string.Empty;
    [Required]
    [MaxLength(300, ErrorMessage = "you can't enter more than 300 characters for address")]
    [MinLength(10, ErrorMessage = "you can't enter less than 10 characters for address")]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "the field postal code can't be null")]
    [MaxLength(10, ErrorMessage = "you can't enter more than 10 characters for postal code")]
    [MinLength(10, ErrorMessage = "you can't enter less than 10 characters for postal code")]
    public string PostalCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "the field home number can't be null")]
    [MaxLength(11, ErrorMessage = "you can't enter more than 11 characters for home number")]
    [MinLength(8, ErrorMessage = "you can't enter less than 8 characters for home number")]
    public string HomeNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "the field phone number can't be null")]
    [MaxLength(14, ErrorMessage = "you can't enter more than 14 characters for phone number")]
    [MinLength(10, ErrorMessage = "you can't enter less than 10 characters for phone number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "the field email can't be null")]
    [MaxLength(150, ErrorMessage = "you can't enter more than 150 characters for email address")]
    [MinLength(7, ErrorMessage = "you can't enter less than 7 characters for email address")]
    [EmailAddress(ErrorMessage = "Please enter valid email address")]
    [DataType(DataType.EmailAddress, ErrorMessage = "Please enter valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "the field social security number can't be null")]
    [MaxLength(10, ErrorMessage = "you can't enter more than 10 characters for social security number")]
    [MinLength(10, ErrorMessage = "you can't enter less than 10 characters for social security number")]
    public string SocialSecurityNumber { get; set; } = string.Empty;

    public byte[]? Image { get; set; } = Array.Empty<byte>();

    public string? ImageType { get; set; } = string.Empty;
}
