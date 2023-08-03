namespace ApartmentManagementApi.Models;

public class SentMessageViewModel
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime SentDate { get; set; }
}
