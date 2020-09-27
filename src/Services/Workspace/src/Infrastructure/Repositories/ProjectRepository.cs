using Application.Common.Interfaces;
using Application.Project.Commands;
using Application.Repositories;
using Core.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
