using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Model
{
    public class EmailInfoModel
    {
        
        [Required(ErrorMessage = "This field is required.")]
        public string Body { get; set; }
      
        public List<string> Bcc { get; set; }
       
        public List<string> Cc { get; set; }
      
        public List<string> To { get; set; }


        [Required(ErrorMessage = "This field is required.")]
     
        public string Subject { get; set; }
   
        
        public List<IFormFile> Attachement { get; set; }

        [Required]
        public string Username { get; set; }

        public string StringBcc { get; set; }
        public string StringCc { get; set; }
        public string StringTo { get; set; }
    }
}
