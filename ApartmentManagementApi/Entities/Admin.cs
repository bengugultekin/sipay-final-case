using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentManagementApi;

public class Admin
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpireDate { get; set; }
    public User User { get; set; }

}
