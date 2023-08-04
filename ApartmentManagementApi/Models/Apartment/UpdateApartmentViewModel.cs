namespace ApartmentManagementApi.Models;

public class UpdateApartmentViewModel
{
    public int UserId { get; set; }
    public string Block { get; set; }
    public string Type { get; set; }
    public int Floor { get; set; }
    public int Number { get; set; }
    public bool IsEmpty { get; set; }
}
