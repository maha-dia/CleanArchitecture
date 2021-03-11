using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkspaceId",
                table: "projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_WorkspaceId",
                table: "projects",
                column: "WorkspaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_projects_Workspaces_WorkspaceId",
                table: "projects",
                column: "WorkspaceId",
                principalTable: "Workspaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_projects_Workspaces_WorkspaceId",
                table: "projects");

            migrationBuilder.DropIndex(
                name: "IX_projects_WorkspaceId",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "WorkspaceId",
                table: "projects");
        }
    }
}
