// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

namespace AppOwnsData.Services
{
    using AppOwnsData.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.PowerBI.Api;
    using Microsoft.PowerBI.Api.Models;
    using Microsoft.Rest;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class PbiEmbedService
    {
        private readonly AadService aadService;
        private readonly string powerBiApiUrl = "https://api.powerbi.com";
        private readonly IConfiguration _config;


        public PbiEmbedService(AadService aadService, IConfiguration config)
        {
            this.aadService = aadService;
            _config = config;
        }

        /// <summary>
        /// Get Power BI client
        /// </summary>
        /// <returns>Power BI client object</returns>
        public PowerBIClient GetPowerBIClient()
        {
            var tokenCredentials = new TokenCredentials(aadService.GetAccessToken(), "Bearer");
            return new PowerBIClient(new Uri(powerBiApiUrl), tokenCredentials);
        }

        /// <summary>
        /// Get embed params for a report
        /// </summary>
        /// <returns>Wrapper object containing Embed token, Embed URL, Report Id, and Report name for single report</returns>
        public EmbedParams GetEmbedParamsOriginal(Guid workspaceId, Guid reportId, Guid reportId2, Guid reportId3, Guid reportId4, [Optional] Guid additionalDatasetId)
        {
            PowerBIClient pbiClient = this.GetPowerBIClient();

            // Get report info
            //var pbiRlsReport1 = pbiClient.Reports.GetReportInGroup(workspaceId, rlsReportId1);
            //var pbiRlsReport2 = pbiClient.Reports.GetReportInGroup(workspaceId, rlsReportId2);

            var pbiReport = pbiClient.Reports.GetReportInGroup(workspaceId, reportId);
            var pbiReport2 = pbiClient.Reports.GetReportInGroup(workspaceId, reportId2);
            var pbiReport3 = pbiClient.Reports.GetReportInGroup(workspaceId, reportId3);
            var pbiReport4 = pbiClient.Reports.GetReportInGroup(workspaceId, reportId4);

            //  Check if dataset is present for the corresponding report
            ////  If isRDLReport is true then it is a RDL Report 
            //var isRDLRlsReport1 = String.IsNullOrEmpty(pbiRlsReport1.DatasetId);
            //var isRDLRlsReport2 = String.IsNullOrEmpty(pbiRlsReport2.DatasetId);

            var isRDLReport = String.IsNullOrEmpty(pbiReport.DatasetId);
            var isRDLReport2 = String.IsNullOrEmpty(pbiReport2.DatasetId);
            var isRDLReport3 = String.IsNullOrEmpty(pbiReport3.DatasetId);
            var isRDLReport4 = String.IsNullOrEmpty(pbiReport4.DatasetId);

            //rlsEmbedToken1,rlsEmbedToken2,
            EmbedToken embedToken, embedToken2, embedToken3, embedToken4;

            // Generate embed token for RDL report if dataset is not present
            if (isRDLReport || isRDLReport2 || isRDLReport3 || isRDLReport4)
            {
                // Get Embed token for RDL Report

                //rlsEmbedToken1 = GetEmbedTokenForRDLReport(workspaceId, rlsReportId1);
                //rlsEmbedToken2 = GetEmbedTokenForRDLReport(workspaceId, rlsReportId2);

                embedToken = GetEmbedTokenForRDLReport(workspaceId, reportId);
                embedToken2 = GetEmbedTokenForRDLReport(workspaceId, reportId2);
                embedToken3 = GetEmbedTokenForRDLReport(workspaceId, reportId3);
                embedToken4 = GetEmbedTokenForRDLReport(workspaceId, reportId4);
            }
            else
            {
                // Create list of datasets

                //var rlsDatasetIds1 = new List<Guid>();
                //var rlsDatasetIds2 = new List<Guid>();

                var datasetIds = new List<Guid>();
                var datasetIds2 = new List<Guid>();
                var datasetIds3 = new List<Guid>();
                var datasetIds4 = new List<Guid>();

                //// Add dataset associated to the report
                //rlsDatasetIds1.Add(Guid.Parse(pbiRlsReport1.DatasetId));
                //rlsDatasetIds2.Add(Guid.Parse(pbiRlsReport2.DatasetId));

                datasetIds.Add(Guid.Parse(pbiReport.DatasetId));
                datasetIds2.Add(Guid.Parse(pbiReport2.DatasetId));
                datasetIds3.Add(Guid.Parse(pbiReport3.DatasetId));
                datasetIds4.Add(Guid.Parse(pbiReport4.DatasetId));

                // Append additional dataset to the list to achieve dynamic binding later
                if (additionalDatasetId != Guid.Empty)
                {
                    datasetIds.Add(additionalDatasetId);
                }

                //// Get Embed token multiple resources
                //rlsEmbedToken1 = GetEmbedToken(rlsReportId1, rlsDatasetIds1, workspaceId);
                //rlsEmbedToken2 = GetEmbedToken(rlsReportId2, rlsDatasetIds2, workspaceId);

                embedToken = GetEmbedTokenWithoutRLS(reportId, datasetIds, workspaceId);
                embedToken2 = GetEmbedTokenWithoutRLS(reportId2, datasetIds2, workspaceId);
                embedToken3 = GetEmbedTokenWithoutRLS(reportId3, datasetIds3, workspaceId);
                embedToken4 = GetEmbedTokenWithoutRLS(reportId4, datasetIds4, workspaceId);


            }

            // Add report data for embedding
            var embedReports = new List<EmbedReport>() {
                new EmbedReport
                {
                    //RlsReportId1=pbiRlsReport1.Id,RlsReportName1=pbiRlsReport1.Name,RlsEmbedUrl1=pbiRlsReport1.EmbedUrl,
                    //RlsReportId2=pbiRlsReport1.Id,RlsReportName2=pbiRlsReport1.Name,RlsEmbedUrl2=pbiRlsReport1.EmbedUrl,

                    ReportId = pbiReport.Id, ReportName = pbiReport.Name, EmbedUrl = pbiReport.EmbedUrl,
                    ReportId2 = pbiReport2.Id, ReportName2 = pbiReport2.Name, EmbedUrl2 = pbiReport2.EmbedUrl,
                    ReportId3 = pbiReport3.Id, ReportName3 = pbiReport3.Name, EmbedUrl3 = pbiReport3.EmbedUrl,
                    ReportId4 = pbiReport4.Id, ReportName4 = pbiReport4.Name, EmbedUrl4 = pbiReport4.EmbedUrl
                }
            };

            var embedTokens = new List<EmbedToken>
            {
                //rlsEmbedToken1,rlsEmbedToken2,
                embedToken, embedToken2, embedToken3, embedToken4
            };

            // Capture embed params
            var embedParams = new EmbedParams
            {
                EmbedReport = embedReports,
                Type = "Report",
                EmbedToken = embedTokens
                //EmbedToken2 = embedToken2,
                //EmbedToken3 = embedToken3,
                //EmbedToken4 = embedToken4
            };

            return embedParams;
        }


        public EmbedParams GetEmbedParams(Guid workspaceId, Guid reportId,string email,string roleName,string dataset_id, [Optional] Guid additionalDatasetId)
        {
            PowerBIClient pbiClient = this.GetPowerBIClient();

            // Get report info

            var pbiReport = pbiClient.Reports.GetReportInGroup(workspaceId, reportId);

            var isRDLReport = String.IsNullOrEmpty(pbiReport.DatasetId);

            //rlsEmbedToken1,rlsEmbedToken2,
            EmbedToken embedToken;

            // Generate embed token for RDL report if dataset is not present
            if (isRDLReport)
            {
                // Get Embed token for RDL Report

                embedToken = GetEmbedTokenForRDLReport(workspaceId, reportId);
                
            }
            else
            {
                // Create list of datasets

                var datasetIds = new List<Guid>();
                
                datasetIds.Add(Guid.Parse(pbiReport.DatasetId));

                // Append additional dataset to the list to achieve dynamic binding later
                if (additionalDatasetId != Guid.Empty)
                {
                    datasetIds.Add(additionalDatasetId);
                }

                embedToken = GetEmbedToken(reportId, datasetIds, email, roleName, dataset_id, workspaceId);
               
            }

            // Add report data for embedding
            var embedReports = new List<EmbedReport>() {
                new EmbedReport
                {
                    ReportId = pbiReport.Id, ReportName = pbiReport.Name, EmbedUrl = pbiReport.EmbedUrl,
                   
                }
            };

            var embedTokens = new List<EmbedToken>
            {
                embedToken
            };

            // Capture embed params
            var embedParams = new EmbedParams
            {
                EmbedReport = embedReports,
                Type = "Report",
                EmbedToken = embedTokens
               
            };

            return embedParams;
        }

        /// <summary>
        /// Get embed params for multiple reports for a single workspace
        /// </summary>
        /// <returns>Wrapper object containing Embed token, Embed URL, Report Id, and Report name for multiple reports</returns>
        /// <remarks>This function is not supported for RDL Report</remakrs>
        public EmbedParams GetEmbedParams(Guid workspaceId, IList<Guid> reportIds, [Optional] IList<Guid> additionalDatasetIds)
        {
            PowerBIClient pbiClient = this.GetPowerBIClient();

            // Create mapping for reports and Embed URLs
            var embedReports = new List<EmbedReport>();

            // Create list of datasets
            var datasetIds = new List<Guid>();

            // Get datasets and Embed URLs for all the reports
            foreach (var reportId in reportIds)
            {
                // Get report info
                var pbiReport = pbiClient.Reports.GetReportInGroup(workspaceId, reportId);

                //  Check if dataset is present for the corresponding report
                //  If isRDLReport is true then it is an RDL Report 
                var isRDLReport = String.IsNullOrEmpty(pbiReport.DatasetId);

                if (isRDLReport)
                {
                    // Handle RDL Reports separately
                    // You can choose to skip RDL Reports or handle them differently
                    continue;
                }

                datasetIds.Add(Guid.Parse(pbiReport.DatasetId));

                // Add report data for embedding
                embedReports.Add(new EmbedReport { ReportId = pbiReport.Id, ReportName = pbiReport.Name, EmbedUrl = pbiReport.EmbedUrl });
            }

            // Append to existing list of datasets to achieve dynamic binding later
            if (additionalDatasetIds != null)
            {
                datasetIds.AddRange(additionalDatasetIds);
            }

            // Get Embed token for multiple reports and datasets
            var embedToken = GetEmbedToken(reportIds, datasetIds, workspaceId);

            // Capture embed params
            var embedParams = new EmbedParams
            {
                EmbedReport = embedReports,
                Type = "Report",
                EmbedToken = embedToken
            };

            return embedParams;
        }

        /// <summary>
        /// Get Embed token for single report, multiple datasets, and an optional target workspace
        /// </summary>
        /// <returns>Embed token</returns>
        /// <remarks>This function is not supported for RDL Report</remakrs>
        /// 

        // Original 
        //public EmbedToken GetEmbedToken(Guid reportId, IList<Guid> datasetIds, [Optional] Guid targetWorkspaceId)
        //{
        //    PowerBIClient pbiClient = this.GetPowerBIClient();

        //    // Create a request for getting Embed token 
        //    // This method works only with new Power BI V2 workspace experience
        //    var tokenRequest = new GenerateTokenRequestV2(

        //        reports: new List<GenerateTokenRequestV2Report>() { new GenerateTokenRequestV2Report(reportId) },

        //        datasets: datasetIds.Select(datasetId => new GenerateTokenRequestV2Dataset(datasetId.ToString())).ToList(),

        //        targetWorkspaces: targetWorkspaceId != Guid.Empty ? new List<GenerateTokenRequestV2TargetWorkspace>() { new GenerateTokenRequestV2TargetWorkspace(targetWorkspaceId) } : null
        //    );

        //    // Generate Embed token
        //    var embedToken = pbiClient.EmbedToken.GenerateToken(tokenRequest);

        //    return embedToken;
        //}

        // Amaing Grace Edit
        //main
        public EmbedToken GetEmbedToken(Guid reportId, IList<Guid> datasetIds, string email, string roleName, string dataset_id, [Optional] Guid targetWorkspaceId)
        {
            PowerBIClient pbiClient = this.GetPowerBIClient();

            var rlsIdentity = new EffectiveIdentity(
                username: email,
                roles: new List<string> { roleName },
                datasets: new List<string> {dataset_id}
            );

            var tokenRequest = new GenerateTokenRequestV2(
                reports: new List<GenerateTokenRequestV2Report>() { new GenerateTokenRequestV2Report(reportId) },
                datasets: datasetIds.Select(datasetId => new GenerateTokenRequestV2Dataset(datasetId.ToString())).ToList(),
                targetWorkspaces: targetWorkspaceId != Guid.Empty ? new List<GenerateTokenRequestV2TargetWorkspace>() { new GenerateTokenRequestV2TargetWorkspace(targetWorkspaceId) } : null,
                identities: new List<EffectiveIdentity> { rlsIdentity }
            );

            // Generate an embed token
            var embedToken = pbiClient.EmbedToken.GenerateToken(tokenRequest);

            Console.WriteLine("embedToken :"+embedToken);

            return embedToken;
        }

        public EmbedToken GetEmbedTokenFine(Guid reportId, IList<Guid> datasetIds, [Optional] Guid targetWorkspaceId)
        {
            PowerBIClient pbiClient = this.GetPowerBIClient();

            var accessLevel = _config.GetValue<string>("accessLevel");
            string username = _config["identities:0:username"];
            var roles = _config.GetSection("identities:0:roles").Get<List<string>>();
            var datasets = _config.GetSection("identities:0:datasets").Get<List<string>>();

            // Defines the user identity and roles.
            //var rlsIdentity = new EffectiveIdentity(
            //    username: "amazing@evo-point.com",
            //    roles: new List<string> { "RLS Test" },
            //    datasets: new List<string> { "ad733dbc-9d8e-4397-9456-92cf80be1283" }
            //);

            IConfigurationSection identitiesSection = _config.GetSection("identities");
            int length = identitiesSection.GetChildren().Count();

            foreach (var childSection in identitiesSection.GetChildren())
            {
                 username = childSection["username"];
                 roles = childSection.GetSection("roles").Get<List<string>>();
                 datasets = childSection.GetSection("datasets").Get<List<string>>();
            }
            Console.WriteLine(username,roles,datasets);

            var rlsIdentity = new EffectiveIdentity(
                username: username,
                roles: roles,
                datasets: datasets
            );

            //List<EffectiveIdentity> effectList = new List<EffectiveIdentity>();
            //effectList.Add(rlsIdentity);

            //// Create a request for getting an embed token for the rls identity defined above
            //var tokenRequest = new GenerateTokenRequestV2(
            //    reports: new List<GenerateTokenRequestV2Report>() { new GenerateTokenRequestV2Report(reportId) },
            //    datasets: datasetIds.Select(datasetId => new GenerateTokenRequestV2Dataset(datasetId.ToString())).ToList(),
            //    targetWorkspaces: targetWorkspaceId != Guid.Empty ? new List<GenerateTokenRequestV2TargetWorkspace>() { new GenerateTokenRequestV2TargetWorkspace(targetWorkspaceId) } : null,
            //    identities: effectList
            //);

            // Generate an embed token
            //var embedToken = pbiClient.EmbedToken.GenerateToken(tokenRequest);

            var generateTokenRequestParameters = new GenerateTokenRequest(accessLevel: "View", identities: new List<EffectiveIdentity> { rlsIdentity });
            var embedToken = pbiClient.Reports.GenerateTokenInGroup(targetWorkspaceId, reportId, generateTokenRequestParameters);

            Console.WriteLine("Embed Token : ", embedToken, accessLevel, datasets, username);

            return embedToken;

        }

        //news

        public EmbedToken GetEmbedTokenWithoutRLS(Guid reportId, IList<Guid> datasetIds, [Optional] Guid targetWorkspaceId)
        {
            PowerBIClient pbiClient = this.GetPowerBIClient();

            var tokenRequest = new GenerateTokenRequestV2(

                reports: new List<GenerateTokenRequestV2Report>() { new GenerateTokenRequestV2Report(reportId) },

                datasets: datasetIds.Select(datasetId => new GenerateTokenRequestV2Dataset(datasetId.ToString())).ToList(),

                targetWorkspaces: targetWorkspaceId != Guid.Empty ? new List<GenerateTokenRequestV2TargetWorkspace>() { new GenerateTokenRequestV2TargetWorkspace(targetWorkspaceId) } : null
            );

            // Generate Embed token
            var embedToken = pbiClient.EmbedToken.GenerateToken(tokenRequest);

            Console.WriteLine("EmbedToken", embedToken);

            return embedToken;
        }

        /// <summary>
        /// Get Embed token for multiple reports, datasets, and an optional target workspace
        /// </summary>
        /// <returns>Embed token</returns>
        /// <remarks>This function is not supported for RDL Report</remakrs>
        public List<EmbedToken> GetEmbedToken(IList<Guid> reportIds, IList<Guid> datasetIds, [Optional] Guid targetWorkspaceId)
        {
            // Note: This method is an example and is not consumed in this sample app

            PowerBIClient pbiClient = this.GetPowerBIClient();

            // Convert report Ids to required types
            var reports = reportIds.Select(reportId => new GenerateTokenRequestV2Report(reportId)).ToList();

            // Convert dataset Ids to required types
            var datasets = datasetIds.Select(datasetId => new GenerateTokenRequestV2Dataset(datasetId.ToString())).ToList();

            // Create a request for getting Embed token 
            // This method works only with new Power BI V2 workspace experience
            var tokenRequest = new GenerateTokenRequestV2(

                datasets: datasets,

                reports: reports,

                targetWorkspaces: targetWorkspaceId != Guid.Empty ? new List<GenerateTokenRequestV2TargetWorkspace>() { new GenerateTokenRequestV2TargetWorkspace(targetWorkspaceId) } : null
            );

            // Generate Embed token
            var embedToken = pbiClient.EmbedToken.GenerateToken(tokenRequest);

            List<EmbedToken> embedTokens = new List<EmbedToken>();

            embedTokens.Add(embedToken);

            return embedTokens;
        }

        /// <summary>
        /// Get Embed token for multiple reports, datasets, and optional target workspaces
        /// </summary>
        /// <returns>Embed token</returns>
        /// <remarks>This function is not supported for RDL Report</remakrs>
        public EmbedToken GetEmbedToken(IList<Guid> reportIds, IList<Guid> datasetIds, [Optional] IList<Guid> targetWorkspaceIds)
        {
            // Note: This method is an example and is not consumed in this sample app

            PowerBIClient pbiClient = this.GetPowerBIClient();

            // Convert report Ids to required types
            var reports = reportIds.Select(reportId => new GenerateTokenRequestV2Report(reportId)).ToList();

            // Convert dataset Ids to required types
            var datasets = datasetIds.Select(datasetId => new GenerateTokenRequestV2Dataset(datasetId.ToString())).ToList();

            // Convert target workspace Ids to required types
            IList<GenerateTokenRequestV2TargetWorkspace> targetWorkspaces = null;
            if (targetWorkspaceIds != null)
            {
                targetWorkspaces = targetWorkspaceIds.Select(targetWorkspaceId => new GenerateTokenRequestV2TargetWorkspace(targetWorkspaceId)).ToList();
            }

            // Create a request for getting Embed token 
            // This method works only with new Power BI V2 workspace experience
            var tokenRequest = new GenerateTokenRequestV2(

                datasets: datasets,

                reports: reports,

                targetWorkspaces: targetWorkspaceIds != null ? targetWorkspaces : null
            );

            // Generate Embed token
            var embedToken = pbiClient.EmbedToken.GenerateToken(tokenRequest);

            return embedToken;
        }


        /// <summary>
        /// Get Embed token for RDL Report
        /// </summary>
        /// <returns>Embed token</returns>
        public EmbedToken GetEmbedTokenForRDLReport(Guid targetWorkspaceId, Guid reportId, string accessLevel = "view")
        {
            PowerBIClient pbiClient = this.GetPowerBIClient();

            // Generate token request for RDL Report
            var generateTokenRequestParameters = new GenerateTokenRequest(
                accessLevel: accessLevel
            );

            // Generate Embed token
            var embedToken = pbiClient.Reports.GenerateTokenInGroup(targetWorkspaceId, reportId, generateTokenRequestParameters);

            return embedToken;
        }
    }
}
