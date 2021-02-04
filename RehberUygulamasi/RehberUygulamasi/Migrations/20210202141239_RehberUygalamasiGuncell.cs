using Microsoft.EntityFrameworkCore.Migrations;

namespace RehberUygulamasi.Migrations
{
    public partial class RehberUygalamasiGuncell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Şehirler_SehirId",
                table: "Kisiler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Şehirler",
                table: "Şehirler");

            migrationBuilder.RenameTable(
                name: "Şehirler",
                newName: "Sehirler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sehirler",
                table: "Sehirler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Sehirler_SehirId",
                table: "Kisiler",
                column: "SehirId",
                principalTable: "Sehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kisiler_Sehirler_SehirId",
                table: "Kisiler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sehirler",
                table: "Sehirler");

            migrationBuilder.RenameTable(
                name: "Sehirler",
                newName: "Şehirler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Şehirler",
                table: "Şehirler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Kisiler_Şehirler_SehirId",
                table: "Kisiler",
                column: "SehirId",
                principalTable: "Şehirler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
