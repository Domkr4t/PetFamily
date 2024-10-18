using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pet_details_breed",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "pet_details_type",
                table: "pets");

            migrationBuilder.AddColumn<Guid>(
                name: "pet_details_breed_id",
                table: "pets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "pet_details_specie_id",
                table: "pets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breeds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    specie_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breeds", x => x.id);
                    table.ForeignKey(
                        name: "fk_breeds_species_specie_id",
                        column: x => x.specie_id,
                        principalTable: "species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_breeds_specie_id",
                table: "breeds",
                column: "specie_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breeds");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropColumn(
                name: "pet_details_breed_id",
                table: "pets");

            migrationBuilder.DropColumn(
                name: "pet_details_specie_id",
                table: "pets");

            migrationBuilder.AddColumn<string>(
                name: "pet_details_breed",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pet_details_type",
                table: "pets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
