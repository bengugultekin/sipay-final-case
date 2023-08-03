using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagementApi;

public class Apartment
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Block { get; set; }
    public string Type { get; set; }
    public int Floor { get; set; }
    public int Number { get; set; }
    public bool IsEmpty { get; set; }
    public User User { get; set; }
}
