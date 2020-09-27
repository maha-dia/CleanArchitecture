﻿using Application.Common.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Workspace.Queries.GetAllWorkspaces
{
    public class WorkspaceDto:IMapForm<Core.Entities.Workspace>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        //public string Image { get; set; }
        public string Owner { get; set; }
        public bool BookMark { get; set; }
        public bool IsPrivate { get; set; }


        public virtual ICollection<Core.Entities.Project> Projects { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Core.Entities.Workspace, WorkspaceDto>()
               ;
        }
    }
}
