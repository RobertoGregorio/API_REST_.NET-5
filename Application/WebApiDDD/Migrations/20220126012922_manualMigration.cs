using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiDDD.Migrations
{
    public partial class manualMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Accounts (Balance,HolderCPF)values(1000,62596266300)");
            migrationBuilder.Sql("Insert into Accounts (Balance,HolderCPF)values(1000,62596266300)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
