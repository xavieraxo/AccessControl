using System;
using System.Collections.Generic;

namespace AccessControlWebRazor.DTO_s.VehiculosUnificados;
public class ResponseGetListVehicleAPI
{
    public string code { get; set; }
    public string msg { get; set; }
    public Data data { get; set; }
}

public class Data
{
    public int total { get; set; }
    public int pageNo { get; set; }
    public int pageSize { get; set; }
    public List<Item> list { get; set; }
}

public class Item
{
    public string vehicleId { get; set; }
    public string plateNo { get; set; }
    public string personName { get; set; }
    public string personFamilyName { get; set; }
    public string personGivenName { get; set; }
    public string phoneNo { get; set; }
    public int vehicleColor { get; set; }
    public string vehicleGroupIndexCode { get; set; }
    public DateTime effectiveDate { get; set; }
    public DateTime expiredDate { get; set; }
}
