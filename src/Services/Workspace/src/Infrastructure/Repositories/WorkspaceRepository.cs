using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Repositories;
using Application.Workspace.Commands;
using Application.Workspace.Commands.DeleteWorkspace;
using Application.Workspace.Commands.UpdateWorkspace;
using Application.Workspace.Queries.GetAllWorkspaces;
using Application.Workspace.Queries.GetWorkspace;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class WorkspaceRepository : IWorkspaceRepository
    {
        private readonly ApplicationDbContext _context;
        
        private readonly IMapper _mapper;

        public WorkspaceRepository(ApplicationDbContext context,IMapper mapper)
        {
            this._context = context;
            
            this._mapper = mapper;
        }
        public async Task<Guid> CreateAsync(CreateWorkspaceCommand workspace, ICurrentUserService currentUserService)
        {
            var NewWorkspace = new Workspace
            {
                Id = new Guid(),
                Name = workspace.Name,
                Description = workspace.Description,
                Image = workspace.Image,
                BookMark = false,
                IsPrivate = true,
                //add member to owner !!! TODO
                Owner = currentUserService.UserId,
                CreatedBy = currentUserService.UserId,
            };
            await this._context.Workspaces.AddAsync(NewWorkspace);
            await this._context.SaveChangesAsync();
            return NewWorkspace.Id;

            
        }

        public async Task<DeleteWorkspaceReturnDto> DeleteAsync(Guid workspaceId, ICurrentUserService currentUserService, CancellationToken cancellationToken)
        {
            var entity = await _context.Workspaces
                .Where(e => e.Id == workspaceId)
                .SingleOrDefaultAsync(cancellationToken)
                ;

            if(entity == null)
            {
                throw new NotFoundException(nameof(Workspace), workspaceId);
            }
             _context.Workspaces.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            var result = new DeleteWorkspaceReturnDto
            {
                Name = entity.Name,
                Description = entity.Description,
                DeletedBy = currentUserService.UserId,
                Projects = entity.Projects,
                DeletedAt = entity.DeletedAt
            };
            return result;
        }

        public async Task<WorkspacesDTOLists> GetAllAsync(GetAllWorkspaceQuery request, CancellationToken cancellationToken)
        {
            
            return new WorkspacesDTOLists
            {
                WorkspacesLists = await _context.Workspaces.ProjectTo<WorkspaceDto>(_mapper.ConfigurationProvider)
                .OrderBy(n => n.Created).ToListAsync(cancellationToken)
            };
        
        }

        public async Task<Workspace> GetAsync(Guid workspaceId)
        {
            var query = _context.Workspaces.Where(w => w.Id == workspaceId).Include(w=> w.Projects);
            var Workspace = await query.FirstOrDefaultAsync();
                
            return Workspace;

        }

        public async Task<bool> UniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Workspaces
                .AllAsync(n => n.Name != name);
        }

        public async Task<Core.Entities.Workspace> UpdataAsync(UpdateWorkspaceCommand workspace, ICurrentUserService currentUser, CancellationToken cancellationToken)
        {
            var workspaceData =await GetAsync(workspace.WorkspaceId);
            if (workspaceData != null)
            {
                workspaceData.Name = workspace.Name;
                workspaceData.Description = workspace.Description;
                workspaceData.Image = workspace.Image;
                workspaceData.BookMark = workspace.BookMark;
                workspaceData.IsPrivate = workspace.IsPrivate;
                workspaceData.CreatedBy = currentUser.UserId;
            
            await this._context.SaveChangesAsync(cancellationToken);

            }
            return workspaceData;

        }
    }
}
