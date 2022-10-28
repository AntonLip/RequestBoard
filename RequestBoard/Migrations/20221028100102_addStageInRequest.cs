using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RequestBoard.Migrations
{
    public partial class addStageInRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8d2959a-20aa-45d6-8173-7856351f7ec3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92f2ab64-618e-49ab-a7cd-ac9ff6f993d8", "c5dd43b5-672c-43ff-846f-724ba2698d31" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92f2ab64-618e-49ab-a7cd-ac9ff6f993d8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5dd43b5-672c-43ff-846f-724ba2698d31");

            migrationBuilder.AddColumn<int>(
                name: "Stage",
                table: "RequestToRestores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a87c446a-1b8a-4299-81e1-fa7751aaf6eb", "2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8aac276-e4ff-4060-a39c-5ece52eb6f36", "1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4f36982e-4214-4b58-8684-cc0aaf637b88", 0, "avadvd", "admin@ya.ru", true, "Pavel", "", false, null, "ADMIN@YA.RU", "ADMIN", "AQAAAAEAACcQAAAAEAJblk2pxmcmE9ea+LogVW1vq2LnhwlL6b4Ji+8Lxk7j9Hdc0o7bp4O68H70ur5LLw==", "1234567890", false, "avebgdfvs", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f8aac276-e4ff-4060-a39c-5ece52eb6f36", "4f36982e-4214-4b58-8684-cc0aaf637b88" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a87c446a-1b8a-4299-81e1-fa7751aaf6eb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8aac276-e4ff-4060-a39c-5ece52eb6f36", "4f36982e-4214-4b58-8684-cc0aaf637b88" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8aac276-e4ff-4060-a39c-5ece52eb6f36");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f36982e-4214-4b58-8684-cc0aaf637b88");

            migrationBuilder.DropColumn(
                name: "Stage",
                table: "RequestToRestores");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92f2ab64-618e-49ab-a7cd-ac9ff6f993d8", "1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b8d2959a-20aa-45d6-8173-7856351f7ec3", "2", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c5dd43b5-672c-43ff-846f-724ba2698d31", 0, "avadvd", "admin@ya.ru", true, "Pavel", "", false, null, "ADMIN@YA.RU", "ADMIN", "AQAAAAEAACcQAAAAEB+fPVAEzti7wiDp17e6zBMgZZyPkR4ubgbazqbgsq5Xif3viKNHeMVzHzS70GHH5g==", "1234567890", false, "avebgdfvs", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "92f2ab64-618e-49ab-a7cd-ac9ff6f993d8", "c5dd43b5-672c-43ff-846f-724ba2698d31" });
        }
    }
}
