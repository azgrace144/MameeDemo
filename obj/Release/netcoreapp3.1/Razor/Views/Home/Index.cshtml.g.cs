#pragma checksum "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5450347d45106fb4b74f33425b9e1e0a0ccee61d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 73 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
using AppOwnsData.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5450347d45106fb4b74f33425b9e1e0a0ccee61d", @"/Views/Home/Index.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DetailReports>>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5450347d45106fb4b74f33425b9e1e0a0ccee61d3037", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>Power BI Embedded sample</title>

    <link rel=""stylesheet"" href=""/lib/bootstrap/dist/css/bootstrap.min.css"">
    <link rel=""stylesheet"" href=""/css/index.css"">

    <style>

        ul {
            list-style-type: none;
            margin: 0;
            padding: 10px;
            width: 300px;
            background-color: #f1f1f1;
            position: fixed;
            height: 100%;
            overflow: auto;
        }

        li a {
            display: block;
            color: #000;
            padding: 8px 16px;
            text-decoration: none;
        }

        li {
            text-align: center;
        }

            li a.active {
                background-color: #555;
                color: white;
            }

            li a:hover:not(.active) {
                background-colo");
                WriteLiteral("r: #555;\r\n                color: white;\r\n            }\r\n\r\n        section {\r\n            margin-left: 450px;\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5450347d45106fb4b74f33425b9e1e0a0ccee61d5232", async() => {
                WriteLiteral(@"
    <header class=""embed-container col-lg-12 col-md-12 col-sm-12 shadow"">
        <p>
            Power BI Embedded
        </p>
    </header>
    <!--
    <div>
        SELECT REPORT :
        <form>
            <select id=""reportSelect"" style=""width:19.8%; text-align-last:center;"">
                <option selected name=""r1"" value=""2b9d4186-825f-48aa-ba29-1ce284862b78"">Report 1</option>
                <option name=""r2"" value=""92d10f88-da7c-4c02-af5e-822a250e65bc"">Report 2</option>
                <option name=""r3"" value=""b32b7faa-93e5-4331-a1e4-070a7e22e417"">Report 3</option>
                <option name=""r4"" value=""2b9d4186-825f-48aa-ba29-1ce284862b78"">Report 4</option>
            </select>
        </form>
    </div>
    <div id=""testing"">REPORT ID : </div>
    -->
");
                WriteLiteral(@"
    <div>
        <ul>
            <li> <a class=""active"" href=""#home""> Dashboard</a> </li>
            <li> <a href=""Report.cshtml""> Report</a> </li>
            <li> <a href=""#about""> About</a> </li>
            <li>
                <div>
                    REPORT                   
                    <form>
                        <select id=""reportSelect"" style=""width: 100%; text-align-last: center;"">
");
#nullable restore
#line 86 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                             foreach (var report in Model)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <option data-report=\'");
#nullable restore
#line 88 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                                                Write(Json.Serialize(report));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' ");
#nullable restore
#line 88 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                                                                          Write(report == Model.First() ? "selected" : "");

#line default
#line hidden
#nullable disable
                WriteLiteral(" \r\n                                value=\"");
#nullable restore
#line 89 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                                  Write(report.Reports.reportId);

#line default
#line hidden
#nullable disable
                WriteLiteral("\">");
#nullable restore
#line 89 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                                                            Write(report.Reports.name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (");
#nullable restore
#line 89 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                                                                                  Write(report.Roles.name);

#line default
#line hidden
#nullable disable
                WriteLiteral(")</option>\r\n");
#nullable restore
#line 90 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </select>\r\n                    </form>\r\n\r\n                </div>\r\n            </li>\r\n            <li> ID </li>\r\n            <li>\r\n                <div id=\"testing\">");
#nullable restore
#line 98 "C:\AmazingGrace\C#\RealProjects\PBI_Embedded(Meor)\Embed for your customers\AppOwnsData\Views\Home\Index.cshtml"
                             Write(Model[0].Reports.reportId);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</div>
            </li>
        </ul>
    </div>
    <main class=""row"">

        <section id=""report-container"" class=""embed-container col-lg-offset-2 col-lg-9 col-md-offset-3 col-md-9 col-sm-offset-3 col-sm-9 mt-5"">
        
        </section>

        <!-- Used to display report embed error messages -->
        <section class=""error-container m-5"">
        </section>
        <script>
            document.getElementById(""reportSelect"").onchange = function (e) {
                var log = document.getElementById(""testing"");
                console.log(""Log"", this.selectedIndex);
                log.innerHTML = this[this.selectedIndex].value;
                console.log(""Selected Value "", this[this.selectedIndex].value);
            };
        </script>

    </main>

    <footer class=""embed-container col-lg-12 col-md-12 col-sm-12 mb-0 mt-4"">
        <!--<p class=""text-center"">
             For Live demo and more code samples please visit <a href=""https://aka.ms/pbijs"">https://aka.ms/");
                WriteLiteral(@"pbijs</a>
             <br>
             For JavaScript API, please visit <a href=""https://aka.ms/PowerBIjs"">https://aka.ms/PowerBIjs</a>
          </p>-->
    </footer>
    <script src=""/lib/jquery/dist/jquery.min.js""></script>
    <script src=""/lib/bootstrap/dist/js/bootstrap.min.js""></script>
    <script src=""/lib/powerbi-client/dist/powerbi.min.js""></script>
    <script src=""/js/index.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DetailReports>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
