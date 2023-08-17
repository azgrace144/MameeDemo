
$(function () {
    var models = window["powerbi-client"].models;
    var reportContainer = $("#report-container").get(0);
    // Get the selected report from the dropdown
    $("#reportSelect").on("change", function () {

        var selectedOption = $("#reportSelect option:selected");
        var selectedReport = selectedOption.data("report");

        console.log("selectedRepot", selectedReport)
        var jsonString = JSON.stringify(selectedReport);

        $.ajax({
            type: "GET",
            url: "/embedinfo/getembedinfo",
            data: { reportDetail: jsonString },
            success: function (data) {

                embedParams = $.parseJSON(data);
                console.log("Response Data : ", data);

                reportLoadConfig = {
                    type: "report",
                    tokenType: models.TokenType.Embed,

                    accessToken: embedParams.EmbedToken[0].Token,

                    embedUrl: embedParams.EmbedReport[0].EmbedUrl,

                    TokenExpiry1: embedParams.EmbedToken[0].Expiration,

                    settings: {
                        background: models.BackgroundType.Transparent
                    }
                };

                reportLoadConfig.accessToken = reportLoadConfig.accessToken;
                reportLoadConfig.embedUrl = reportLoadConfig.embedUrl;
                tokenExpiry = reportLoadConfig.TokenExpiry1;
                
                 var report = powerbi.embed(reportContainer, reportLoadConfig);
                // Use the token expiry to regenerate Embed token for seamless end user experience
                // Refer https://aka.ms/RefreshEmbedToken
                tokenExpiry = embedParams.EmbedToken.Expiration;
                // Clear any other loaded handler events
                report.off("loaded");

                // Triggers when a report schema is successfully loaded
                report.on("loaded", function () {
                    console.log("Report load successful");
                });
                // Clear any other rendered handler events
                report.off("rendered");
                // Triggers when a report is successfully embedded in UI
                report.on("rendered", function () {
                    console.log("Report render successful");
                });
                // Clear any other error handler events
                report.off("error");
                // Handle embed errors
                report.on("error", function (event) {
                    var errorMsg = event.detail;

                    // Use errorMsg variable to log error in any destination of choice
                    console.error(errorMsg);
                    return;
                });
            },
            error: function (err) {

                // Show error container
                var errorContainer = $(".error-container");
                $(".embed-container").hide();
                errorContainer.show();

                // Format error message
                var errMessageHtml = "<strong> Error Details: </strong> <br/>" + err.responseText;
                errMessageHtml = errMessageHtml.split("\n").join("<br/>");

                // Show error message on UI
                errorContainer.append(errMessageHtml);
            }
        });
    });

    // Initial load of the Power BI report based on the default selected option
    $("#reportSelect").trigger("change");
});