﻿namespace ApartmentManagementApi.Models;

public class GetMessagesViewModel
{
    public string UserName { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime SentDate { get; set; }
    public bool IsReaded { get; set; }
}
