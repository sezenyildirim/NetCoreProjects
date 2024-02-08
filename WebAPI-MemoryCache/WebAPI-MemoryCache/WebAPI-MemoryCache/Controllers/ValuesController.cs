using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPI_MemoryCache.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IMemoryCache _memoryCache;

		public ValuesController(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

		[HttpGet]
		public IActionResult Get()
		{
			//_memoryCache.Remove("names");//cache temizlemek için
			List<string> names = new();
			names = _memoryCache.Get<List<string>>("names");
			if (names == null)
			{
				names = new(){
				"Test1",
				"Test2",
				"Test3",
				"Test4",
				"Test5",
				"Test6",
				"Test7",
			};
				Thread.Sleep(3000);
				_memoryCache.Set("names", names);
				_memoryCache.Set("names", names,TimeSpan.FromSeconds(5));//cache'ledikten 5 sn sonra veriyi cache'den siler
			}
			return Ok(names);

		}
	}
}
