using Application.File;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class FileController:ApiController
    {
        private IMediator _mediator;

        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create new Project
        /// </summary>
        /// <param name="command"> CreateProjectCommand </param>
        /// <returns>string</returns>
        [HttpPost]
        public async Task<ActionResult<File>> Create(AddFileCommand command)
        {
            var result = await this._mediator.Send(command);
            return result;
        }
    }
}
