using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagementApi;

public class Debt
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime? DebtPaidDate { get; set; }
    public DateTime DebtLastPayDate { get; set; }
    public decimal Cost { get; set; }
    public bool IsPaid { get; set; }
}
