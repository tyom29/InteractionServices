using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InteractionService.Domain;
using InteractionService.Model;
using InteractionService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InteractionService.Controllers
{

    [ApiController]
    [Route("api/Email")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailInfoService _emailInfoService;
        public EmailController(IEmailInfoService emailInfoService)
        {
            _emailInfoService = emailInfoService;
        }

        [HttpPost]
        [Route("EmailSMS")]
        public string EmailSms(EmailInfoModel email)
        {
            var infoService = _emailInfoService.CreateEmailInfo(email);
            return infoService;
        }
    }
}