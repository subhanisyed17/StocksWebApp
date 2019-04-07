using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public interface IRepository
	{
		bool SaveCompanies(List<Company> companies);

		CompanyQuote GetCompanyQuote(string symbol);
	}
}
