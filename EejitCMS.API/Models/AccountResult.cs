using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EejitCMS.API.Models
{
	public class AccountResult
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }

		public DateTime CreatedOn { get; set; }
		public DateTime LastLogin { get; set; }

		public bool EmailVerified { get; set; }

		public AccountResult(Account account)
		{
			Id = account.Id;
			Username = account.Username;
			Email = account.Email;

			CreatedOn = account.CreatedOn;
			LastLogin = account.LastLogin;

			EmailVerified = account.EmailVerified;
		}
	}
}
