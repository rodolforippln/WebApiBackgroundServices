namespace WebApiBackgroundServices.Domain.models;

public class Receiver
{
  public string? Document { get; set; }
  public string? StateRegistration { get; set; }
  public string? Name { get; set; }
  public bool Payer { get; set; }
  public Telephone? Telephone { get; set; }
  public Address? Address { get; set; }
}