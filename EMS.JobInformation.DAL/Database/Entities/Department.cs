using System.ComponentModel.DataAnnotations;

namespace EMS.JobInformation.DAL.Database.Entities;

public partial class Department
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(800)]
    public string Description { get; set; } = string.Empty;

    [Required] // It come from Personal Informations Service
    public int ManagerId { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    public DateTime? UpdateDate { get; set; }
}
