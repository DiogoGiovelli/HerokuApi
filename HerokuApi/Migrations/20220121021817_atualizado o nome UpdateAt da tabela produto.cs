using Microsoft.EntityFrameworkCore.Migrations;

namespace HerokuApi.Migrations
{
    public partial class atualizadoonomeUpdateAtdatabelaproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updateat",
                table: "produto",
                newName: "updatedat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedat",
                table: "produto",
                newName: "updateat");
        }
    }
}
