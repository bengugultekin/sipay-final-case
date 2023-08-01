using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagementApi;

public class Bill
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public decimal Cost { get; set; }
    public DateTime BillCreatedDate { get; set; }
    public DateTime BillLastPayDate { get; set; }
    public DateTime? BillPaidDate { get; set; }
    public bool IsPaid { get; set; } = false;
    public virtual User User { get; set; }
}
