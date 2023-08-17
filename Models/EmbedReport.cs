// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

namespace AppOwnsData.Models
{
    using System;

    public class EmbedReport
    {
        // Id of Power BI report to be embedded

        //public Guid RlsReportId1 { get; set; }
        //public Guid RlsReportId2 { get; set; }

        public Guid ReportId { get; set; }
        public Guid ReportId2 { get; internal set; }
        public Guid ReportId3 { get; internal set; }
        public Guid ReportId4 { get; internal set; }

        // Name of the report
        //public string RlsReportName1 { get; set; }
        //public string RlsReportName2 { get; set; }
        public string ReportName { get; set; }
        public string ReportName2 { get; set; }
        public string ReportName3 { get; set; }
        public string ReportName4 { get; set; }

        // Embed URL for the Power BI report

        //public string RlsEmbedUrl1 { get; set; }
        //public string RlsEmbedUrl2 { get; set; }
        public string EmbedUrl { get; set; }
        public string EmbedUrl2 { get; set; }
        public string EmbedUrl3 { get; set; }
        public string EmbedUrl4 { get; set; }
    }
}
