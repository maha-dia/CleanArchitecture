using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ProjectsMembers
    {
            public Guid Id { get; set; }
            public Guid MemberID { get; set; }
            public virtual Member Member { get; set; }
            public Guid ProjectId { get; set; }
            public virtual Project Project { get; set; }
        
    }
}
