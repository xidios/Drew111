using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Backend6.Data.Migrations
{
    public partial class OrderChnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Executors_ExecutorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ExecutorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ExecutorId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "ExecutorId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ExecutorId",
                table: "Orders",
                column: "ExecutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Executors_ExecutorId",
                table: "Orders",
                column: "ExecutorId",
                principalTable: "Executors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
