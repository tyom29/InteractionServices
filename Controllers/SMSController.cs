using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractionService.Model;
using InteractionService.Service.SMSService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InteractionService.Controllers
{
    [Route("api/SMS")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISmsService _smsService;
        public SMSController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost]
        [Route("send")]
        public string Send(MessageRequestModel request)
        {
            return _smsService.Send(request);
        }
    }
}
