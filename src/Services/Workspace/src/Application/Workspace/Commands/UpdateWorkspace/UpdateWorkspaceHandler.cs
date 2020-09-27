using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Workspace.Commands.UpdateWorkspace
{
    public class UpdateWorkspaceHandler : IRequestHandler<UpdateWorkspaceCommand,Core.Entities.Workspace>
    {
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateWorkspaceHandler(IWorkspaceRepository workspaceRepository,ICurrentUserService currentUserService)
        {
            _workspaceRepository = workspaceRepository;
            _currentUserService = currentUserService;
        }
        public async Task<Core.Entities.Workspace> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            if (request.Name.Equals(""))
            {
                throw new BusinessRuleException($"Name of workspace {request.Name} is empty,Or");
            }
            else if (!await _workspaceRepository.UniqueName(request.Name, cancellationToken))
            {
                throw new BusinessRuleException($"Name of workspace {request.Name} is already exist");
            }
            else
            {
                var isExsit = await this._workspaceRepository.GetAsync(request.WorkspaceId);
                if(isExsit != null) 
                {
                 var result = await this._workspaceRepository.UpdataAsync(request, _currentUserService, cancellationToken);
                    return result;
                }
                else 
                {
                    throw new BusinessRuleException($"The workspace id is doesn't exist in your database");
                }
                
            }
        }
    }
}
