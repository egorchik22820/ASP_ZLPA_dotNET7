using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_ZALUUPA.Migrations
{
    /// <inheritdoc />
    public partial class photoURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e8bbcd93-b117-411b-b2dc-443e8dfeaa05", "93ed7099-dedb-47af-8534-a4d4d1e1c31d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8bbcd93-b117-411b-b2dc-443e8dfeaa05");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93ed7099-dedb-47af-8534-a4d4d1e1c31d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08c8da72-63f1-469e-a275-8abb845ff7cf", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d55b2acd-0231-44a8-939a-5f3d782ab95e", 0, "f5dc283f-9ba2-4463-b3e2-b094db18c3d3", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEBkVtx60spXTStojP+Ztkr+QRY47qA3nukOQ9SS/IMBQfhnWdfgpkBU56W0WGvYehQ==", null, true, "e5ceac01-6376-45b6-bf60-ebf39bd1744a", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "08c8da72-63f1-469e-a275-8abb845ff7cf", "d55b2acd-0231-44a8-939a-5f3d782ab95e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "08c8da72-63f1-469e-a275-8abb845ff7cf", "d55b2acd-0231-44a8-939a-5f3d782ab95e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08c8da72-63f1-469e-a275-8abb845ff7cf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d55b2acd-0231-44a8-939a-5f3d782ab95e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8bbcd93-b117-411b-b2dc-443e8dfeaa05", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "93ed7099-dedb-47af-8534-a4d4d1e1c31d", 0, "473d23aa-9d49-459e-b36d-9fe5c4e2c164", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAENs7qKiYXjREK7AnVcvOPIaQH13eZB3QOOH50vuVfztXdvKu72hEBbgLGW3/a9ZuLw==", null, true, "7233769f-2d13-4a91-8bad-72abe3aa2b1e", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e8bbcd93-b117-411b-b2dc-443e8dfeaa05", "93ed7099-dedb-47af-8534-a4d4d1e1c31d" });
        }
    }
}
