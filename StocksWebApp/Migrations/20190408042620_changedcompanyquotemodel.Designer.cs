﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StocksWebApp.Models;

namespace StocksWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190408042620_changedcompanyquotemodel")]
    partial class changedcompanyquotemodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("StocksWebApp.Models.CompanyDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEO");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Exchange");

                    b.Property<string>("Industry");

                    b.Property<string>("Sector");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.ToTable("CompanyDetails");
                });

            modelBuilder.Entity("StocksWebApp.Models.CompanyDividend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("DeclaredDate");

                    b.Property<DateTime>("PaymentDate");

                    b.Property<string>("Symbol");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("CompanyDividend");
                });

            modelBuilder.Entity("StocksWebApp.Models.CompanyQuote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsStockAvailable");

                    b.Property<string>("Symbol");

                    b.Property<decimal>("close");

                    b.Property<string>("companyname");

                    b.Property<decimal>("high");

                    b.Property<decimal>("latestprice");

                    b.Property<decimal>("low");

                    b.Property<decimal>("marketCap");

                    b.Property<decimal>("open");

                    b.Property<decimal>("previousClose");

                    b.Property<string>("primaryexchange");

                    b.Property<string>("sector");

                    b.HasKey("QuoteId");

                    b.ToTable("CompaniesQuote");
                });

            modelBuilder.Entity("StocksWebApp.Models.Feedback", b =>
                {
                    b.Property<string>("FeedbackId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailId");

                    b.Property<string>("FeedbackMessage");

                    b.Property<string>("Name");

                    b.HasKey("FeedbackId");

                    b.ToTable("Feedback");
                });
#pragma warning restore 612, 618
        }
    }
}
