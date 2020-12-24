using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "4b4c9c58-e68f-467a-998f-8b994e91d5d2", "admin@admin.com", false, false, null, null, null, "", null, false, null, false, "admin" },
                    { 2, 0, "193e5b1b-7879-418b-b6aa-2033deb57b25", "writer@writer.com", false, false, null, null, null, "", null, false, null, false, "Writer" },
                    { 3, 0, "91fa87d1-8c37-423a-a780-397c3c9886b2", "user@user.com", false, false, null, null, null, "", null, false, null, false, "User" },
                    { 4, 0, "cc077ef6-ef2f-4a27-8773-5ea197060727", "user2@user2.com", false, false, null, null, null, "", null, false, null, false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Tipas",
                columns: new[] { "Id", "Tipas1" },
                values: new object[,]
                {
                    { 1, "Knyga" },
                    { 2, "Filmas" },
                    { 3, "Serialas" }
                });

            migrationBuilder.InsertData(
                table: "Zanrai",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Veiksmo" },
                    { 2, "Animacinis" },
                    { 3, "Fantastinis" },
                    { 4, "Nuotykių" },
                    { 5, "Siaubo" },
                    { 6, "Trileris" },
                    { 7, "Romantinis" }
                });

            migrationBuilder.InsertData(
                table: "Recenzija",
                columns: new[] { "Id", "Aprasymas", "KritikoVertinimas", "Pavadinimas", "RasytojasId", "Tipas", "Zanras" },
                values: new object[,]
                {
                    { 1, "Aprasymas", 5, "Inception", 2, 1, 1 },
                    { 2, "Aprasfasfdasdfymas", 8, "Antras", 2, 2, 1 },
                    { 3, "Aprassadfasdfymas", 7, "Trecias", 2, 2, 1 },
                    { 4, "Aprsdfasdfasdfasymas", 10, "Ketvirtas", 2, 2, 1 },
                    { 5, "Aprassadfasdfymas", 9, "Penktas", 2, 2, 1 },
                    { 6, "Apdfasdfsadfrasymas", 7, "Haris Poteris", 2, 2, 1 },
                    { 7, "Aprassdfasdfsaymas", 8, "Fast and furiuos", 2, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vertinimas",
                columns: new[] { "Id", "IdNaudotojas", "IdRecenzija", "Vertinimas1" },
                values: new object[,]
                {
                    { 1, 3, 1, 10 },
                    { 2, 3, 2, 10 },
                    { 3, 3, 2, 5 },
                    { 4, 4, 3, 5 },
                    { 5, 4, 4, 7 },
                    { 6, 4, 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "Komentaras",
                columns: new[] { "Id", "Komentaras1", "VertinimasId" },
                values: new object[,]
                {
                    { 1, "komentaras", 1 },
                    { 2, "komentaras", 2 },
                    { 3, "komentaras", 3 },
                    { 4, "komentaras", 4 },
                    { 5, "komentaras", 5 },
                    { 6, "komentaras", 6 }
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Komentaras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Komentaras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Komentaras",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Komentaras",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Komentaras",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Komentaras",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tipas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zanrai",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zanrai",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zanrai",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zanrai",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Zanrai",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Zanrai",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vertinimas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vertinimas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vertinimas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vertinimas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vertinimas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vertinimas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Recenzija",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tipas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tipas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zanrai",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Vertinimas1",
                table: "Vertinimas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

        }
    }
}
