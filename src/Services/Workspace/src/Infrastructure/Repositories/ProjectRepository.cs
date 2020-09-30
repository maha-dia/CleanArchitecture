using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Project.Commands;
using Application.Project.Commands.DeleteProject;
using Application.Project.Commands.UpdateProject;
using Application.Project.Queries.GetProjectById;
using Application.Repositories;
using Core.Entities;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository

    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ICurrentUserService currentUserService,
            ApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _context = context;

        }
        public async Task<Guid> CreateAsync(CreateProjectCommand command,Workspace workspace, ICurrentUserService _currentUserService)
        {
            var project = new Project
            {
                ProjectId = new Guid(),
                Label = command.Label,
                Description = command.Description,
                CreatedBy = _currentUserService.UserId,
                Workspace = workspace,   
            };

            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
            return project.ProjectId;

        }

        public async Task<DeleteProjectDto> DeleteAsync(DeleteProjectCommand query, ICurrentUserService currentUserService, CancellationToken cancellationToken)
        {
            var project =  await _context.projects
                .Where(e => e.ProjectId == query.ProjectId)
                .SingleOrDefaultAsync(cancellationToken)
                ;
             _context.projects.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);
            var result = new DeleteProjectDto
            {
                DeletedAt = project.DeletedAt,
                DeletedBy = currentUserService.UserId,
                Label = project.Label,
                ProjectId = project.ProjectId

            };
            return result ;

        }

        public async Task<Project> GetAsync(GetProjectByIdQuery query)
        {
            var project = await _context.projects.Where(w => w.ProjectId == query.Id).SingleOrDefaultAsync();
            if(project == null)
            {
                throw new NotFoundException(nameof(Project), query.Id);
            }
            return project;
        }

        

        public async Task<Unit> UpdateAsync(UpdateProjectCommand query, ICurrentUserService currentUserService)
        {
            var queryUpdate = new GetProjectByIdQuery { Id = query.ProjectId };
            var project = await GetAsync(queryUpdate);
            if ( project== null)
            {
                throw new NotFoundException(nameof(Project), query.ProjectId);
            }
            project.Label = query.Label;
            project.Description = query.Description;
            project.Icon = query.Icon;
            project.LastModifiedBy = currentUserService.UserId;

            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
