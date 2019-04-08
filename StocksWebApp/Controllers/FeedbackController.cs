using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StocksWebApp.Models;

namespace StocksWebApp.Controllers
{
    public class FeedbackController : Controller
    {
		bool isSaved = false;
		private readonly IRepository _repository;

		public FeedbackController(IRepository repository)
		{
			_repository = repository;
	
		}
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public IActionResult Index(Feedback feedback)
		{
			isSaved = _repository.SaveFeedback(feedback);
			return RedirectToAction("Feedback");
		}

		public IActionResult Feedback()
		{
			if (isSaved)
			{
				@ViewBag.Message = "Thank you for providing your feedback";
			}
			return View(@ViewBag.Message);
		}
	}
}