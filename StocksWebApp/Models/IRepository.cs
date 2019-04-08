using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public interface IRepository
	{
		bool SaveCompanies(List<Company> companies);

		void SaveCompanyQuote(CompanyQuote companyQuote);

		void SaveCompanyDetails(CompanyDetails companyDetails);

		void SaveCompanyLatestDividend(List<CompanyDividend> companyDividend);

		bool SaveFeedback(Feedback feedback);
	}
}
