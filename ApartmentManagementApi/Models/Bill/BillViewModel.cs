namespace ApartmentManagementApi.Models;

public class BillViewModel
{
    public decimal Cost { get; set; }
    public DateTime BillCreatedDate { get; set; }
    public DateTime BillLastPayDate { get; set; }
    public DateTime? BillPaidDate { get; set; }
    public bool IsPaid { get; set; }
}
