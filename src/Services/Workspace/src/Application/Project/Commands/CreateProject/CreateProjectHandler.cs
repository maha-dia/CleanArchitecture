using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Project.Commands
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IWorkspaceRepository _workspaceRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly ICurrentUserService _currentUserService;
        

        public CreateProjectHandler(IWorkspaceRepository workspaceRepository,
                                    IProjectRepository projectRepository,
                                    ICurrentUserService currentUserService)
        {
            _workspaceRepository = workspaceRepository;
            _projectRepository = projectRepository;
            _currentUserService = currentUserService;
        }
        public async Task<Guid> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
        {

            //var workspaceExiste = await _workspaceRepository.GetAsync(command);
            //if (workspaceExiste == null)
            //{
            //    throw new BusinessRuleException("Workspace is doesn't exist");
            //}
            //else
            //{
            //    var project = await _projectRepository.CreateAsync(command, workspaceExiste, _currentUserService);
            //    return project;
            //}
            return Guid.NewGuid();
        }
    }
}
