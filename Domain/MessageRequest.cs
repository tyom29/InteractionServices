using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Domain
{
    public class MessageRequest
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DataType(DataType.Text)]
        public string Recipient { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DataType(DataType.Text)]
        public string MessageId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DataType(DataType.Text)]
        public string Originator { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DataType(DataType.Text)]
        public string Content { get; set; }

    }
}
