using Application.Common.Exceptions;
using Application.Project.Commands;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Workspace;
using Xunit;

namespace UnitTest.Project
{
    public class UnitTest:BaseMock
    {
        [Fact]
        public async void ValidCommand_ShouldReturnProjectId()
        {
            //Arrage
            var command = new CreateProjectCommand
            {
                Label = "Plateforme",
                Description = "abcdefghigklmopqrstuvwxyz",
                WorkspaceId = Guid.NewGuid()
            };

            var workspace = new Core.Entities.Workspace { 
                Name = "testWorkspaceMock",
                Description = "jsjsjjssjjsjjksjksjksjkjkskjkjksjks",
                Id=command.WorkspaceId
            };
            //this._projectRepositoryMock.Setup(x => x.CreateAsync(command,workspace, _currentUserMock.Object)).ReturnsAsync(Guid.NewGuid());
            //this._workspaceRepositoryMock.Setup(w => w.GetAsync(command.WorkspaceId)).ReturnsAsync(workspace);

            //Act
            var handler = new CreateProjectHandler(_workspaceRepositoryMock.Object, _projectRepositoryMock.Object, _currentUserMock.Object);
            var projectId = await handler.Handle(command, new System.Threading.CancellationToken());

            //Assert 
            Assert.NotEqual(projectId, Guid.Empty);
        }


        [Fact]
        public async void IforkspaceDoesntExist_ShouldThrowEXception()
        {
            //Arrage
            var command = new CreateProjectCommand
            {
                Label = "PlateformeShouldThrow",
                Description = "abcdefghigklmopqrstuvwxyz"
                
            };

            this._projectRepositoryMock.Setup(p => p.CreateAsync(command, null, _currentUserMock.Object))
                .ReturnsAsync(Guid.NewGuid());
            //this._workspaceRepositoryMock.Setup(w => w.GetAsync(command.WorkspaceId));

            //Act
            var handler = new CreateProjectHandler(_workspaceRepositoryMock.Object, _projectRepositoryMock.Object, _currentUserMock.Object);
            //Asset
            await Assert.ThrowsAsync<BusinessRuleException>(
                 () => handler.Handle(command, new System.Threading.CancellationToken()));

        }
    }
}
