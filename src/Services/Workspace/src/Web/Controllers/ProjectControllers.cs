﻿using Application.Project.Commands;
using Application.Project.Commands.DeleteProject;
using Application.Project.Commands.UpdateProject;
using Application.Project.Queries.GetProjectById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ProjectControllers:ApiController
    {
        private IMediator _mediator;

        public ProjectControllers(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create new Project
        /// </summary>
        /// <param name="command"> CreateProjectCommand </param>
        /// <returns>string</returns>
        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateProjectCommand command)
        {
            var result = await this._mediator.Send(command);
            return result;
        }

        /// <summary>
        /// Get Project
        /// </summary>
        /// <param name="command"> </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Core.Entities.Project>> GetById([FromQuery] GetProjectByIdQuery query)
        {
            var result = await this._mediator.Send(query);
            return result;
        }
        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="command"> </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdateProjectCommand command)
        {
             await this._mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Delete Workspace
        /// </summary>
        /// <param name="command"> Delete </param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<DeleteProjectDto>> Delete(DeleteProjectCommand command)
        {
            var result = await this._mediator.Send(command);
            return result;
        }
    }
}
