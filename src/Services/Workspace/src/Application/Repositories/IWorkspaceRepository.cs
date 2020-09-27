using Application.Common.Interfaces;
using Application.Workspace.Commands;
using Application.Workspace.Commands.DeleteWorkspace;
using Application.Workspace.Commands.UpdateWorkspace;
using Application.Workspace.Queries.GetAllWorkspaces;
using Application.Workspace.Queries.GetWorkspace;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IWorkspaceRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<Guid> CreateAsync(CreateWorkspaceCommand workspace, ICurrentUserService currentUser);
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<Core.Entities.Workspace> GetAsync(Guid workspaceId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<Boolean> UniqueName(string name, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<WorkspacesDTOLists> GetAllAsync(GetAllWorkspaceQuery request, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<Core.Entities.Workspace> UpdataAsync(UpdateWorkspaceCommand workspace, ICurrentUserService currentUser, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        Task<DeleteWorkspaceReturnDto> DeleteAsync(Guid workspaceId, ICurrentUserService currentUserService, CancellationToken cancellationToken);
    }
}
