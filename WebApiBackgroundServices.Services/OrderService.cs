namespace WebApiBackgroundServices.Services;

public class OrderService
{
    private OrderClient _orderClient;
    
    public OrderService(OrderClient orderClient)
    {
        _orderClient = orderClient;
    }

    public async Task PorcessOrderVtex()
    {
        var result = await _orderClient.GetListOdersVtex();

        var m = await _orderClient.GetById(result.List[0].OrderId);

        Console.WriteLine();
        Console.WriteLine($"Loja dea venda: {m.marketplaceServicesEndpoint}");
    }
}

