using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Message
    {
        public string line { get; set; }

        public Message(String m)
        {
            this.line = m;
        }
    }
}