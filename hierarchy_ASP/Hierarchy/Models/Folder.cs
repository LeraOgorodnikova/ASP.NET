using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hierarchy.Models
{
    public class Folder
    {
        public String name { get; set; }
        public DateTime date { get; set; }
        public int child_objects { get; set; }
        public List<File> files { get; set; }
        public List<Folder> subFolder { get; set; }
        public Folder(String Newname, DateTime newDate, int newChild_objects,List<File> newFiles,List<Folder> sub)
        {
            this.name = Newname;
            this.date = newDate;
            this.child_objects = newChild_objects;
            this.files = newFiles;
            this.subFolder = sub;
        }
        public Folder()
        {
        }
    }
}