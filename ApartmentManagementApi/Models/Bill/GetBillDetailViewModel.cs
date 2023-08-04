namespace ApartmentManagementApi.Models;

public class GetBillDetailViewModel
{
    public string Customer { get; set; }
    public decimal Cost { get; set; }
    public DateTime BillCreatedDate { get; set; }
    public DateTime BillLastPayDate { get; set; }
    public DateTime? BillPaidDate { get; set; }
    public bool IsPaid { get; set; }
}
