using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_ZALUUPA.Migrations
{
    /// <inheritdoc />
    public partial class newPhotoLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServicePhotos_Services_ServiceId",
                table: "ServicePhotos");

            migrationBuilder.DropIndex(
                name: "IX_ServicePhotos_ServiceId",
                table: "ServicePhotos");

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

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ServicePhotos");

            migrationBuilder.AddColumn<int>(
                name: "ServicePhotoId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "557f5381-52ae-4e45-9acd-919c8626db3d", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "80b38c19-dd4a-406b-9215-c8adec85940e", 0, "a04d3c79-9706-40ff-9020-5de982133bdf", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAELtRhw/ca432srC0DAJ9HVp6riuHYKUaewNVhgdH3LtlfP2dC8RUK4/ABXuUvruZfA==", null, true, "d97878c6-ea22-46bd-8959-7c4826111495", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "557f5381-52ae-4e45-9acd-919c8626db3d", "80b38c19-dd4a-406b-9215-c8adec85940e" });

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServicePhotoId",
                table: "Services",
                column: "ServicePhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServicePhotos_ServicePhotoId",
                table: "Services",
                column: "ServicePhotoId",
                principalTable: "ServicePhotos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServicePhotos_ServicePhotoId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_ServicePhotoId",
                table: "Services");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "557f5381-52ae-4e45-9acd-919c8626db3d", "80b38c19-dd4a-406b-9215-c8adec85940e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "557f5381-52ae-4e45-9acd-919c8626db3d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80b38c19-dd4a-406b-9215-c8adec85940e");

            migrationBuilder.DropColumn(
                name: "ServicePhotoId",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "ServicePhotos",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_ServicePhotos_Services_ServiceId",
                table: "ServicePhotos",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
