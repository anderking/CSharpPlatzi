using Microsoft.EntityFrameworkCore.Migrations;

namespace CategoryJobsEF.Migrations
{
    public partial class EntityBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifedDate",
                table: "Job",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "ModifedDate",
                table: "Category",
                newName: "ModifiedDate");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserEmail",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserEmail",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserName",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateModified",
                table: "Job",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserEmail",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserEmail",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedUserName",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "State",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateDelete",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StateModified",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatedUserEmail",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ModifiedUserEmail",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "ModifiedUserName",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "StateModified",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedUserEmail",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedUserName",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifiedUserEmail",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifiedUserName",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "StateDelete",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "StateModified",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Job",
                newName: "ModifedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Category",
                newName: "ModifedDate");
        }
    }
}
