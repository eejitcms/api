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
	public class PageController : ControllerBase
	{
		// GET api/page
		[HttpGet]
		public Page Get()
		{
			throw new NotImplementedException ();
		} 

		// POST api/page
		[HttpPost]
		public void Post([FromBody] string value)
		{
			throw new NotImplementedException ();
		}

		// GET api/page/:slug
		[HttpGet("{slug:string}")]
		public Page Get(string slug)
		{
			throw new NotImplementedException ();
		}

		// PUT api/page/:slug
		[HttpPut("{slug:string}")]
		public void Put(string slug, [FromBody] string value)
		{
			throw new NotImplementedException ();
		}

		// DELETE api/page/:slug
		[HttpDelete("{slug:string}")]
		public void Delete(string slug)
		{
			throw new NotImplementedException ();
		}
	}
}
