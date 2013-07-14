using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Telelinkedin.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }

        public string FromUserName { get; set; }

        public bool Replied { get; set; }

        public int FromUserId { get; set; }
    }
}