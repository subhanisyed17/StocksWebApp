﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StocksWebApp.Models;

namespace StocksWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StocksWebApp.Models.Company", b =>
                {
                    b.Property<string>("Symbol")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("Iexid");

                    b.Property<bool>("IsEnabled");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.HasKey("Symbol");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StocksWebApp.Models.CompanyQuote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CompanyMarketCapitilization");

                    b.Property<bool>("IsStockAvailable");

                    b.Property<string>("Symbol");

                    b.Property<decimal>("closingprice");

                    b.Property<string>("companyname");

                    b.Property<decimal>("highestprice");

                    b.Property<decimal>("latestprice");

                    b.Property<decimal>("lowestprice");

                    b.Property<decimal>("openingprice");

                    b.Property<string>("primaryexchange");

                    b.Property<decimal>("priviousclosingprice");

                    b.Property<string>("sector");

                    b.HasKey("QuoteId");

                    b.ToTable("CompaniesQuote");
                });
#pragma warning restore 612, 618
        }
    }
}
