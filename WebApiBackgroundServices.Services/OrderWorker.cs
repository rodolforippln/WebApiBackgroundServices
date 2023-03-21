using Microsoft.Extensions.Hosting;
using WebApiBackgroundServices.Repository;

namespace WebApiBackgroundServices.Services;

public class OrderWorker : IHostedService
{
    private Timer? _timer = null;
    private ICommandRepository _commandRepository;
    private OrderService _orderService;


    public OrderWorker(ICommandRepository commandRepository, OrderService orderService)
    {
        _commandRepository = commandRepository;       
        _orderService = orderService;
    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(180));

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Finalizando Worrker {nameof(OrderWorker)}");
        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        var m =_orderService.PorcessOrderVtex();
        //var n = _orderClient.GetById(m.List[0].OrderId);
        
    }
}