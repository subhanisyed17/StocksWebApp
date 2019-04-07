using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StocksWebApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Symbol = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CompanyType = table.Column<string>(nullable: true),
                    Iexid = table.Column<int>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "CompaniesQuote",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Symbol = table.Column<string>(nullable: true),
                    companyname = table.Column<string>(nullable: true),
                    primaryexchange = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    openingprice = table.Column<decimal>(nullable: false),
                    closingprice = table.Column<decimal>(nullable: false),
                    highestprice = table.Column<decimal>(nullable: false),
                    lowestprice = table.Column<decimal>(nullable: false),
                    latestprice = table.Column<decimal>(nullable: false),
                    priviousclosingprice = table.Column<decimal>(nullable: false),
                    IsStockAvailable = table.Column<bool>(nullable: false),
                    CompanyMarketCapitilization = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompaniesQuote", x => x.QuoteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CompaniesQuote");
        }
    }
}
