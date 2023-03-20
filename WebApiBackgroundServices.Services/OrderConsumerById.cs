using Newtonsoft.Json;
using WebApiBackgroundServices.Services.modelsResponseVTEX;

namespace WebApiBackgroundServices.Services
{
  public class OrderConsumerById
  {
    private readonly HttpClient _httpClient;

    public OrderConsumerById(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<ResponseOrder> GetById(string id)
    {

      var url = $"https://Vicenza.vtexcommercestable.com.br/api/oms/pvt/orders/{id}";
      var request = new HttpRequestMessage(HttpMethod.Get, url);
      request.Headers.Add("X-VTEX-API-AppKey", "vtexappkey-vicenza-YTSYLU");
      request.Headers.Add("X-VTEX-API-AppToken", "HKBPBFDYYBEREGTMYBMWFYNXBFSUMQTXZWPMJAFPCALRYAXWIZNEJNKDZVXRCZSJHDYPHEOCLOLBPUUXJJGNFVOVCWHFZFZBZLZULHVUJCGYZGBZEZJXHTUQGMDQLSVI");
      request.Headers.Add("Accept", "application/json");
      //request.Headers.Add("Cookie", "janus_sid=d1d673ac-bb2a-4cb2-a37c-20b49b7e2787");

      var response = await _httpClient.SendAsync(request);
      response.EnsureSuccessStatusCode();
      var result = await response.Content.ReadAsStringAsync();

      var m = JsonConvert.DeserializeObject<ResponseOrder>(result);

      Console.WriteLine();
      Console.WriteLine("Fazendo fetching Order By Id na VTex:");
      Console.WriteLine("============================================");
      Console.WriteLine();
      Console.WriteLine($"UniqueId: {m.orderId}");

      if (m.items is not null)
      {


        foreach (var item in m.items)
        {
          if (item is not null) Console.WriteLine($"UniqueId: {item.uniqueId}");
          // if (item is not null) Console.WriteLine(item.ClientName);
          // if (item is not null) Console.WriteLine(item.Status);
          // if (item is not null) Console.WriteLine(item.StatusDescription);
          // if (item is not null) Console.WriteLine(item.Origin);
          // if (item is not null) Console.WriteLine(item.CurrencyCode);
          if (item is not null) Console.WriteLine();
        }
      }
      else
      {
        Console.WriteLine("Sem order no momento...");
      }

      return m;
    }
  }
}
