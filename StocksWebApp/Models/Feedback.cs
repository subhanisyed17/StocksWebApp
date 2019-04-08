using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StocksWebApp.Models
{
	public class Feedback
	{
		[Key]
		public string FeedbackId { get; set; }

		public string Name { get; set; }

		public string EmailId { get; set; }
		public string FeedbackMessage { get; set; }
	}
}
