using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Services.Abstraction;
using BusinessLayer.Models;
using System;
using System.Threading.Tasks;
using UrlShortener.Models;

namespace Test.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IUrlService _urlService;
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlValidatorService _validatorService;

        public HomeController(IUrlService urlService, IUrlValidatorService validatorService, ILogger<HomeController> logger)
        {
            _urlService = urlService;
            _logger = logger;
            _validatorService = validatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("GetShortenedUrl")]
        public async Task<IActionResult> GetShortenedUrl(string originalUrl)
        {
            ShortUri shortUrl = null;

            //Validation
            var validationResult = _validatorService.ValidateUrl(originalUrl);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToString());
            }

            // Retrieve original URL
            try
            {
                shortUrl = await _urlService.CreateShortUrlAsync(originalUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            var vm = new ShortUrlViewModel
            {
                ShortenedUrl = shortUrl.ShortenedUrl,
                FormattedExpiryDate = shortUrl.FormattedExpiryDate
            };

            return Ok(vm);
        }
    }
}
