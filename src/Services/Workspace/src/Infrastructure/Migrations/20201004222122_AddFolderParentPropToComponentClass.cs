using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddFolderParentPropToComponentClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentFolderId",
                table: "Folders",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentFolderId",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ParentFolderId",
                table: "Files",
                column: "ParentFolderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folders_ParentFolderId",
                table: "Files",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "FolderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "FolderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Folders_ParentFolderId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Files_ParentFolderId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ParentFolderId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "ParentFolderId",
                table: "Files");
        }
    }
}
