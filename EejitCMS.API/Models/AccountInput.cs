using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EejitCMS.API.Models
{
	public class AccountInput
	{
		public string Username { get; set; }
		public string Old_Password { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string Email { get; set; }
	}
}
