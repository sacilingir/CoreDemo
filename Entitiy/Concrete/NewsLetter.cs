﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiy.Concrete
{
	public class NewsLetter
	{
        [Key]
        public int MailId { get; set; }
        public string Mail { get; set; }
        public bool MailStatus { get; set; }
    }
}
