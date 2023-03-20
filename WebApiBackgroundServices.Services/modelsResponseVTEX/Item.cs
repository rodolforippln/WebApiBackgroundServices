namespace WebApiBackgroundServices.Services.modelsResponseVTEX;

public class Item
{
  public string? uniqueId { get; set; }
  public string? id { get; set; }
  public string? productId { get; set; }
  public string? ean { get; set; }
  public string? lockId { get; set; }
  public string? name { get; set; }
  public int price { get; set; }
  public string? imageUrl { get; set; }
  public string? detailUrl { get; set; }
  public AdditionalInfo? additionalInfo { get; set; }
}