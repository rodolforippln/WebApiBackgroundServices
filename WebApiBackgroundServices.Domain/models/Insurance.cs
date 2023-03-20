namespace WebApiBackgroundServices.Domain.models;

public class Insurance
{
  public int Type { get; set; }
  public string? Company { get; set; }
  public string? PolicyNumber { get; set; }
}