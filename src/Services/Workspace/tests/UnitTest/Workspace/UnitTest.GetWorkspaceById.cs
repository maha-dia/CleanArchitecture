using Application.Common.Exceptions;
using Application.Workspace.Queries.GetWorkspace;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.Workspace
{
    public class GetWorkspaceByIdTests: BaseWorkspaceMock
    {
        [Fact]
        public async void ShouldGiveValideGuidIdRequest()
        {
            //Arrage
            var request = new GetWorkspaceByIdQuery
            {
                WorkspaceRequestId =  Guid.Empty,
            };
            var workspace = new Core.Entities.Workspace();
            this._workspaceRepositoryMock.Setup(x => x.GetAsync(request.WorkspaceRequestId))
                .ReturnsAsync(workspace);

            //Act
            var handler = new GetWorkspaceByIdHandler(_workspaceRepositoryMock.Object);

            //Assert
             await Assert.ThrowsAsync<BusinessRuleException>(
                 () => handler.Handle(request, new System.Threading.CancellationToken()));
                
        }
    }
}
