using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EejitCMS.API.Controllers
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