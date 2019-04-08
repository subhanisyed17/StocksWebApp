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

		[HttpPost]
		public IActionResult CompanyQuote(CompanyQuote companyQuote)
		{
			TempData["Symbol"] = companyQuote.Symbol.Trim();
			return RedirectToAction("GetCompanyQuote");
		}

		public IActionResult GetCompanyQuote()
		{
			string symbol = TempData["Symbol"] as string;
			CompanyQuote companyQuote = GetCompanyQuote(symbol);
			_repository.SaveCompanyQuote(companyQuote);
			return View(companyQuote);
		}

		private CompanyQuote GetCompanyQuote(string symbol)
		{
			CompanyQuote cQ = new CompanyQuote();
			string CompanyQuote_End_Point = BASE_URL + "stock/"+symbol+"/book";
			string apiResponse = string.Empty;
			httpClient.BaseAddress = new Uri(CompanyQuote_End_Point);
			HttpResponseMessage response = httpClient.GetAsync(CompanyQuote_End_Point).GetAwaiter().GetResult();
			if (response.IsSuccessStatusCode)
			{
				apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}
			if (!string.IsNullOrEmpty(apiResponse))
			{
				cQ = JsonConvert.DeserializeObject<CompanyQuote>(apiResponse);
			}
			return cQ;
		}

		[HttpPost]
		public IActionResult CompanyDetails(string symbol)
		{
			detailsOfCompany = GetCompanyDetails(symbol);
			_repository.SaveCompanyDetails(detailsOfCompany);
			TempData["CompanyDetails"] = detailsOfCompany;
			return RedirectToAction("/Home/GetCompanyInfo");
		}

		public IActionResult GetCompanyInfo()
		{
			CompanyDetails companyInformation = TempData["CompanyDetails"] as CompanyDetails;
			return View(companyInformation);
		}
		private CompanyDetails GetCompanyDetails(string symbol)
		{
			CompanyDetails cD = new CompanyDetails();
			string CompanyDetails_End_Point = BASE_URL + "stock/" + symbol + "/company";
			string apiResponse = string.Empty;
			httpClient.BaseAddress = new Uri(CompanyDetails_End_Point);
			HttpResponseMessage response = httpClient.GetAsync(CompanyDetails_End_Point).GetAwaiter().GetResult();
			if (response.IsSuccessStatusCode)
			{
				apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}
			if (!string.IsNullOrEmpty(apiResponse))
			{
				cD = JsonConvert.DeserializeObject<CompanyDetails>(apiResponse);
			}
			return cD;
		}


		[HttpPost]
		public IActionResult CompanyDividends(CompanyDividend companyDividends)
		{
			dividendsOfCompany = GetCompanyDividend(companyDividends.Symbol);
			_repository.SaveCompanyLatestDividend(dividendsOfCompany);
			TempData["CompanyDividends"] = dividendsOfCompany;
			return RedirectToAction("/Home/GetCompanyDividend");
		}

		public IActionResult GetCompanyDividend()
		{
			List<CompanyDividend> companyDiv = TempData["CompanyDividends"] as List<CompanyDividend>;
			return View(companyDiv);
		}
		private List<CompanyDividend> GetCompanyDividend(string symbol)
		{
			List<CompanyDividend> cDividends = new List<CompanyDividend>();
			string CompanyDividends_End_Point = BASE_URL + "stock/" + symbol + "/dividends/1y";
			string apiResponse = string.Empty;
			httpClient.BaseAddress = new Uri(CompanyDividends_End_Point);
			HttpResponseMessage response = httpClient.GetAsync(CompanyDividends_End_Point).GetAwaiter().GetResult();
			if (response.IsSuccessStatusCode)
			{
				apiResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			}
			if (!string.IsNullOrEmpty(apiResponse))
			{
				cDividends = JsonConvert.DeserializeObject<List<CompanyDividend>>(apiResponse);
			}
			return cDividends;
		}

		[HttpPost]
		public IActionResult Feedback(Feedback feedback)
		{
			isSaved = _repository.SaveFeedback(feedback);
			return RedirectToAction("/Home/FeedbackOutput");
		}

		public IActionResult FeedbackOutput()
		{
			if (isSaved)
			{
				@ViewBag.Message = "Thank you for providing your feedback";
			}
			return View(@ViewBag.Message);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
