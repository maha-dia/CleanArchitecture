using Application.Common.Exceptions;
using Application.Project.Commands.UpdateProject;
using Application.Project.Queries.GetProjectById;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest.Workspace;
using Xunit;

namespace UnitTest.Project
{
    public class UpdateProjectUnitTests:BaseMock
    {
        [Fact]
        public async void InValidCommand_ShouldThrowException()
        {
            var request = new UpdateProjectCommand
            {
                ProjectId = Guid.Empty,
                Label ="nouvelle label",
                Description = "nouvelle description",
                Icon = "nouvelle icon"
            };

            var getEntity = new GetProjectByIdQuery
            {
                Id = request.ProjectId,
            };
            var project = new Core.Entities.Project {
                ProjectId = Guid.Parse("CE854229-F5E7-4CCE-603B-08D85FD832A3"),
                Label = " label",
                Description = "description",
                Icon = " icon"
            };

            _projectRepositoryMock.Setup(x => x.GetAsync(It.IsAny<GetProjectByIdQuery>())).ReturnsAsync(project);
            //_workspaceRepositoryMock.Setup(y => y.UniqueName(project.Label, new System.Threading.CancellationToken())).ReturnsAsync(true);
            _projectRepositoryMock.Setup(z => z.UpdateAsync(request, _currentUserMock.Object));

            var handler = new UpdateProjectCommandHandler(_projectRepositoryMock.Object, _workspaceRepositoryMock.Object, _currentUserMock.Object);
            //var projectUpdated = await handler.Handle(request, new System.Threading.CancellationToken());

            await Assert.ThrowsAsync<BusinessRuleException>(
                 () => handler.Handle(request, new System.Threading.CancellationToken()));




        }
    }
}
