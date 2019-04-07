using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public class CompanyQuote
	{
		[Key]
		public int QuoteId { get; set; } // this column value is set during insertion of records into database by dbcontext

		[ForeignKey("Company")]
		public String Symbol { get; set; }
		public string companyname { get; set; }
		public string primaryexchange { get; set; }
		public string sector { get; set; }
		public decimal openingprice { get; set; }
		public decimal closingprice { get; set; }
		public decimal highestprice { get; set; }
		public decimal lowestprice { get; set; }
		public decimal latestprice { get; set; }
		public decimal priviousclosingprice { get; set; }
		public bool IsStockAvailable { get; set; }
		public decimal CompanyMarketCapitilization { get; set; }
	}
}
