using Application.Common.Interfaces;
using Application.Project.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProjectRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Project"></param>
        /// <returns></returns>
        Task<Guid> CreateAsync(CreateProjectCommand command,Core.Entities.Workspace workspace,ICurrentUserService currentUserService);
    }
}
