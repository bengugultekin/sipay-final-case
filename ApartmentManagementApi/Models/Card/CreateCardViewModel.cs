﻿namespace ApartmentManagementApi.Models;

public class CreateCardViewModel
{
    public double Number { get; set; }
    public DateTime LastUseDate { get; set; }
    public int Cvc { get; set; }
    
}
