using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StocksWebApp.Models;

namespace StocksWebApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly IRepository _repository;

		public List<Company> companies;
		public CompanyDetails detailsOfCompany;
		public List<CompanyDividend> dividendsOfCompany;
		bool isSaved = false;
		public string BASE_URL = "https://api.iextrading.com/1.0/";
		HttpClient httpClient;

		public HomeController(IRepository repository)
		{
			_repository = repository;
			httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new
				System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}

		public IActionResult Companies()
		{
			List<Company> allCompanies = GetAllCompanies();
			bool areNewRcordsInserted = _repository.SaveCompanies(allCompanies);
			return View(allCompanies);
		}

		private List<Company> GetAllCompanies()
		{
			string CompaniesApi_End_Point = BASE_URL + "ref-data/symbols";
			string companyList = string.Empty;
			httpClient.BaseAddress = new Uri(CompaniesApi_End_Point);
			HttpResponseMessage response = httpClient.GetAsync(CompaniesApi_End_Point).GetAwaiter().GetResult();
			if (response.IsSuccessStatusCode)
			{
				companyList = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}
			if (!string.IsNullOrEmpty(companyList))
			{
				companies = JsonConvert.DeserializeObject<List<Company>>(companyList);
			}
			return companies;
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
