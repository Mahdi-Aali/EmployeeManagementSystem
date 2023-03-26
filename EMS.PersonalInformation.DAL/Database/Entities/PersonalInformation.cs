namespace EMS.PersonalInformation.DAL.Database.Entities;

public partial class PersonalInformation
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string PostalCode { get; set; } = string.Empty;

    [Required]
    [MaxLength(11)]
    public string HomeNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(14)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(10)]
    public string SocialSecurityNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string ImageUrl { get; set; } = string.Empty;

    [Required]
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
