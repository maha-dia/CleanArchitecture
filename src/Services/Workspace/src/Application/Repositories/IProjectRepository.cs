using Application.Common.Interfaces;
using Application.Project.Commands;
using Application.Project.Commands.DeleteProject;
using Application.Project.Commands.UpdateProject;
using Application.Project.Queries.GetProjectById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProjectRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command,workspace,currentUserService">CreateProjectCommand,Workspace,ICurrentUserService</param>
        /// <returns></returns>
        Task<string> CreateAsync(CreateProjectCommand command,Core.Entities.Workspace workspace,ICurrentUserService currentUserService);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        Task<Core.Entities.Project> GetAsync(GetProjectByIdQuery query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        Task<Unit> UpdateAsync(UpdateProjectCommand query,ICurrentUserService currentUserService);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        Task<DeleteProjectDto> DeleteAsync(DeleteProjectCommand query, ICurrentUserService currentUserService, CancellationToken cancellationToken);
    }
}
