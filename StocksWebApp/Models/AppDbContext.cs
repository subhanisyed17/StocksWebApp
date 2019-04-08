using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<Company> Companies { get; set; }

		public DbSet<CompanyQuote> CompaniesQuote { get; set; }

		public DbSet<CompanyDetails> CompanyDetails { get; set; }

		public DbSet<CompanyDividend> CompanyDividend { get; set; }

		public DbSet<Feedback> Feedback { get; set; }
	}
}
