using System;
using System.Net.Http;
using System.Threading.Tasks;
using Raccord.Application.Core.ExternalServices.Communication.Mail;
using Raccord.Core.Options;
using RestSharp;
using RestSharp.Authenticators;
using Microsoft.Extensions.Options;

namespace Raccord.Application.ExternalServices.Communication.Mail
{
  public class SendMailService : ISendMailService
  {
    private readonly MailSettings _mailSettings;
    
    public SendMailService(IOptions<MailSettings> mailSettings)
    {
      _mailSettings = mailSettings.Value;
    }

    public void SendMail(SendMailRequestDto requestDto)
    {
      RestClient client = new RestClient ();
      client.BaseUrl = new Uri (_mailSettings.Uri);
      client.Authenticator =
          new HttpBasicAuthenticator ("api",
                                      _mailSettings.ApiKey);
      RestRequest request = new RestRequest ();
      request.AddParameter ("domain", _mailSettings.Domain, ParameterType.UrlSegment);
      request.Resource = "{domain}/messages";
      request.AddParameter ("from", $"Excited User <mailgun@{_mailSettings.Domain}>");
      request.AddParameter ("to", _mailSettings.DefaultEmail);
      request.AddParameter ("subject", requestDto.Subject);
      request.AddParameter ("text", GetWrappedBody(requestDto.Body, requestDto.Recipient));
      request.Method = Method.POST;
      client.Execute (request);
    }

    private string GetWrappedBody(string body, string recipient)
    {
      return $"Email for {recipient}: {body}";
    }
  }
}