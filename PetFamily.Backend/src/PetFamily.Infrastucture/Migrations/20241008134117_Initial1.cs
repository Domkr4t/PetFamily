using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "pets");

            migrationBuilder.AddColumn<string>(
                name: "address_city",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_country",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_flat",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_house",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_postal_code",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "address_region",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address_city",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_country",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_flat",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_house",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_postal_code",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "address_region",
                table: "pets");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "pets",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }
    }
}
