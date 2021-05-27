using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend6.Data.Migrations
{
    public partial class AddedKekwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderExecutors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExecutorId = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderExecutors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderExecutors_Executors_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Executors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderExecutors_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderExecutors_ExecutorId",
                table: "orderExecutors",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_orderExecutors_OrderId",
                table: "orderExecutors",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderExecutors");
        }
    }
}
