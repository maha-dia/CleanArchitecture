using Core.Commun;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{

    public class Project : AuditableEntity
    {
        public Guid ProjectId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }

        //cle 
        //Model
        public virtual Workspace Workspace { get; set; }

    }
}
