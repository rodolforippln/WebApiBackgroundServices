using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApiBackgroundServices.Domain;
using WebApiBackgroundServices.Services.modelsResponseVTEX;

namespace WebApiBackgroundServices.Services;

public class OrderClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public OrderClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;        
        _configuration = configuration;
    }

    public async Task<Order> GetListOdersVtex()
    {
        var uriBase = _configuration.GetSection("MySettings").GetSection("Parameters").GetSection("IsProduction").Value;
        Console.WriteLine(uriBase);
        Console.WriteLine("/////////////////////////////////////////");
        var url = "https://Vicenza.vtexcommercestable.com.br/api/oms/pvt/orders/?f_creationDate=creationDate:[2023-02-27T02:00:00.000Z TO 2023-03-01T01:59:59.999Z]";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("X-VTEX-API-AppKey", "vtexappkey-vicenza-LWUNVW");
        request.Headers.Add("X-VTEX-API-AppToken", "EAHPSQYGDUVEQYJJKPNIQMYFHIMYRHMMAGBVLHJXRVHDJHQNLEUIAMVCQUWTYTJJIEEONVDJJOUDUJFYGQBXUDDDXBJIEEEKSIWZNMIECSOPJECDDNGIWCLWMELKVSWW");
        request.Headers.Add("Accept", "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        var m = JsonConvert.DeserializeObject<Order>(result);
        

        return m;
    }

    public async Task<ResponseOrder> GetById(string id)
    {
        var url = $"https://Vicenza.vtexcommercestable.com.br/api/oms/pvt/orders/{id}";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("X-VTEX-API-AppKey", "vtexappkey-vicenza-LWUNVW");
        request.Headers.Add("X-VTEX-API-AppToken", "EAHPSQYGDUVEQYJJKPNIQMYFHIMYRHMMAGBVLHJXRVHDJHQNLEUIAMVCQUWTYTJJIEEONVDJJOUDUJFYGQBXUDDDXBJIEEEKSIWZNMIECSOPJECDDNGIWCLWMELKVSWW");
        request.Headers.Add("Accept", "application/json");
       
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        var m = JsonConvert.DeserializeObject<ResponseOrder>(result);

        //Console.WriteLine();
        //Console.WriteLine("Fazendo fetching Order By Id na VTex:");
        //Console.WriteLine("============================================");
        //Console.WriteLine();
        //Console.WriteLine($"UniqueId: {m.orderId}");

        //if (m.items is not null)
        //{
        //    foreach (var item in m.items)
        //    {
        //        if (item is not null) Console.WriteLine($"UniqueId: {item.uniqueId}");

        //        if (item is not null) Console.WriteLine();
        //    }
        //}
        //else
        //{
        //    Console.WriteLine("Sem order no momento...");
        //}

        return m;
    }
}
