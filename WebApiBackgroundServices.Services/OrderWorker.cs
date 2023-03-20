using Microsoft.Extensions.Hosting;
using WebApiBackgroundServices.Repository;

namespace WebApiBackgroundServices.Services;

public class OrderWorker : IHostedService
{
  private Timer? _timer = null;
  private ICommandRepository _commandRepository;
  private OrderConsumerService _consumerService;

  public OrderWorker(ICommandRepository commandRepository, OrderConsumerService consumerService)
  {
    _commandRepository = commandRepository;
    _consumerService = consumerService;
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
    var m = _consumerService.GetListOdersVtex();
  }

}