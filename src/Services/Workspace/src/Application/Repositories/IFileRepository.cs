using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IFileRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command">CreateProjectCommand,Workspace,ICurrentUserService</param>
        /// <returns>Core.Entities.Folder</returns>
        Task<Core.Entities.File> AddAsync(Core.Commun.Component command, Core.Entities.Folder folderId);
    }
}
