using Application.Project.Commands;
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
        /// <param name="command"> new </param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            var result = await this._mediator.Send(command);
            return Ok(result);
        }
    }
}
