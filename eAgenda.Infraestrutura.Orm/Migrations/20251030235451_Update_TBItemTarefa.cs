using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eAgenda.Infraestrutura.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Update_TBItemTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBItemTarefa_AspNetUsers_UsuarioId",
                table: "TBItemTarefa");

            migrationBuilder.DropIndex(
                name: "IX_TBItemTarefa_UsuarioId",
                table: "TBItemTarefa");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TBItemTarefa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "TBItemTarefa",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TBItemTarefa_UsuarioId",
                table: "TBItemTarefa",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBItemTarefa_AspNetUsers_UsuarioId",
                table: "TBItemTarefa",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
