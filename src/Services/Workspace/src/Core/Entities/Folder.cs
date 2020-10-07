using Core.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Folder:Component
    {
        public Guid FolderId { get; set; }
        public Folder(string name) : base(name)
        {
            
        }
        public List<Component> components = new List<Component>();

        public virtual Project Project { get; set; }
    }
}
