using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.WebUI.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1a6d8c4-9e7f-4d20-aae3-6f1b2c9d5e5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9bf6d60-575c-4449-b321-f43cce7940b9", "AQAAAAIAAYagAAAAEK8c/HNAEGcno7jR3ccyiQjS3ss1ys1c5b9MKbFQD+9O9r2bVMaA9vXed3RcQ2xGGA==", "24ea3eed-216b-4344-9d63-a4e5f7ff8dcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e8c5b9-1a2b-4c3d-8e9f-5a6b7c8d9e0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d5b6f31-6170-4719-8af7-101fbcd1eed3", "AQAAAAIAAYagAAAAEO54WQyJZP/4qcRkmpcY89KVmCb5KR33FlACGyiHhkGzbdPc0YUSZY9yMI8KF0SJCw==", "0a964a6b-f9b8-46c7-af9f-0bfe9742cd47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8c6a9d2-5e4f-4b10-9e1d-3c7b8a6f9d2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "427011f5-fe07-4c1e-ad07-d1d1949a434e", "AQAAAAIAAYagAAAAEL7dpoNFaHwLKDEskhrafd7QDLzWWyXswLmSuBczW75K1pPF40J2h8Eotz74Qco6pA==", "11f5c286-87d8-4ff7-b899-d9d8dcbc315f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b1a6d8c4-9e7f-4d20-aae3-6f1b2c9d5e5a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b564a6c-9bba-4ee2-8fd2-d7cbf7a2e7b5", "AQAAAAIAAYagAAAAEGN7Np6GUjjAYFxPx/BIIBO2L8XiPaLW+PdsPz8upx4Ylo+xCr1tYC/5nwkeiNcZVA==", "bbbf37a7-16e9-49da-bdf4-3cf075ce61e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d3e8c5b9-1a2b-4c3d-8e9f-5a6b7c8d9e0f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15da7b20-1b11-40c0-8946-c93d3827912c", "AQAAAAIAAYagAAAAEDDEcmgz7GoJbiP5+tcOVZH7vRX3onAl7NyjVc2vFkCzY05ximbi8N9GYOJjL7CXEQ==", "a26d8181-e457-46fe-b774-4b60d61bdf9f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8c6a9d2-5e4f-4b10-9e1d-3c7b8a6f9d2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "948b6a8b-1ab0-4a46-92c0-890e4bb1c0f6", "AQAAAAIAAYagAAAAEI5E0TjC3Sm2/4/5ssSrYJs7SwugP+X+NUrckxycQrQRZOBxReOzwLtdFigG/n/M5Q==", "5950a6ee-dbfa-4fca-ae58-c5b34abae68e" });
        }
    }
}
