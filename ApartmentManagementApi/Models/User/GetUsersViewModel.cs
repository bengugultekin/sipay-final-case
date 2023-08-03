using ApartmentManagementApi.Migrations;

namespace ApartmentManagementApi.Models;

public class GetUsersViewModel
{
    public string NameSurname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? PlateCode { get; set; }
    public ICollection<BillViewModel>? Bills { get; set; } = new List<BillViewModel>();
    public ICollection<CardViewModel> Cards { get; set; } = new List<CardViewModel>();

}
