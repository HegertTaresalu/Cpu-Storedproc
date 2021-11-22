using Microsoft.EntityFrameworkCore.Migrations;

namespace StoredProc.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cpu",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Company = table.Column<string>(nullable: true),
                    BaseClock = table.Column<double>(nullable: true),
                    MaxBoostClock = table.Column<double>(nullable: true),
                    CoreCount = table.Column<int>(nullable: true),
                    ThreadCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cpu", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.FirstName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cpu");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
