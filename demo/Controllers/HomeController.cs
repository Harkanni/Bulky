using demo.Models;
using demo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IScoppedGuidServices _scopped1;
        private readonly IScoppedGuidServices _scopped2;

        private readonly ITransientGuidService _transient1;
        private readonly ITransientGuidService _transient2;

        private readonly ISingletonGuidService _singleton1;
        private readonly ISingletonGuidService _singleton2;


        public HomeController(IScoppedGuidServices scopedGuild1, IScoppedGuidServices scoppedGuid2,
                              ITransientGuidService transientGuid1, ITransientGuidService transientGuid2,
                              ISingletonGuidService singletonGuid1, ISingletonGuidService singletonGuid2)
        {
            _scopped1 = scopedGuild1;
            _scopped2 = scoppedGuid2;

            _transient1 = transientGuid1;
            _transient2 = transientGuid2;

            _singleton1 = singletonGuid1;
            _singleton2 = singletonGuid2;
        }






        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append($"Scopped 1 : {_scopped1.GetGuid()}\n");
            messages.Append($"Scopped 2 : {_scopped2.GetGuid()}\n\n");

            messages.Append($"Transient 1 : {_transient1.GetGuid()}\n");
            messages.Append($"Transient 2 : {_transient2.GetGuid()}\n\n");

            messages.Append($"Singleton 1 : {_singleton1.GetGuid()}\n");
            messages.Append($"Singleton 2 : {_singleton2.GetGuid()}\n");



            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
