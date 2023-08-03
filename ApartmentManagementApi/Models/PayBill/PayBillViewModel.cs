namespace ApartmentManagementApi.Models;

public class PayBillViewModel
{
    public double CardNumber { get; set; }
    public int CardCvc { get; set; }
    public string CardOwner { get; set; }
    public DateTime CardLastUseDate { get; set; }
}
