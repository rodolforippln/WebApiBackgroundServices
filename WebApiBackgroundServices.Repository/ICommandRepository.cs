using WebApiBackgroundServices.Domain;

namespace WebApiBackgroundServices.Repository
{
    public interface ICommandRepository
    {
        public string GetMessage();
        public void SetMessage(Message message);        
    }
}
