using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.File.Commands.UploadFile
{
    public class PostFileCommand:IRequest<Unit>
    {
        public List<IFormFile> Files { get; set; }

        public string Name { get; set; }
        public Guid FolderParentId { get; set; }
    }
}
