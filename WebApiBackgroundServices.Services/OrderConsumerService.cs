using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApiBackgroundServices.Domain;

namespace WebApiBackgroundServices.Services
{
    public class OrderConsumerService
    {
        private readonly HttpClient _httpClient;

        public OrderConsumerService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        public async Task<Order> GetListOdersVtex()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://Vicenza.vtexcommercestable.com.br/api/oms/pvt/orders/?f_creationDate=creationDate:[2023-02-27T02:00:00.000Z TO 2023-03-01T01:59:59.999Z]");
            request.Headers.Add("X-VTEX-API-AppKey", "vtexappkey-vicenza-YTSYLU");
            request.Headers.Add("X-VTEX-API-AppToken", "HKBPBFDYYBEREGTMYBMWFYNXBFSUMQTXZWPMJAFPCALRYAXWIZNEJNKDZVXRCZSJHDYPHEOCLOLBPUUXJJGNFVOVCWHFZFZBZLZULHVUJCGYZGBZEZJXHTUQGMDQLSVI");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Cookie", "janus_sid=d1d673ac-bb2a-4cb2-a37c-20b49b7e2787");

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            var m = JsonConvert.DeserializeObject<Order>(result);
            
            Console.WriteLine();
            Console.WriteLine("Fazendo fetching na lista de pedido na VTex:");
            Console.WriteLine("============================================");

            if (m.List is not null)
            {
                Console.WriteLine();
                foreach (var item in m.List)
                {
                    if (item is not null) Console.WriteLine(item.OrderId);
                    if (item is not null) Console.WriteLine(item.ClientName);
                    if (item is not null) Console.WriteLine(item.Status);
                    if (item is not null) Console.WriteLine(item.StatusDescription);
                    if (item is not null) Console.WriteLine(item.Origin);
                    if (item is not null) Console.WriteLine(item.CurrencyCode);
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
