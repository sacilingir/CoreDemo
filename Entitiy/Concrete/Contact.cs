﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactUserName { get; set; }
        public string CommentMail { get; set; }
        public string ContactSubject { get; set; }
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }


    }
}
