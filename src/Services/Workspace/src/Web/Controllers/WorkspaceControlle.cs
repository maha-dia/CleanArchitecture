﻿using Application.Workspace.Commands;
using Application.Workspace.Commands.DeleteWorkspace;
using Application.Workspace.Commands.UpdateWorkspace;
using Application.Workspace.Queries.GetAllWorkspaces;
using Application.Workspace.Queries.GetWorkspace;
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
        /// <param name="command"> new </param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateWorkspaceCommand command)
        {
            var result = await this._mediator.Send(command);
            return Ok(result);
        }


        /// <summary>
        /// Get an Workspace by Id
        /// </summary>
        /// <param name="requestId">  </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetWorkspaceByIdQuery requestId)
        {
            var result = await this._mediator.Send(requestId);
            return Ok(result);
        }

        /// <summary>
        /// Get all Workspaces 
        /// </summary>
        /// <param name="requestId">  </param>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<ActionResult<WorkspacesDTOLists>> GetAll()
        {
            var result = await this._mediator.Send(new GetAllWorkspaceQuery());
            return result;
        }

        /// <summary>
        /// Update Workspace
        /// </summary>
        /// <param name="command"> new </param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<IActionResult> Update(Guid id,UpdateWorkspaceCommand command)
        {
           if(id != command.WorkspaceId)
            {
                return BadRequest();
            }
            else { 
            await this._mediator.Send(command);
            return NoContent();
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