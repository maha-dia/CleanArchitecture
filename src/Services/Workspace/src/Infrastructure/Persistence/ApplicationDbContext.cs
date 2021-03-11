using Application.Common.Interfaces;
using Core.Commun;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        
        private readonly IDateTime _dateTime;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            this._currentUserService = currentUserService;
            this._dateTime = dateTime;
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedBy = _currentUserService.UserId;
                        entry.Entity.DeletedAt = _dateTime.Now;
                        break;


                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<File>Files { get; set; }
        public DbSet<Folder> Folders { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            

            base.OnModelCreating(builder);
        }
    }
}
