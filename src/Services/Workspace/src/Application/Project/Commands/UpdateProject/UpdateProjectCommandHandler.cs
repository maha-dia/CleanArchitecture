using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Project.Queries.GetProjectById;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Project.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IWorkspaceRepository _workspaceRepository;

        public  UpdateProjectCommandHandler(IProjectRepository projectRepository,IWorkspaceRepository workspaceRepository,ICurrentUserService currentUserService)
        {
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
            _workspaceRepository = workspaceRepository;
        }
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var getEntity = new GetProjectByIdQuery
            {
                Id = request.ProjectId,
            };
            var entity =await _projectRepository.GetAsync(getEntity);
            if (request.ProjectId != entity.ProjectId)
            {
                throw new BusinessRuleException("it doesn't exist");
            }
            if(request.ProjectId == Guid.Empty)
            {
                throw new BusinessRuleException("invalid parameter");
            }
            var exist = await _workspaceRepository.UniqueName(request.Label, cancellationToken);
            if(!exist)
            {
                throw new BusinessRuleException("is alredy exist");

            }
            await _projectRepository.UpdateAsync(request, _currentUserService);

            return Unit.Value;
        }
    }
}
