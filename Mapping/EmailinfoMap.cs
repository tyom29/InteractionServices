using InteractionService.Domain;
using InteractionService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Mapping
{
    public class EmailinfoMap:AutoMapper.Profile
    {
        public EmailinfoMap()
        {
            CreateMap<EmailInfo, EmailInfoModel>();
            CreateMap<EmailInfoModel, EmailInfo>();
    
        }
    }
}
