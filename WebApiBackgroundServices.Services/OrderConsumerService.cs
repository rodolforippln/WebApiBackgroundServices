﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebApiBackgroundServices.Domain;
using WebApiBackgroundServices.Services.modelsResponseVTEX;

namespace WebApiBackgroundServices.Services;

public class OrderConsumerService
{
    private readonly HttpClient _httpClient;
    private OrderConsumerById _orderConsumerById;
    private readonly IConfiguration _configuration;
    public OrderConsumerService(HttpClient httpClient, OrderConsumerById orderConsumerById, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _orderConsumerById = orderConsumerById;
        _configuration = configuration;
    }

    public async Task<Order> GetListOdersVtex()
    {
        var uriBase = _configuration.GetSection("MySettings").GetSection("Parameters").GetSection("IsProduction").Value;
        Console.WriteLine(uriBase);
        Console.WriteLine("/////////////////////////////////////////");
        var url = "https://Vicenza.vtexcommercestable.com.br/api/oms/pvt/orders/?f_creationDate=creationDate:[2023-02-27T02:00:00.000Z TO 2023-03-01T01:59:59.999Z]";
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("X-VTEX-API-AppKey", "vtexappkey-vicenza-YTSYLU");
        request.Headers.Add("X-VTEX-API-AppToken", "HKBPBFDYYBEREGTMYBMWFYNXBFSUMQTXZWPMJAFPCALRYAXWIZNEJNKDZVXRCZSJHDYPHEOCLOLBPUUXJJGNFVOVCWHFZFZBZLZULHVUJCGYZGBZEZJXHTUQGMDQLSVI");
        request.Headers.Add("Accept", "application/json");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        var m = JsonConvert.DeserializeObject<Order>(result);

        Console.WriteLine();

        await _orderConsumerById.GetById(m.List[0].OrderId);
        

        return m;
    }
}
