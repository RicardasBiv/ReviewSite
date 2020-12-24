using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class extra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentaras_Vertinimas_VertinimasId",
                table: "Komentaras");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bdc4f6df-26d9-4df8-a702-996877afe433");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "38a8dcde-5a9e-4c6c-b690-4c53993f1eb8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "305f6ac8-d6dd-4fea-97ac-4d426f9c5537");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "2444ca52-99f1-4d3d-994e-07e46b125534");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentaras_Vertinimas_VertinimasId",
                table: "Komentaras",
                column: "VertinimasId",
                principalTable: "Vertinimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentaras_Vertinimas_VertinimasId",
                table: "Komentaras");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5dd37071-9b33-4d31-aeee-a1a6520d98c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "003cf495-815a-4681-a898-57709fdbf0b9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "61796ceb-658c-4a65-a6bd-2ae9345a5bc9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "18144540-c3d6-44fb-9386-bc4bdaac5191");

            migrationBuilder.AddForeignKey(
                name: "FK_Komentaras_Vertinimas_VertinimasId",
                table: "Komentaras",
                column: "VertinimasId",
                principalTable: "Vertinimas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
