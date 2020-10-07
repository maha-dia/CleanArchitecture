using Core.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class File:Component
    {
        public Guid FileId { get; set; }
        public File(string name):base(name)
        {
            
        }
    }
}
