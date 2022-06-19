using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zadaniedodatkowe.Entities.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "IdCompany", "CreationDate", "Location", "Name" },
                values: new object[] { 2, new DateTime(2004, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japonia", "FromSoftware" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Company",
                keyColumn: "IdCompany",
                keyValue: 2);
        }
    }
}
