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
			throw new NotImplementedException ();
		}

		// GET api/media/:id
		[HttpGet("{id}")]
		public Page Get(string id)
		{
			throw new NotImplementedException ();
		}

		// PUT api/media/:id
		[HttpPut("{id}")]
		public void Put(string id, [FromBody] string value)
		{
			throw new NotImplementedException ();
		}

		// DELETE api/media/:id
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			throw new NotImplementedException ();
		}
	}
}
