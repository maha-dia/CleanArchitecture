using Application.Repositories;
using Core.Commun;
using Core.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _context;
        public FileRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<File> AddAsync(Component command,Folder folderId)
        {
            var file = new Core.Entities.File(command.Name) {
                Parent = folderId,
            };
            
            //folder.FolderId
            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();

            return file;
        }
    }
}
