// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

namespace AppOwnsData.Models
{
    using Microsoft.PowerBI.Api.Models;
    using System.Collections.Generic;

    public class EmbedParams
    {
        // Type of the object to be embedded
        public string Type { get; set; }

        // Report to be embedded
        public List<EmbedReport> EmbedReport { get; set; }

        // Embed Token for the Power BI report
        public List<EmbedToken> EmbedToken { get; set; }
        //public EmbedToken EmbedToken2 { get; set; }
        //public EmbedToken EmbedToken3 { get; set; }
        //public EmbedToken EmbedToken4 { get; set; }
    }
}
