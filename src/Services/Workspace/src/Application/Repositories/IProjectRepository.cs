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
        /// <returns>string</returns>
        Task<string> CreateAsync(CreateProjectCommand command,Core.Entities.Workspace workspace,ICurrentUserService currentUserService);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query">GetProjectByIdQuery</param>
        /// <returns>Project Or TODO Dto</returns>
        Task<Core.Entities.Project> GetAsync(GetProjectByIdQuery query);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query,currentUserService,project">UpdateProjectCommand,ICurrentUserService,Project</param>
        /// <returns>Unit</returns>
        Task<Unit> UpdateAsync(UpdateProjectCommand query,Core.Entities.Project project,ICurrentUserService currentUserService);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query,currentUserService">DeleteProjectCommand, ICurrentUserService</param>
        /// <returns>DeleteProjectDto</returns>
        Task<DeleteProjectDto> DeleteAsync(DeleteProjectCommand query, ICurrentUserService currentUserService);
    }
}
