namespace ApartmentManagementApi.Models.User;

public class CreateUserViewModel
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? PlateCode { get; set; }
}
