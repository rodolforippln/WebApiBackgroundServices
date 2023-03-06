using Microsoft.Extensions.Hosting;
using WebApiBackgroundServices.Repository;

namespace WebApiBackgroundServices.Services
{
    public class OrderWorker : IHostedService
    {
        private Timer? _timer = null;
        private ICommandRepository _commandRepository;

        public OrderWorker(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            //Console.WriteLine($"Iniciando Worker {nameof(OrderWorker)}");

            _timer = new Timer(DoWork, null, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1));
            
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Finalizando Worrker {nameof(OrderWorker)}");
            return Task.CompletedTask;
        }

        private void DoWork(object? state)
        {
            Console.WriteLine($"{DateTime.UtcNow:o} => {_commandRepository.GetMessage()}");            
        }
    }
}