using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_ZALUUPA.Migrations
{
    /// <inheritdoc />
    public partial class photoSaveDbTest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ServicePhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePhotos_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68a26189-0b6e-47c9-8c73-6a46fd3dc4df", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c8b774f3-8ac4-4256-b2cf-f5ceb13f088f", 0, "d916143e-c531-4e2e-bc8f-d543950f32d2", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAENipyZybAp3pHpaJNnnWiYWYHzNhIx5Nea1Q2vq1JgOnF4r0d1F1eTYp0sLFU5hnNg==", null, true, "5fa1b06a-b3ea-43c5-8076-c03a84bd76c7", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "68a26189-0b6e-47c9-8c73-6a46fd3dc4df", "c8b774f3-8ac4-4256-b2cf-f5ceb13f088f" });

            migrationBuilder.CreateIndex(
                name: "IX_ServicePhotos_ServiceId",
                table: "ServicePhotos",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicePhotos");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "68a26189-0b6e-47c9-8c73-6a46fd3dc4df", "c8b774f3-8ac4-4256-b2cf-f5ceb13f088f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68a26189-0b6e-47c9-8c73-6a46fd3dc4df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8b774f3-8ac4-4256-b2cf-f5ceb13f088f");

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
    }
}
