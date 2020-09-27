using Application.Common.Interfaces;
using Application.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace UnitTest.Workspace
{
    public class BaseWorkspaceMock
    {
        protected readonly Mock<IProjectRepository> _projectRepositoryMock;
        protected readonly Mock<IWorkspaceRepository> _workspaceRepositoryMock;
        protected readonly Mock<ICurrentUserService> _currentUserMock;
         public BaseWorkspaceMock()
        {
            this._currentUserMock = new Mock<ICurrentUserService>();
            this._workspaceRepositoryMock = new Mock<IWorkspaceRepository>();
            this._projectRepositoryMock = new Mock<IProjectRepository>();
            
        }
    }
}
