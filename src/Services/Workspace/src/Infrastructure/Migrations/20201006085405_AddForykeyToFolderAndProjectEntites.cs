using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddForykeyToFolderAndProjectEntites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Folders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ProjectId",
                table: "Folders",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_projects_ProjectId",
                table: "Folders",
                column: "ProjectId",
                principalTable: "projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_projects_ProjectId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_ProjectId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Folders");
        }
    }
}
