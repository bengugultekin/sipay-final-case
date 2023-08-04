namespace ApartmentManagementApi.Models;

public class UpdateUserViewModel
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? PlateCode { get; set; }
}
