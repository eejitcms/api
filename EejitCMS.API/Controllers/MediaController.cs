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
	public class MediaController : ControllerBase
	{
		// POST api/media
		[HttpPost]
		public void Post([FromBody] string value)
		{
			throw new NotFiniteNumberException ();
		}

		// GET api/media/:id
		[HttpGet("{id:string}")]
		public Page Get(string id)
		{
			throw new NotFiniteNumberException ();
		}

		// PUT api/media/:id
		[HttpPut("{id:string}")]
		public void Put(string id, [FromBody] string value)
		{
			throw new NotFiniteNumberException ();
		}

		// DELETE api/media/:id
		[HttpDelete("{id:string}")]
		public void Delete(string id)
		{
			throw new NotFiniteNumberException ();
		}
	}
}
