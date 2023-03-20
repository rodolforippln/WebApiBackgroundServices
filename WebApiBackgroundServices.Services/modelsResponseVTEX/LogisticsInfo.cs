namespace WebApiBackgroundServices.Services.modelsResponseVTEX;

public class LogisticsInfo
{
  public int itemIndex { get; set; }
  public string? selectedSla { get; set; }
  public string? lockTTL { get; set; }
  public int price { get; set; }
  public int listPrice { get; set; }
  public int sellingPrice { get; set; }
  public string? deliveryWindow { get; set; }
  public string? deliveryCompany { get; set; }
  public string? shippingEstimate { get; set; }
  public DateTime shippingEstimateDate { get; set; }
}