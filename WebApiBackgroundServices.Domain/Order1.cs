using Newtonsoft.Json;

namespace WebApiBackgroundServices.Domain;

public partial class Order1
{
  public List<List>? List1 { get; set; }
}

public partial class List1
{
  [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
  public string? OrderId { get; set; }

  [JsonProperty("clientName", NullValueHandling = NullValueHandling.Ignore)]
  public string? ClientName { get; set; }

  [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
  public string? Status { get; set; }

  [JsonProperty("statusDescription", NullValueHandling = NullValueHandling.Ignore)]
  public string? StatusDescription { get; set; }

  [JsonProperty("origin", NullValueHandling = NullValueHandling.Ignore)]
  public string? Origin { get; set; }

  [JsonProperty("currencyCode", NullValueHandling = NullValueHandling.Ignore)]
  public string? CurrencyCode { get; set; }
}

