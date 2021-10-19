﻿using Microsoft.AspNetCore.Mvc;
using Tnf;
using Tnf.AspNetCore.Mvc.Response;
using Tnf.Localization;

namespace TOTVSIntegrationCRM.Web.Controllers
{
    /// <summary>
    /// Hello API
    /// </summary>
    [Route("api/hello")]
    [ApiController]
    public class HelloController : TnfController
    {
        private readonly ILocalizationManager localizationManager;

        public HelloController(ILocalizationManager localizationManager)
        {
            this.localizationManager = localizationManager;
        }

        /// <summary>
        /// Get a localized Hello string according with request culture
        /// For change culture sent in headers of request the key <see cref="TnfConsts.Localization.DefaultLanguage"/>
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public IActionResult Get()
        {
            var localizationSource = localizationManager.GetSource(Constants.LocalizationSourceName);

            var localizedHelloMessage = localizationSource.GetString(GlobalizationKey.Hello);

            return Json(localizedHelloMessage);
        }
    }
}
