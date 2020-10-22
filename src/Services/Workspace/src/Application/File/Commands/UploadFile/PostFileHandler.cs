using Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.File.Commands.UploadFile
{
    public class PostFileHandler : IRequestHandler<PostFileCommand, Unit>
    {
        private readonly IFileRepository _fileRepository;

        public PostFileHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task<Unit> Handle(PostFileCommand request, CancellationToken cancellationToken)
        {
           return  await _fileRepository.Post(request);
        }
    }
}
