using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Initial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "surname",
                table: "volunteers",
                newName: "full_name_surname");

            migrationBuilder.RenameColumn(
                name: "patronymic",
                table: "volunteers",
                newName: "full_name_patronymic");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "volunteers",
                newName: "full_name_first_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "full_name_surname",
                table: "volunteers",
                newName: "surname");

            migrationBuilder.RenameColumn(
                name: "full_name_patronymic",
                table: "volunteers",
                newName: "patronymic");

            migrationBuilder.RenameColumn(
                name: "full_name_first_name",
                table: "volunteers",
                newName: "first_name");
        }
    }
}
