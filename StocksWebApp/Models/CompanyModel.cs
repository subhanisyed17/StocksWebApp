using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public class CompanyModel
	{
		public List<Company> Companies { get; set; }

		public int CurrentPageIndex { get; set; }

		public int PageCount { get; set; }
	}
}
