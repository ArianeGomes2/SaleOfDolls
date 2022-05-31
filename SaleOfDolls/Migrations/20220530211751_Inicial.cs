using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaleOfDolls.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Dolls",
                columns: table => new
                {
                    DollId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hair = table.Column<int>(type: "int", nullable: false),
                    Eyes = table.Column<byte>(type: "tinyint", nullable: false),
                    Skin = table.Column<byte>(type: "tinyint", nullable: false),
                    Clothing = table.Column<byte>(type: "tinyint", nullable: false),
                    Accessory = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dolls", x => x.DollId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "Solicitations",
                columns: table => new
                {
                    SolicitationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    RequestNumber = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: false),
                    FormOfPayment = table.Column<byte>(type: "tinyint", nullable: false),
                    DollId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitations", x => x.SolicitationId);
                    table.ForeignKey(
                        name: "FK_Solicitations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitations_Dolls_DollId",
                        column: x => x.DollId,
                        principalTable: "Dolls",
                        principalColumn: "DollId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitations_ClientId",
                table: "Solicitations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitations_DollId",
                table: "Solicitations",
                column: "DollId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Dolls");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
