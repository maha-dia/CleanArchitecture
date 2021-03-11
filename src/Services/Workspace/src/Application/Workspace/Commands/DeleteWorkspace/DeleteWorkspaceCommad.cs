﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Workspace.Commands.DeleteWorkspace
{
    public class DeleteWorkspaceCommad:IRequest<DeleteWorkspaceReturnDto>
    {
        public Guid WorkspaceId { get; set; }
    }
}
