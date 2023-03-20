namespace WebApiBackgroundServices.Services.modelsResponseVTEX;

public class ShippingData
{
  public string? id { get; set; }
  public Address? address { get; set; }
  public List<LogisticsInfo>? logisticsInfo { get; set; }
  public List<SelectedAddress>? selectedAddresses { get; set; }
}