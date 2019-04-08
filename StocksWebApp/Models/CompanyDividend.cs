using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public class CompanyDividend
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Company")]
		public string Symbol { get; set; }
		public DateTime DeclaredDate { get; set; }

		public decimal Amount { get; set; }

		public DateTime PaymentDate { get; set; }

		public string Type { get; set; }
	}
}
