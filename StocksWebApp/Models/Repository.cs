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
			//foreach (Company c in companies)
			//{
			//	if (_appDbContext.Companies.Where(x => x.Symbol.Equals(c.Symbol)).Count() == 0)
			//	{
			//		_appDbContext.Companies.Add(c);
			//		anyNewRcordsInserted = true;

			//	}
			//}
	
		
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

		public CompanyQuote GetCompanyQuote(string symbol)
		{
			return _appDbContext.CompaniesQuote.FirstOrDefault(x => x.Symbol == symbol);
		}
	}
}
