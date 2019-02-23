using EejitCMS.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EejitCMS.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly AccountContext _context;

		public AccountController(AccountContext context)
		{
			_context = context;
		}

		// GET api/account
		[HttpGet]
		public Account Get()
		{
			throw new NotImplementedException ();
		}

		// POST api/acount
		[HttpPost]
		public void Post([FromBody] string value)
		{
			throw new NotImplementedException ();
		}

		// GET api/account/:id
		[HttpGet("{id:string}")]
		public Account Get(string id)
		{
			throw new NotImplementedException ();
		}

		// PUT api/account/:id
		[HttpPut("{id:string}")]
		public void Put(string id, [FromBody] string value)
		{
			throw new NotImplementedException ();
		}

		// DELETE api/account/:id
		[HttpDelete("{id:string}")]
		public void Delete(string id)
		{
			throw new NotImplementedException ();
		}

	}
}
