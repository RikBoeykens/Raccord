namespace Raccord.Application.Core.ExternalServices.Communication.Mail
{
  public class SendMailRequestDto
  {
    public string Recipient { get; set;}
    public string Subject { get; set; }
    public string Body { get; set;}
  }
}