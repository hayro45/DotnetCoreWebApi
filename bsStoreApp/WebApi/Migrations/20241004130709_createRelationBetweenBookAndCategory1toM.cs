using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class createRelationBetweenBookAndCategory1toM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dd99cfe-9bc8-47bc-ab29-175c058da17a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "729b298f-e653-4c6e-a3b9-72e584f0969c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea951780-57f6-4656-83ad-b73a5a9f91ea");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3410d8a5-c03c-494b-bd6c-dab8550171bf", "525610b2-5ea9-4f11-b337-b9df150fbf6a", "User", "USER" },
                    { "65e4fc07-730a-4a76-af6a-8201894030a7", "175058d4-25a5-4645-9b48-e911dab68c53", "Editor", "EDITOR" },
                    { "78f09ca6-e7e9-4fbb-ad16-3e4484a8dbde", "32f1e474-c5b3-4e8e-ae6e-e9946b0e8a00", "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3410d8a5-c03c-494b-bd6c-dab8550171bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65e4fc07-730a-4a76-af6a-8201894030a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78f09ca6-e7e9-4fbb-ad16-3e4484a8dbde");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5dd99cfe-9bc8-47bc-ab29-175c058da17a", "4891e086-14af-4cc1-9755-bb6e7907f87f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "729b298f-e653-4c6e-a3b9-72e584f0969c", "96695031-d662-44e4-a845-e163732ebf33", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea951780-57f6-4656-83ad-b73a5a9f91ea", "e871ec5d-5f89-4719-8e6d-b1def88e1cd2", "Editor", "EDITOR" });
        }
    }
}
