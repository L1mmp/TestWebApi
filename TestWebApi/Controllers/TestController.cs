using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		[HttpGet]
		[Route("get")]
		public string GetPage()
		{
			Response.Headers.Append("Access-Control-Allow-Origin", "*");
			return "qwe";
		}
	}
}
