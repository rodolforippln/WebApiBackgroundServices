using Newtonsoft.Json;
using WebApiBackgroundServices.Domain;

namespace WebApiBackgroundServices.Services
{
  public class OrderConsumerService
  {
    private readonly HttpClient _httpClient;
    private OrderConsumerById _orderConsumerById;
    public OrderConsumerService(HttpClient httpClient, OrderConsumerById orderConsumerById)
    {
      _httpClient = httpClient;
      _orderConsumerById = orderConsumerById;
    }

    public async Task<Order> GetListOdersVtex()
    {
      var url = "https://Vicenza.vtexcommercestable.com.br/api/oms/pvt/orders/?f_creationDate=creationDate:[2023-02-27T02:00:00.000Z TO 2023-03-01T01:59:59.999Z]";
      var request = new HttpRequestMessage(HttpMethod.Get, url);
      request.Headers.Add("X-VTEX-API-AppKey", "vtexappkey-vicenza-YTSYLU");
      request.Headers.Add("X-VTEX-API-AppToken", "HKBPBFDYYBEREGTMYBMWFYNXBFSUMQTXZWPMJAFPCALRYAXWIZNEJNKDZVXRCZSJHDYPHEOCLOLBPUUXJJGNFVOVCWHFZFZBZLZULHVUJCGYZGBZEZJXHTUQGMDQLSVI");
      request.Headers.Add("Accept", "application/json");

      var response = await _httpClient.SendAsync(request);
      response.EnsureSuccessStatusCode();
      var result = await response.Content.ReadAsStringAsync();

      var m = JsonConvert.DeserializeObject<Order>(result);

      //Console.WriteLine();
      //Console.WriteLine("Fazendo fetching na lista de pedido na VTex:");
      //Console.WriteLine("============================================");


      Console.WriteLine();
      //Console.WriteLine(m.List[0].OrderId);

      await _orderConsumerById.GetById(m.List[0].OrderId);



      // if (m.List is not null)
      // {
      //   Console.WriteLine();
      //   Console.WriteLine(m.List[0].OrderId);
      //   foreach (var item in m.List)
      //   {
      //     await _orderConsumerById.GetById(item.OrderId);
      //     if (item is not null) Console.WriteLine();
      //   }
      // }
      // else
      // {
      //   Console.WriteLine("Sem order no momento...");
      // }

      return m;
    }
  }
}
