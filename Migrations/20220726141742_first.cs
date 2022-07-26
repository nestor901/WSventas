using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSventas.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime", nullable: true),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_venta_Cliente",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "concepto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_venta = table.Column<int>(type: "int", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    precioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    importe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Id_producto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concepto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concepto_producto",
                        column: x => x.Id_producto,
                        principalTable: "producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_concepto_venta",
                        column: x => x.id_venta,
                        principalTable: "venta",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_concepto_Id_producto",
                table: "concepto",
                column: "Id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_concepto_id_venta",
                table: "concepto",
                column: "id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_venta_clienteId",
                table: "venta",
                column: "clienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concepto");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "venta");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
