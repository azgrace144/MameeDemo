// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

namespace AppOwnsData.Controllers
{
    using AppOwnsData.DB;
    using AppOwnsData.Models;
    using AppOwnsData.Services;
    using AppOwnsData.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class EmbedInfoController : Controller
    {
        private readonly PbiEmbedService pbiEmbedService;
        private readonly IOptions<AzureAd> azureAd;
        private readonly IOptions<PowerBI> powerBI;

        private readonly AppDbcontext _dbcontext;

        public EmbedInfoController(PbiEmbedService pbiEmbedService, IOptions<AzureAd> azureAd, IOptions<PowerBI> powerBI,AppDbcontext dbcontext)
        {
            this.pbiEmbedService = pbiEmbedService;
            this.azureAd = azureAd;
            this.powerBI = powerBI;
            this._dbcontext= dbcontext;
        }


        /// <summary>
        /// Returns Embed token, Embed URL, and Embed token expiry to the client
        /// </summary>
        /// <returns>JSON containing parameters for embedding</returns>
        [HttpGet]
        public string GetEmbedInfo( string reportDetail)
        {
            string email = TempData["email"] as string;
            TempData.Keep("email");

            var selectedReport = JsonConvert.DeserializeObject<DetailReports>(reportDetail);

            var report_id = selectedReport.Reports.reportId;
            var dataset_id = selectedReport.Reports.datasetId;
            var roleName = selectedReport.Roles.name;

            try
            {
                // Validate whether all the required configurations are provided in appsettings.json
                string configValidationResult = ConfigValidatorService.ValidateConfig(azureAd, powerBI);
                if (configValidationResult != null)
                {
                    HttpContext.Response.StatusCode = 400;
                    return configValidationResult;
                }

                EmbedParams embedParams = pbiEmbedService.GetEmbedParams(new Guid(powerBI.Value.WorkspaceId), new Guid(report_id),email,roleName,dataset_id);              
                
                return System.Text.Json.JsonSerializer.Serialize<EmbedParams>(embedParams);
            }
            catch (HttpOperationException httpEx)
            {
                HttpContext.Response.StatusCode = 500;
                return string.Join("\n\n", new[] { httpEx.Message, httpEx.Response.Content, httpEx.StackTrace });
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                return ex.Message + "\n\n" + ex.StackTrace;
            }
        }

    }
}
