namespace EMS.TrafficRecordService.DAL.Database.Entities;

public class Traffic
{
    [Required]
    [Key]
    public DateTime TrafficDate { get; set; }
    [Required]
    public int Count { get; set; }
}
