namespace WebApiBackgroundServices.Domain.models;

public class Telephone
{
  public string? CountryCode { get; set; }
  public int AreaCityCode { get; set; }
  public string? PhoneNumber { get; set; }
}