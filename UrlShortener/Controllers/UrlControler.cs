namespace UrlShortener.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using UrlShortener.Validation;
    using UrlShortener.Models;
    using UrlShortener.MongoDb;
    using UrlShortener.Services;

    [ApiController]
    [Route("urls")]
    public class UrlControler : ControllerBase
    {
        private readonly IStringValidator _stringValidator;
        private readonly IUrlService _urlService;
        private readonly ILogger _logger;

        public UrlControler(ILogger<UrlControler> logger, IUrlService urlService, IStringValidator stringValidator)
        {
            _logger = logger;
            _urlService = urlService;
            _stringValidator = stringValidator;
        }

        [HttpGet("{shortenedUrl}")]
        public ActionResult<string> Get(string shortenedUrl)
        {
            if (string.IsNullOrEmpty(shortenedUrl))
            {
                return this.StatusCode(400);
            }

            try
            {
                _stringValidator.shortenedUrlValidation(shortenedUrl);
                string response;
                response = _urlService.getUrlByShortenedUrl(shortenedUrl).originalUrl;

                return Redirect(response);

            } catch (Exception e)
            {
                _logger.LogError(e.Message);
                return this.StatusCode(500); 
            }
        }

        [HttpPost]
        [Route("addUrl")]
        public ActionResult<CreateUrlResponse> PostUrl(CreateUrlRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Url))
            {
                return this.StatusCode(400);
            }

            Url response = null;
            _stringValidator.inputUrlValidation(request.Url);

            try
            { 
                response = _urlService.shortenUrl(request.Url);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return this.StatusCode(500);
            }

            string fullUrl = $"{Request.Scheme}://{Request.Host.Value}/" + "urls/" + response.shortenedUrl;
            response.shortenedUrl = fullUrl;
            return this.Ok(response);
        }
    }
}
