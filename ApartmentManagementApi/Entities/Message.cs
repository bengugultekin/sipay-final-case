using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagementApi;

public class Message
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime SentDate { get; set; }
    public virtual User User { get; set; }
    public bool IsReaded { get; set; } = false;
}
