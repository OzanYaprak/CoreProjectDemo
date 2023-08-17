using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JopID",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Jops",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jops", x => x.JobID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_JopID",
                table: "Customers",
                column: "JopID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Jops_JopID",
                table: "Customers",
                column: "JopID",
                principalTable: "Jops",
                principalColumn: "JobID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Jops_JopID",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Jops");

            migrationBuilder.DropIndex(
                name: "IX_Customers_JopID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "JopID",
                table: "Customers");
        }
    }
}
