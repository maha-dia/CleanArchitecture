using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Workspace.Commands.CreateWorkspace
{
    public class CreateWorkspaceHandler : IRequestHandler<CreateWorkspaceCommand , Guid>
    {
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateWorkspaceHandler(IWorkspaceRepository workspaceRepository,ICurrentUserService currentUserService)
        {
            this._workspaceRepository = workspaceRepository;
            this._currentUserService = currentUserService;
        }
        public async Task<Guid> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            // Check business rules
            // R01 Asset label is requared
            if (request.Name.Equals(""))
            {
                throw new BusinessRuleException($"Name of workspace {request.Name} is empty");
            }
            // R02 Asset label is unique
            else if (!await _workspaceRepository.UniqueName(request.Name, cancellationToken))
            {
                throw new BusinessRuleException($"Name of workspace {request.Name} is already exist");
            }
            else
            {
                var workspaceId = await this._workspaceRepository.CreateAsync(request, _currentUserService);
                return workspaceId;
            }
        }
    }
}
