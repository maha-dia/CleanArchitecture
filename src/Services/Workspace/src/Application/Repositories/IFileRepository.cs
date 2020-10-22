using Application.File.Commands.UploadFile;
using MediatR;
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
        /// <param name="command,folderId">Component,Folder</param>
        /// <returns>Core.Entitiesfile</returns>
        Task<Core.Entities.File> AddAsync(Core.Commun.Component command, Core.Entities.Folder folderId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        Task<Unit> Post( PostFileCommand command);
    }
}
