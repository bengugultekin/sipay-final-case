using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagementApi;

public class Card
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime LastUseDate { get; set; }
    public double Number { get; set; }
    public int Cvc { get; set; }
    public virtual User User { get; set; }

}
