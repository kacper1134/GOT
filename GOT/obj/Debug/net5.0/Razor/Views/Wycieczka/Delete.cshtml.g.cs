#pragma checksum "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79baf2a1029c77bba94b6647f4dc1070ed5b30bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wycieczka_Delete), @"mvc.1.0.view", @"/Views/Wycieczka/Delete.cshtml")]
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
#line 1 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\_ViewImports.cshtml"
using GOT;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\_ViewImports.cshtml"
using GOT.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79baf2a1029c77bba94b6647f4dc1070ed5b30bb", @"/Views/Wycieczka/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bab7eab681533ea974c0065c885cfc63e5e5921a", @"/Views/_ViewImports.cshtml")]
    public class Views_Wycieczka_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wycieczka>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TripDetailsPage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TripDeletePage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
  
    ViewData["Title"] = "Trip Delete Page";

    var tripSegments = ViewData["TripSegments"] as List<Odcinek>;
    var i = 1;
    var arrow = " -> ";
    var enter = "\n";
    var bracket = ") ";
    var points = " punkt??w";
    var space = " ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79baf2a1029c77bba94b6647f4dc1070ed5b30bb4844", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "79baf2a1029c77bba94b6647f4dc1070ed5b30bb5106", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "79baf2a1029c77bba94b6647f4dc1070ed5b30bb6284", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "79baf2a1029c77bba94b6647f4dc1070ed5b30bb8166", async() => {
                WriteLiteral("\r\n    <div class=\"content-container\">\r\n        <div id=\"overlay\">\r\n            <div class=\"trip-details-container\">\r\n                <h1>");
#nullable restore
#line 24 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
               Write(ViewData["TripTitle"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n                <p>\r\n                    W dniach od <span class=\"special-text\">");
#nullable restore
#line 26 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                      Write(ViewData["TripStartTime"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> do <span class=\"special-text\">");
#nullable restore
#line 26 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                                      Write(ViewData["TripEndTime"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> masz zaplanowan?? wycieczk?? na obszarze <span class=\"special-text\">");
#nullable restore
#line 26 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                                                                                                                                        Write(tripSegments[0].Punkt_Poczatkowy.NazwaGrupyGorskiej);

#line default
#line hidden
#nullable disable
                WriteLiteral(",</span>\r\n                    za kt??r?? mo??esz zdoby?? <span class=\"special-text\">");
#nullable restore
#line 27 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                 Write(ViewData["TripPoints"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" punkt??w.</span>\r\n                </p>\r\n                <div class=\"route-segments\">\r\n                    <h1>Trasa wycieczki</h1>\r\n                    <textarea disabled class=\"segments\">\r\n");
#nullable restore
#line 32 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                     foreach (var segment in tripSegments)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                          ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                       Write(bracket);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                    ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                 Write(segment.Punkt_Poczatkowy.Nazwa);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                     ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                  Write(arrow);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                             ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                          Write(segment.Punkt_Koncowy.Nazwa);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                           ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                        Write(space);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                               Write(segment.Punkty);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                                               Write(points);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                                                       Write(enter);

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                                                                                                                                                  ;

                        i = i + 1;
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </textarea>\r\n                    <button class=\"route-button\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1566, "\"", 1606, 3);
                WriteAttributeValue("", 1576, "RouteButtonClick(", 1576, 17, true);
#nullable restore
#line 39 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
WriteAttributeValue("", 1593, Model.Numer, 1593, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1605, ")", 1605, 1, true);
                EndWriteAttribute();
                WriteLiteral(">Poka?? na mapie</button>\r\n                </div>\r\n                <button id=\"DeleteTripButton\"");
                BeginWriteAttribute("onclick", " onclick=\"", 1702, "\"", 1743, 3);
                WriteAttributeValue("", 1712, "DeleteButtonClick(", 1712, 18, true);
#nullable restore
#line 41 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
WriteAttributeValue("", 1730, Model.Numer, 1730, 12, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1742, ")", 1742, 1, true);
                EndWriteAttribute();
                WriteLiteral(@">Usu??</button>
                <button class=""verification-button"" id=""cancel-button"" onclick=""ReturnButtonClick()"">Powr??t</button>
            </div>
        </div>
        <div class=""my-modal"" id=""modalDelete"">
            <div class=""my-modal-body"">
                <p style=""margin:0"">Usuni??cie wycieczki jest operacj?? nieodwracaln??.</p>
                <p style=""margin:0"">Czy jeste?? pewien, ??e chcesz to zrobi???</p>
            </div>

            <button id=""ConfirmButton"" class=""modalLeftButton modalButton"" onclick=""ModalButtonClick(true)"">Tak</button>
            <button class=""modalRightButton modalButton"" onclick=""ModalButtonClick(false)"">Nie</button>

        </div>

    </div>
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
            WriteLiteral("\r\n</html>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        function ReturnButtonClick() {\r\n            window.location.href = \"");
#nullable restore
#line 64 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                               Write(Url.Action("Index", "Wycieczka"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""";
        }

        function DeleteButtonClick(id) {
                $(""#modalDelete"").fadeIn(800).css(""display"", ""block"");
                $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0.2)"").css(""pointer-events"", ""none"");
                $(""#DeleteTripButton"").val(id);
            }

        function DeclineButtonClick(id) {
            window.location.href = """);
#nullable restore
#line 74 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                               Write(Url.Action("ApplicationDeclineReason", "Weryfikacja"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?id=""+id;
        }

        function ModalButtonClick(decision) {
            id = parseInt($(""#DeleteTripButton"").attr(""value""));
            $(""#modalDelete"").css(""display"", ""none"");
            $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0)"").css(""pointer-events"", ""all"");

            if (decision) DeleteTripStartClick(id);
        }

        function DeleteTripStartClick(id) {
            window.location.href = """);
#nullable restore
#line 86 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                               Write(Url.Action("DeleteConfirm", "Wycieczka"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?tripNumber=\" + id;\r\n        }\r\n\r\n        function RouteButtonClick(tripNumber) {\r\n            window.location.href = \"");
#nullable restore
#line 90 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Delete.cshtml"
                               Write(Url.Action("DisplayRouteOnMap", "Wycieczka"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?tripNumber=\" + tripNumber + \"&callerController=\'Wycieczka\'&callerAction=\'Delete\'\";\r\n        }\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wycieczka> Html { get; private set; }
    }
}
#pragma warning restore 1591
