using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Core.Entities
{
    public class Member
    {
       
        public Guid MemberID { get; set; }
       
        public ICollection<ProjectsMembers> ProjectsMembers { get; set; }

    }
}
