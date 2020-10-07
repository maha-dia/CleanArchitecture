using Application.Folder.Commands;
using Application.Folder.Commands.DeleteFolder;
using Application.Folder.Commands.UpdateFolder;
using Application.Folder.Queries;
using Application.Folder.Queries.GetAllFolder;
using Application.Workspace.Queries.GetAllWorkspaces;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class FolderControllers:ApiController
    {
        private IMediator _mediator;

        public FolderControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create new Project
        /// </summary>
        /// <param name="command"> CreateProjectCommand </param>
        /// <returns>string</returns>
        [HttpPost]
        public async Task<ActionResult<Folder>> Create(AddFolderCommand command)
        {
            var result = await this._mediator.Send(command);
            return result;
        }
        /// <summary>
        /// Get Project
        /// </summary>
        /// <param name="query"> GetProjectByIdQuery</param>
        /// <returns>Project</returns>
        [HttpGet]
        public async Task<ActionResult<Core.Entities.Folder>> Get([FromQuery] GetFolderQuery query)
        {
            var result = await this._mediator.Send(query);
            return result;
        }

        /// <summary>
        /// Get all Folders
        /// </summary>
        /// <param name="query">GetAllFoldersQuery</param>
        /// <returns>GetFoldersDtoLists</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<GetFoldersDtoLists>> GetAll([FromQuery] GetAllFoldersQuery query)
        {
            var result = await this._mediator.Send(query);
            return result;
        }

        /// <summary>Rename Folder
        /// </summary>
        /// <param name="command"> </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<string>> Update(RenameFolderCommand command)
        {
            var result = await this._mediator.Send(command);
            return result;
        }

        /// <summary>
        /// Delete Folder
        /// </summary>
        /// <param name="command"> Delete </param>
        /// <returns>DeleteFolderDto</returns>
        [HttpDelete]
        public async Task<ActionResult<DeleteFolderDto>> Delete(DeleteFolderCommand command)
        {
            var result = await this._mediator.Send(command);
            return result;
        }

    }
}
