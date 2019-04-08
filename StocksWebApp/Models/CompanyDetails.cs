using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public class CompanyDetails
	{
		[Key]
		public int Id { get; set; }
		[ForeignKey("Company")]
		public string Symbol { get; set; }
		public string CompanyName { get; set; }

		public string CEO { get; set; }
		public string Exchange { get; set; }
		public string Industry { get; set; }

		public string Sector { get; set; }


	}
}
