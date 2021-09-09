using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BusinessLayer.Services.Abstraction;
using System;
using System.Threading.Tasks;

namespace Test.Controllers
{
    public class RedirectController : ControllerBase
    {
        private readonly IUrlService _urlService;
        private readonly ILogger<RedirectController> _logger;

        public RedirectController(IUrlService urlService, ILogger<RedirectController> logger)
        {
            _urlService = urlService;
            _logger = logger;
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest();    //Note: This should never happen
            }

            // Get original URL
            string originalUrl;
            try
            {
                originalUrl = await _urlService.GetOriginalUrlAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }

            return Redirect(originalUrl);
        }
    }
}
