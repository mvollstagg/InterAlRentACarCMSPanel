using System.Threading.Tasks;

namespace Utilities.Services
{
    public interface IEmailSender
    {
        public Task SendMessage(string messageSubject, string messageBody, string toMailAddress);
    }
}
