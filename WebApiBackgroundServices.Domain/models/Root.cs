// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
namespace WebApiBackgroundServices.Domain.models;

public class Root
{
  public string? OriginPointCode { get; set; }
  public string? OriginPartnerPointCode { get; set; }
  public string? OriginPostalCode { get; set; }
  public bool ToCollect { get; set; }
  public string? DestinationPointCode { get; set; }
  public string? DestinationPostalCode { get; set; }
  public bool ToDelivery { get; set; }
  public string? ServiceCode { get; set; }
  public Insurance? Insurance { get; set; }
  public double DeclaredValue { get; set; }
  public string? previousDocuments { get; set; }
  public Sender? Sender { get; set; }
  public Receiver? Receiver { get; set; }
  public List<Volume>? Volumes { get; set; }
  public bool generateDocumentNumber { get; set; }
  public int paymentMethod { get; set; }
}






