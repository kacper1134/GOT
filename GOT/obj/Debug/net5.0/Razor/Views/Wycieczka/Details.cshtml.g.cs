#pragma checksum "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93b94af62155263b7502395bd77718016143169c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wycieczka_Details), @"mvc.1.0.view", @"/Views/Wycieczka/Details.cshtml")]
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
#line 1 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\_ViewImports.cshtml"
using GOT;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\_ViewImports.cshtml"
using GOT.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93b94af62155263b7502395bd77718016143169c", @"/Views/Wycieczka/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bab7eab681533ea974c0065c885cfc63e5e5921a", @"/Views/_ViewImports.cshtml")]
    public class Views_Wycieczka_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TripDetailsPage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
  
    ViewData["Title"] = "Trip Details Page";

    var tripSegments = ViewData["TripSegments"] as List<Odcinek>;
    var i = 1;
    var arrow = " -> ";
    var enter = "\n";
    var bracket = ") ";
    var points = " punktów";
    var space = " ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93b94af62155263b7502395bd77718016143169c4503", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "93b94af62155263b7502395bd77718016143169c4765", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93b94af62155263b7502395bd77718016143169c6647", async() => {
                WriteLiteral("\r\n    <div class=\"content-container\">\r\n        <div class=\"trip-details-container\">\r\n            <h1>");
#nullable restore
#line 20 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
           Write(ViewData["TripTitle"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n            <p>\r\n                W dniach od <span class=\"special-text\">");
#nullable restore
#line 22 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                  Write(ViewData["TripStartTime"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> do <span class=\"special-text\">");
#nullable restore
#line 22 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                                  Write(ViewData["TripEndTime"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> masz zaplanowaną wycieczkę na obszarze <span class=\"special-text\">");
#nullable restore
#line 22 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                                                                                                                                    Write(tripSegments[0].Punkt_Poczatkowy.NazwaGrupyGorskiej);

#line default
#line hidden
#nullable disable
                WriteLiteral(",</span>\r\n                za którą możesz zdobyć <span class=\"special-text\">");
#nullable restore
#line 23 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                             Write(ViewData["TripPoints"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" punktów.</span>\r\n            </p>\r\n            <div class=\"route-segments\">\r\n                <h1>Trasa wycieczki</h1>\r\n                <textarea disabled class=\"segments\">\r\n");
#nullable restore
#line 28 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                     foreach (var segment in tripSegments)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                          ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                       Write(bracket);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                    ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                 Write(segment.Punkt_Poczatkowy.Nazwa);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                     ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                  Write(arrow);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                             ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                          Write(segment.Punkt_Koncowy.Nazwa);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                           ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                        Write(space);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                               Write(segment.Punkty);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                                               Write(points);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                                                       Write(enter);

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                                                                                                                                                  ;

                        i = i + 1;
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </textarea>\r\n                <button class=\"route-button\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1415, "\"", 1466, 3);
                WriteAttributeValue("", 1425, "RouteButtonClick(", 1425, 17, true);
#nullable restore
#line 35 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
WriteAttributeValue("", 1442, ViewData["TripNumber"], 1442, 23, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1465, ")", 1465, 1, true);
                EndWriteAttribute();
                WriteLiteral(">Pokaż na mapie</button>\r\n            </div>\r\n            <button class=\"verification-button\" id=\"cancel-button\" onclick=\"ReturnButtonClick()\">Powrót</button>\r\n        </div>\r\n    </div>\r\n");
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
            WriteLiteral("\r\n</html>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        function ReturnButtonClick() {\r\n            window.location.href = \"");
#nullable restore
#line 47 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                               Write(Url.Action("Index", "Wycieczka"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        }\r\n\r\n        function RouteButtonClick(tripNumber) {\r\n            window.location.href = \"");
#nullable restore
#line 51 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Details.cshtml"
                               Write(Url.Action("DisplayRouteOnMap", "Wycieczka"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?tripNumber=\" + tripNumber + \"&callerController=\'Wycieczka\'&callerAction=\'Details\'\";\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
