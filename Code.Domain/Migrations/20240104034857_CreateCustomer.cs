using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Code.Domain.Migrations
{
    public partial class CreateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "FirstName", "LastName", "Email", "CreatedDateTime", "LastUpdatedDateTime" },
                values: new object[,]
                {
                    { "John", "Doe", "john.doe@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Jane", "Doe", "jane.doe@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Alice", "Smith", "alice.smith@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Bob", "Brown", "bob.brown@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Charlie", "Davis", "charlie.davis@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Daisy", "Miller", "daisy.miller@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Ethan", "Wilson", "ethan.wilson@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Fiona", "Taylor", "fiona.taylor@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "George", "Anderson", "george.anderson@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Hannah", "Thomas", "hannah.thomas@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Ivan", "Jackson", "ivan.jackson@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Julia", "White", "julia.white@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Kevin", "Harris", "kevin.harris@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Lily", "Martin", "lily.martin@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Mike", "Garcia", "mike.garcia@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Nina", "Robinson", "nina.robinson@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Oscar", "Clark", "oscar.clark@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Pamela", "Rodriguez", "pamela.rodriguez@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Quincy", "Lewis", "quincy.lewis@example.com", DateTime.UtcNow, DateTime.UtcNow },
                    { "Rachel", "Lee", "rachel.lee@example.com", DateTime.UtcNow, DateTime.UtcNow }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
