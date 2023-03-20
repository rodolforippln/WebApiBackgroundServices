namespace WebApiBackgroundServices.Services.modelsResponseVTEX;

public class ResponseOrder
{
  public string? orderId { get; set; }
  public string? marketplaceServicesEndpoint { get; set; }
  public string? origin { get; set; }
  public string? status { get; set; }
  public string? statusDescription { get; set; }
  public DateTime? creationDate { get; set; }
  public DateTime? lastChange { get; set; }
  public List<Item>? items { get; set; }
  public ClientProfileData? clientProfileData { get; set; }
  public ShippingData? shippingData { get; set; }
  public bool isCompleted { get; set; }
  public bool isCheckedIn { get; set; }
  public Marketplace? marketplace { get; set; }
}
