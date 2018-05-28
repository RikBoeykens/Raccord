using System.Threading.Tasks;

namespace Raccord.Application.Core.ExternalServices.Communication.Mail
{
  public interface ISendMailService
  {
      void SendMail(SendMailRequestDto request);
  }
}