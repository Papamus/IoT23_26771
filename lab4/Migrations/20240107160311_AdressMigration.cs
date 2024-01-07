using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab3V2.Migrations
{
    /// <inheritdoc />
    public partial class AdressMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressEntityId",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressEntityId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressEntityId",
                table: "Person",
                column: "AddressEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Address_AddressEntityId",
                table: "Person",
                column: "AddressEntityId",
                principalTable: "Address",
                principalColumn: "AddressEntityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Address_AddressEntityId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Person_AddressEntityId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "AddressEntityId",
                table: "Person");
        }
    }
}
