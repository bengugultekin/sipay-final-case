using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagementApi;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? PlateCode { get; set; }
}
