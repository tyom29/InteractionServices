using InteractionService.Model;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using InteractionService.Repositories.MessageRequestRepositories;
using InteractionService.Domain;
using System.Text;
using System.Net.Http.Headers;
using System.IO;
using RestSharp;
using Newtonsoft.Json;

namespace InteractionService.Service.SMSService
{
    public class SmsService : ISmsService
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IMessageRequestRepository _messageRequest;
        public SmsService(Microsoft.Extensions.Configuration.IConfiguration configuration, IMapper mapper, IMessageRequestRepository messageRequest)
        {
            _config = configuration;
            _mapper = mapper;
            _messageRequest = messageRequest;
        }
        public string Send(MessageRequestModel requestModel)
        {
            if (!string.IsNullOrEmpty(requestModel.Messages[0].recipient))
            {
                requestModel.Messages[0].recipient = new string(requestModel.Messages[0].recipient.Where(c => char.IsDigit(c)).ToArray());
                requestModel.Messages[0].recipient = requestModel.Messages[0].recipient.Substring(requestModel.Messages[0].recipient.Length - 8, 8);
                requestModel.Messages[0].recipient = string.Format("374{0}", requestModel.Messages[0].recipient);
            }
            requestModel.Messages[0].messageId = DateTime.Now.ToString();
            string result = null;
            try
            {
                var authenticationString = $"{"trans"}:{"C464658dT"}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));
                var json = JsonConvert.SerializeObject(requestModel);
                string URI = _config.GetSection("ApiKeys:SMSURI").Value;
                var client = new RestClient($"{URI}/send");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Basic {base64EncodedAuthenticationString}");
                request.AddParameter("application/json", json, ParameterType.RequestBody);
              
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    result = "Success";
                   var a=_messageRequest.CreateMessageRequest(_mapper.Map<MessageRequest>(requestModel));
                }
                else
                {
                    result = "Failure";
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                result = "Failure";
            }
           
            return result;

        }
    }

}
