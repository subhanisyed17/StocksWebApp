using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksWebApp.Migrations
{
    public partial class changedcompanyquotemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "priviousclosingprice",
                table: "CompaniesQuote",
                newName: "previousClose");

            migrationBuilder.RenameColumn(
                name: "openingprice",
                table: "CompaniesQuote",
                newName: "open");

            migrationBuilder.RenameColumn(
                name: "lowestprice",
                table: "CompaniesQuote",
                newName: "marketCap");

            migrationBuilder.RenameColumn(
                name: "highestprice",
                table: "CompaniesQuote",
                newName: "low");

            migrationBuilder.RenameColumn(
                name: "closingprice",
                table: "CompaniesQuote",
                newName: "high");

            migrationBuilder.RenameColumn(
                name: "CompanyMarketCapitilization",
                table: "CompaniesQuote",
                newName: "close");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "previousClose",
                table: "CompaniesQuote",
                newName: "priviousclosingprice");

            migrationBuilder.RenameColumn(
                name: "open",
                table: "CompaniesQuote",
                newName: "openingprice");

            migrationBuilder.RenameColumn(
                name: "marketCap",
                table: "CompaniesQuote",
                newName: "lowestprice");

            migrationBuilder.RenameColumn(
                name: "low",
                table: "CompaniesQuote",
                newName: "highestprice");

            migrationBuilder.RenameColumn(
                name: "high",
                table: "CompaniesQuote",
                newName: "closingprice");

            migrationBuilder.RenameColumn(
                name: "close",
                table: "CompaniesQuote",
                newName: "CompanyMarketCapitilization");
        }
    }
}
