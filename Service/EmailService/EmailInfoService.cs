using AutoMapper;
using AutoMapper.Configuration;
using InteractionService.Domain;
using InteractionService.Model;
using InteractionService.Repositories;
using InteractionService.Repositories.EmailInfoRepositories;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace InteractionService.Service
{
    public   class EmailInfoService : IEmailInfoService
    {
        private readonly IMapper _mapper;
        private readonly IEmailInfoRepository _emailInfoRepositories;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public EmailInfoService(IEmailInfoRepository emailInfoRepositories,IMapper mapper, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _emailInfoRepositories = emailInfoRepositories;
            _config = configuration;
            _mapper = mapper;
        }    
        public   string CreateEmailInfo(EmailInfoModel email)
        {

            if (_config.GetSection("ApiKeys:EmailType").Value == "true")
            {
               
                try
                {

                    var basicCredintial = new NetworkCredential(_config.GetSection("ApiKeys:EmailUsername").Value, _config.GetSection("ApiKeys:EmailPassword").Value, "finca.am");
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Credentials = basicCredintial;
                    smtpClient.Port = Convert.ToInt32(_config.GetSection("ApiKeys:Port").Value);
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Host = _config.GetSection("ApiKeys:Host").Value;
                    //smtpClient.EnableSsl = true;
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    using (MailMessage message = new MailMessage())
                    {


                        message.IsBodyHtml = true;
                        if (email.Username == "AFD")
                        {
                            message.From = new MailAddress(_config.GetSection("ApiKeys:EmailAFDUsername").Value, _config.GetSection("ApiKeys:FromDisplayName").Value, Encoding.UTF8);
                            foreach(string to in email.To)
                            {
                                MailMessage mailMessage = new MailMessage(_config.GetSection("ApiKeys:EmailAFDUsername").Value, to);
                            }
                        }
                        else if (email.Username == "LOA")
                        {
                            message.From = new MailAddress(_config.GetSection("ApiKeys:EmailLOAUsername").Value, _config.GetSection("ApiKeys:FromDisplayName").Value, Encoding.UTF8);
                            foreach (string to in email.To)
                            {
                                MailMessage mailMessage = new MailMessage(_config.GetSection("ApiKeys:EmailLOAUsername").Value, to);
                            }
                        }
                        else if (email.Username == "MPB")
                        {
                            message.From = new MailAddress(_config.GetSection("ApiKeys:EmailMPBUsername").Value, _config.GetSection("ApiKeys:FromDisplayName").Value, Encoding.UTF8);
                            foreach (string to in email.To)
                            {
                                MailMessage mailMessage = new MailMessage(_config.GetSection("ApiKeys:EmailMPBUsername").Value, to);
                            }
                        }
                        else if (email.Username == "PLM")
                        {
                            message.From = new MailAddress(_config.GetSection("ApiKeys:EmailPLMUsername").Value, _config.GetSection("ApiKeys:FromDisplayName").Value, Encoding.UTF8);
                            foreach (string to in email.To)
                            {
                                MailMessage mailMessage = new MailMessage(_config.GetSection("ApiKeys:EmailLOOOLUsername").Value, to);
                            }
                        }
                        message.Subject = email.Subject;
                        message.Body = email.Body;
                        if (email.Bcc != null)
                        {
                            foreach (string addresses in email.Bcc)
                            {
                                message.Bcc.Add(addresses);
                            }
                        }
                        if (email.Cc != null)
                        {
                            foreach (string addresses in email.Cc)
                                message.CC.Add(addresses);
                        }
                        if (email.To != null)
                        {
                            foreach (string addresses in email.To)
                                message.To.Add(addresses);
                        }
                        
                         smtpClient.Send(message);
                        
                         _emailInfoRepositories.CreateEmailInfo(_mapper.Map<EmailInfo>(email));
                        return   "OK";
                    }

                }
                catch (Exception ex)
                {
                    
                    return "Exception" + ex;
                }
            }
            // Exchange
            else
            {
              
                try
                {
                    ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
                    service.Credentials = (ExchangeCredentials)new NetworkCredential(_config.GetSection("ApiKeys:EmailUsername").Value, _config.GetSection("ApiKeys:EmailPassword").Value);
                    service.Url = new Uri(_config.GetSection("ApiKeys:EWSUri").Value);
                    EmailMessage emailMessage = new EmailMessage(service);

                    if (email.Username == "OLLLL")
                    {
                        emailMessage.From = (EmailAddress)_config.GetSection("ApiKeys:EmailDFAUsername").Value;

                        foreach (string to in email.To)
                        {

                            emailMessage.ToRecipients.Add(to);
                        }
                    }

                    else if (email.Username == "LOL")
                    {

                        emailMessage.From = (EmailAddress)_config.GetSection("ApiKeys:EmailOlaUsername").Value;
                        foreach (string to in email.To)
                        {
                            emailMessage.ToRecipients.Add(to);
                        }
                    }
                    else if (email.Username == "TMS")
                    {

                        emailMessage.From = (EmailAddress)_config.GetSection("ApiKeys:EmailBPMUsername").Value;
                        foreach (string to in email.To)
                        {

                            emailMessage.ToRecipients.Add(to);
                        }
                    }
                    else if (email.Username == "MIS")
                    {

                        emailMessage.From = (EmailAddress)_config.GetSection("ApiKeys:EmailPLMDUsername").Value;
                        foreach (string to in email.To)
                        {
                            emailMessage.ToRecipients.Add(to);
                        }
                    }
                    emailMessage.Subject = email.Subject;
                    emailMessage.Body = (MessageBody)email.Body;

                    if (email.Bcc != null)
                    {
                        foreach (string smtpAddress in email.Bcc)
                            emailMessage.BccRecipients.Add(smtpAddress);
                    }
                    if (email.Cc != null)
                    {
                        foreach (string smtpAddress in email.Cc)
                            emailMessage.CcRecipients.Add(smtpAddress);
                    }
                    
                    emailMessage.Send();

                    if (email.Cc != null)
                    {
                        email.StringCc = string.Join(",", email.Cc);
                    }
                    if (email.Bcc != null)
                    {
                        email.StringBcc = string.Join(",", email.Bcc);
                    }
                    if (email.To != null)
                    {
                        email.StringTo = string.Join(",", email.To);
                    }

                    _emailInfoRepositories.CreateEmailInfo(_mapper.Map<EmailInfo>(email));


                    return "OK";
                }
                catch (Exception ex)
                {
                    
                    return "Exception" + ex;
                }
            }
          
        }
    }
}
