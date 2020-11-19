using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InteractionService.Domain
{
    public class EmailInfo
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="nvarchar(max)")]     
        [DataType(DataType.Text)]
        public string Body { get; set; }
        [Column(TypeName ="nvarchar(max)")]
        [DataType(DataType.Text)]
        public string StringBcc { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [DataType(DataType.Text)]
        public string StringCc { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [DataType(DataType.Text)]
        public string StringTo { get; set; }
        [Column(TypeName = "nvarchar(max)")]   
        [DataType(DataType.Text)]
        public string Subject { get; set; }

     
        [NotMapped]
        public List<string> ListBcc { get; set; }
       
        [NotMapped]
        public List<string> ListCc { get; set; }
        [NotMapped]
        public List<string> ListTo { get; set; }
        [NotMapped]
        public List<IFormFile> Attachement { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
