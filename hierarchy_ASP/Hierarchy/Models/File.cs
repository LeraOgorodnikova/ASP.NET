using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hierarchy.Models
{
    public class File
    {
        public String name { get; set; }
        public DateTime date { get; set; }
        public int size { get; set; }

        public File(String Newname, DateTime newDate, int newSize)
        {
            this.name = Newname;
            this.date = newDate;
            this.size = newSize;
        }
    }
}