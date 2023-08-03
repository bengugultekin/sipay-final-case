namespace ApartmentManagementApi.Models;

public class CreateCardViewModel
{
    public int UserId { get; set; }
    public DateTime LastUseDate { get; set; }
    public double Number { get; set; }
    public int Cvc { get; set; }
}
