#pragma checksum "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b803bb95c8b676f39369f2731ec868c5f140616"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wycieczka_Create), @"mvc.1.0.view", @"/Views/Wycieczka/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b803bb95c8b676f39369f2731ec868c5f140616", @"/Views/Wycieczka/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bab7eab681533ea974c0065c885cfc63e5e5921a", @"/Views/_ViewImports.cshtml")]
    public class Views_Wycieczka_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TripDetailsPage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/TripCreatePage.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("editTripFrom"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateConfirm", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
  
    ViewData["Title"] = "Trip Create Page";

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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b803bb95c8b676f39369f2731ec868c5f1406166044", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b803bb95c8b676f39369f2731ec868c5f1406166306", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b803bb95c8b676f39369f2731ec868c5f1406167484", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b803bb95c8b676f39369f2731ec868c5f1406169366", async() => {
                WriteLiteral("\r\n    <div class=\"content-container\">\r\n        <div id=\"overlay\">\r\n            <div class=\"trip-details-container\">\r\n                <h1>Tworzenie nowej wycieczki</h1>\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b803bb95c8b676f39369f2731ec868c5f1406169821", async() => {
                    WriteLiteral("\r\n                    <input hidden name=\"routeNumber\"");
                    BeginWriteAttribute("value", " value=\"", 765, "\"", 797, 1);
#nullable restore
#line 24 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
WriteAttributeValue("", 773, ViewData["RouteNumber"], 773, 24, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required/>\r\n\r\n                    <label class=\"control-label\" for=\"startDate\">Data pocz??tkowa</label>\r\n                    <input class=\"form-control\" name=\"startDate\" type=\"date\"");
                    BeginWriteAttribute("value", " value=\"", 979, "\"", 1011, 1);
#nullable restore
#line 27 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
WriteAttributeValue("", 987, ViewData["CurrentDate"], 987, 24, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    BeginWriteAttribute("min", " min=\"", 1012, "\"", 1042, 1);
#nullable restore
#line 27 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
WriteAttributeValue("", 1018, ViewData["CurrentDate"], 1018, 24, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    BeginWriteAttribute("max", "\r\n                           max=\"", 1043, "\"", 1097, 1);
#nullable restore
#line 28 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
WriteAttributeValue("", 1077, ViewData["MaxData"], 1077, 20, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" required />

                    <label class=""control-label"" for=""tripDuration"">Czas trwania&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                    <input id=""dateInput"" class=""form-control"" name=""tripDuration"" type=""number"" min=""1"" max=""20"" value=""1"" />
                    <input type=""submit"" id=""createTrip"" hidden />
                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n                <div class=\"route-segments\">\r\n                    <h1>Trasa wycieczki</h1>\r\n                    <textarea disabled class=\"segments\">\r\n");
#nullable restore
#line 38 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                     foreach (var segment in tripSegments)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                          ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                       Write(bracket);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                    ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                 Write(segment.Punkt_Poczatkowy.Nazwa);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                     ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                  Write(arrow);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                             ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                          Write(segment.Punkt_Koncowy.Nazwa);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                                                           ; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                                                        Write(space);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                                                               Write(segment.Punkty);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                                                                               Write(points);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                                                                                       Write(enter);

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                                                                                                                                                  ;

                        i = i + 1;
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </textarea>
                    <button class=""route-button"" onclick=""RouteButtonClick()"">Utw??rz tras??</button>
                </div>
                <button class=""verification-button"" id=""create-trip-button"" onclick=""CreateButtonClick()""> Zatwierd?? </button>
                <button class=""verification-button"" id=""return-button"" onclick=""ReturnButtonClick()"">Powr??t</button>
            </div>
        </div>

        <div class=""my-modal"" id=""modalCreate"">
            <div class=""my-modal-body"">
                <p style=""margin:0"">Za chwil?? zostanie utworzona nowa wycieczka.</p>
                <p style=""margin:0"">Czy jeste?? pewien, ??e chcesz to zrobi???</p>
            </div>

            <button id=""ConfirmButton"" class=""modalLeftButton modalButton"" onclick=""ModalButtonClick(true)"">Tak</button>
            <button class=""modalRightButton modalButton"" onclick=""ModalButtonClick(false)"">Nie</button>
        </div>

        <div class=""my-modal"" id=""modalError"" style=""height: 9");
                WriteLiteral(@"0px;"">
            <div class=""my-modal-body"">
                <p style=""margin:0"">W podanym terminie masz ju?? inn?? wycieczk??.</p>
                <p style=""margin:0""></p>
            </div>

            <button id=""OkButton"" class=""modalButton"" onclick=""OkButtonClick()"">OK</button>
        </div>

    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "onload", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 18 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
AddHtmlAttributeValue("", 430, ViewData["ErrorFunction"], 430, 26, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
#line 79 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                               Write(Url.Action("Index", "Wycieczka"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""";
        }

        function CreateButtonClick() {
            $(""#modalCreate"").fadeIn(800).css(""display"", ""block"");
            $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0.2)"").css(""pointer-events"", ""none"");
        }

        function ModalButtonClick(decision) {
            $(""#modalCreate"").css(""display"", ""none"");
            $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0)"").css(""pointer-events"", ""all"");

            if (decision) document.getElementById(""createTrip"").click();
        }

        function ErrorModal() {
            $(""#modalError"").fadeIn(800).css(""display"", ""block"");
            $(""#modalError"").css(""display"", ""block"");
            $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0)"").css(""pointer-events"", ""all"");
        }

        function OkButtonClick() {
            $(""#modalError"").css(""display"", ""none"");
            $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0)"").css(""pointer-events"", ""all"");
        }

        function RouteButtonC");
                WriteLiteral("lick() {\r\n            window.location.href = \"");
#nullable restore
#line 106 "C:\Users\kacpe\Desktop\GOTv2\GOT\Views\Wycieczka\Create.cshtml"
                               Write(Url.Action("ChooseRoute", "Wycieczka"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\";\r\n        }\r\n\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
