using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public class Repository:IRepository
	{
		private readonly AppDbContext _appDbContext;

		private List<Company> companies;

		public Repository(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		public bool SaveCompanies(List<Company> companies)
		{
			bool anyNewRcordsInserted = false;
			var missingRecords = from cs in companies
								 join cd in _appDbContext.Companies
									 on cs.Symbol equals cd.Symbol into pp
								 from cd in pp.DefaultIfEmpty()
								 where cd == null
								 select cs;
			int count = missingRecords.ToList().Count;
			if (count!=0)
			{
				foreach (Company c in missingRecords)
				{
					_appDbContext.Companies.Add(c);
					anyNewRcordsInserted = true;
				}
				_appDbContext.SaveChanges();
			}
			
			return anyNewRcordsInserted;
		}

		public void SaveCompanyQuote(CompanyQuote companyQuote)
		{
			_appDbContext.CompaniesQuote.Add(companyQuote);
			_appDbContext.SaveChanges();
		}

		public void SaveCompanyDetails(CompanyDetails companyDetails)
		{
			CompanyDetails companyInfo = new CompanyDetails();

			//when the records is missing insert in database
			if (_appDbContext.CompanyDetails.Where(x => x.Symbol == companyDetails.Symbol).Count() == 0)
			{
				_appDbContext.CompanyDetails.Add(companyDetails);
			}

			//else
			//{
			//	// when the record is already present in database
			//	companyInfo = _appDbContext.CompanyDetails.Where(x => x.Symbol == companyDetails.Symbol).FirstOrDefault();

			//	// if record is found updating the column values with latest values obtained from API call.
			//	if (
			//		!companyInfo.CompanyName.Equals(companyDetails.CompanyName, StringComparison.OrdinalIgnoreCase) ||
			//		!companyInfo.CEO.Equals(companyDetails.CEO, StringComparison.OrdinalIgnoreCase) ||
			//		!companyInfo.Exchange.Equals(companyDetails.Exchange, StringComparison.OrdinalIgnoreCase)
			//		)
			//	{
			//		companyInfo.CompanyName = companyDetails.CompanyName.Trim();
			//		companyInfo.CEO = companyDetails.CEO.Trim();
			//		companyInfo.Exchange = companyDetails.Exchange.Trim();

			//	}
			//}
			_appDbContext.SaveChanges();
		}

		public void SaveCompanyLatestDividend(List<CompanyDividend> companyDividend)
		{
			if (companyDividend != null && companyDividend.Count != 0)
			{
				foreach (CompanyDividend c in companyDividend)
				{
					_appDbContext.CompanyDividend.Add(c);
				}
				_appDbContext.SaveChanges();
			}
		}

		public bool SaveFeedback(Feedback feedback)
		{
			bool isFeedbackSaved= false;
			if (feedback != null)
			{
				_appDbContext.Feedback.Add(feedback);
				isFeedbackSaved = true;
			}
			return isFeedbackSaved;
		}
	}
}
