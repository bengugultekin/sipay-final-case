namespace ApartmentManagementApi.Models;

public class GetApartmentDetailViewModel
{
    public string HomeOwner { get; set; }
    public string Block { get; set; }
    public string Type { get; set; }
    public int Floor { get; set; }
    public int Number { get; set; }
    public bool IsEmpty { get; set; }
}
