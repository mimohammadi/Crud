using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Repository.Migrations
{
    /// <inheritdoc />
    public partial class correctTablename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "PersonalInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonalInfos",
                table: "PersonalInfos",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonalInfos",
                table: "PersonalInfos");

            migrationBuilder.RenameTable(
                name: "PersonalInfos",
                newName: "Discounts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");
        }
    }
}
