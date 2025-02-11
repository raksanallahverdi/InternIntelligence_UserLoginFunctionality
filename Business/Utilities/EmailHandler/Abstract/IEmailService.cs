using Business.Utilities.EmailHandler.Models;

namespace Business.Utilities.EmailHandler.Abstract
{
    public interface IEmailService
    {
        public void SendMessage(Message message);
    }
}
