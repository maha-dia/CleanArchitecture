using Application.Workspace.Commands;
using Application.Workspace.Commands.DeleteWorkspace;
using Application.Workspace.Commands.UpdateWorkspace;
using Application.Workspace.Queries.GetAllWorkspaces;
using Application.Workspace.Queries.GetWorkspace;
using Application.Workspace.Queries.GetWorkspaceByKeyWord;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Web.Controllers
{
    public class WorkspaceControlle : ApiController
    {
        private readonly IMediator _mediator;

        public WorkspaceControlle(IMediator meditor)
        {
            this._mediator = meditor;
        }
        /// <summary>
        /// Create new Workspace
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateWorkspaceCommand command)
        {
            var result = await this._mediator.Send(command);
            return result;
        }


        /// <summary>
        /// Get Workspace by Id
        /// </summary>
        /// <param name="requestId">GetWorkspaceByIdQuery</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<Core.Entities.Workspace>> Get([FromQuery] GetWorkspaceByIdQuery requestId)
        {
            var result = await this._mediator.Send(requestId);
            return result;
        }

        /// <summary>
        /// Get all Workspaces 
        /// </summary>
        /// <param name="query">GetAllWorkspaceQuery</param>
        /// <returns>WorkspacesDTOLists</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<WorkspacesDTOLists>> GetAll([FromQuery] GetAllWorkspaceQuery query)
        {
            var result = await this._mediator.Send(query);
            return result;
        }

        /// <summary>
        /// Get Workspaces By Key word 
        /// </summary>
        /// <param name="query">GetAllWorkspaceQuery</param>
        /// <returns>WorkspacesDTOLists</returns>
        [HttpGet("search")]
        public async Task<ActionResult<WorkspaceDtoLists>> GetByKeyWord([FromQuery] GetWorkspaceByKeyWord query)
        {
            var result = await this._mediator.Send(query);
            return result;
        }

        /// <summary>
        /// Update Workspace
        /// </summary>
        /// <param name="command"> new </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Core.Entities.Workspace>> Update(UpdateWorkspaceCommand command)
        {
           if(command.WorkspaceId != command.WorkspaceId)
            {
                return BadRequest();
            }
            else { 
            var result =await this._mediator.Send(command);
                return result;
            }
        }

        /// <summary>
        /// Delete Workspace
        /// </summary>
        /// <param name="command"> Delete </param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult<DeleteWorkspaceReturnDto>> Delete(Guid id)
        {
             var result = await this._mediator.Send(new DeleteWorkspaceCommad { WorkspaceId = id });
            return result;
        }

    }
}
