using EejitCMS.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EejitCMS.API.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly AccountContext _context;

		public AccountController(AccountContext context)
		{
			_context = context;

			if (_context.Accounts.Count() == 0)
			{
				// Add admin account if no other accounts exist
				Account admin = new Account ()
				{
					Username = "admin",
					Email = "admin@example.com",
					CreatedOn = DateTime.UtcNow,
					EmailVerified = true
				};
				admin.TrySetPassword ("changeme", out string reason);

				_context.Add (admin);
				_context.SaveChanges ();
			}
		}

		// GET api/account
		[HttpGet]
		public async Task<IEnumerable<AccountResult>> Get()
		{
			var accounts = await _context.Accounts.ToListAsync ();
			return accounts.Select(a => new AccountResult(a));
		}

		// POST api/account
		[HttpPost]
		public async Task<IActionResult> Post(AccountInput account)
		{
			Account search = await _context.Accounts.FirstOrDefaultAsync (acc => acc.Username == account.Username);
			if (search != null) return BadRequest (new {
				Message = "A user with the given username already exists"
			});
			if (account.Password != account.ConfirmPassword) return BadRequest (new {
				Message = "Passwords do not match"
			});

			Account new_account = new Account ()
			{
				Username = account.Username,
				Email = account.Email,
				CreatedOn = DateTime.UtcNow
			};

			if (!new_account.TrySetPassword (account.Password, out string reason)) return BadRequest(new {
				Message = $"Failed to set password [{reason}]"
			});

			_context.Accounts.Add (new_account);
			await _context.SaveChangesAsync ();
			return CreatedAtAction (nameof (Get), new { id = new_account.Username }, new AccountResult(new_account));
		}

		// GET api/account/:id
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(string id)
		{
			Account search = await _context.Accounts.FirstOrDefaultAsync (acc => acc.Username == id);
			if (search == null) return NotFound (new { Message = "A user with the given username doesn't exists" });
			return Ok (new AccountResult(search));
		}

		// PUT api/account/:id
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(string id, AccountInput accountInput)
		{
			Account search = await _context.Accounts.FirstOrDefaultAsync (acc => acc.Username == id);
			if (search == null) return NotFound (new { Message = "A user with the given username doesn't exists" });
			
			// Update Email if new email provided and set email verified correctly
			search.Email = accountInput.Email ?? search.Email;
			search.EmailVerified = (accountInput.Email == null) == search.EmailVerified; 

			if (accountInput.Password != null && accountInput.Old_Password != null)
			{
				// Check old password is correct
				if (!search.IsPassword (accountInput.Old_Password))
					return BadRequest (new { Message = "Incorrect Password" });

				// Check new passwords match
				if (accountInput.Password != accountInput.ConfirmPassword)
					return BadRequest (new { Message = "Passwords do not match" });

				// Try set new password
				if (!search.TrySetPassword (accountInput.Password, out string reason))
					return BadRequest (new { Message = $"Failed to set password [{reason}]" });
			}

			await _context.SaveChangesAsync ();
			return Ok (new AccountResult(search));
		}

		// DELETE api/account/:id
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			Account search = await _context.Accounts.FirstOrDefaultAsync (acc => acc.Username == id);
			if (search == null) return NotFound(new { Message = "A user with the given username doesn't exists" });
			_context.Accounts.Remove (search);
			await _context.SaveChangesAsync ();
			return Ok (new { Message = "Successfully deleted user" });
		}
	}
}
