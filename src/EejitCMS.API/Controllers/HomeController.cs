using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EejitCms.Api.Controllers
{
	[Route("api/[controller]")]
	public class HomeController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return Ok();
		}
	}
}