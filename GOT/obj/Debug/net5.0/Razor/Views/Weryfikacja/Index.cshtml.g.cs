#pragma checksum "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9995a035ac3660ae1adc7e72e164b0f84ab22bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Weryfikacja_Index), @"mvc.1.0.view", @"/Views/Weryfikacja/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
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
#nullable restore
#line 2 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
using GOT.Models.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
using System.Collections.Generic;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9995a035ac3660ae1adc7e72e164b0f84ab22bf", @"/Views/Weryfikacja/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bab7eab681533ea974c0065c885cfc63e5e5921a", @"/Views/_ViewImports.cshtml")]
    public class Views_Weryfikacja_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GOT.Models.Weryfikacja>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("FilterList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("FilterListClick()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("OrderList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("OrderListClick()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
  
    ViewData["Title"] = "Verification Home Page";
    var titlesList = ViewData["Titles"] as List<string>;
    var i = 0;
    var filterOption = ViewData["filterOptionNumber"].ToString();
    var orderOption = ViewData["orderOptionNumber"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content-container\">\r\n    <div id=\"overlay\">\r\n        <h1>Wnioski</h1>\r\n        <p style=\"padding-left: 20px; float: left;\">\r\n            Filtruj:\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9995a035ac3660ae1adc7e72e164b0f84ab22bf7055", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9995a035ac3660ae1adc7e72e164b0f84ab22bf7331", async() => {
                    WriteLiteral("Pokaż Wszystkie");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 18 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Html.GetEnumSelectList<Status>();

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 18 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => filterOption);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </p>\r\n\r\n        <p style=\"padding-right: 20px; float:right;\">\r\n            Sortuj:\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9995a035ac3660ae1adc7e72e164b0f84ab22bf10547", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9995a035ac3660ae1adc7e72e164b0f84ab22bf10824", async() => {
                    WriteLiteral("Od najnowszych");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9995a035ac3660ae1adc7e72e164b0f84ab22bf12395", async() => {
                    WriteLiteral("Od najstarszych");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
#nullable restore
#line 25 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => orderOption);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </p>\r\n\r\n");
#nullable restore
#line 31 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
         foreach (var item in Model)
        {
            var statusId = (int)item.Status;


#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"application-container\">\r\n                <div class=\"application-text-container\"");
            BeginWriteAttribute("style", " style=\"", 1300, "\"", 1370, 2);
            WriteAttributeValue("", 1308, "border-color:", 1308, 13, true);
#nullable restore
#line 36 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
WriteAttributeValue("  ", 1321, Weryfikacja.BorderColorForStatus(@item.Status), 1323, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <p>\r\n                        ");
#nullable restore
#line 38 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                   Write(titlesList[i]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <br />\r\n                        ");
#nullable restore
#line 40 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                   Write(item.GetDateInformation());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </p>\r\n                </div>\r\n\r\n                <button class=\"application-button-container\"");
            BeginWriteAttribute("style", " style=\"", 1635, "\"", 1705, 2);
            WriteAttributeValue("", 1643, "border-color:", 1643, 13, true);
#nullable restore
#line 44 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
WriteAttributeValue("  ", 1656, Weryfikacja.BorderColorForStatus(@item.Status), 1658, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1706, "\"", 1769, 5);
            WriteAttributeValue("", 1716, "VerificationButtonClick(", 1716, 24, true);
#nullable restore
#line 44 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
WriteAttributeValue("", 1740, item.Numer_Wpisu, 1740, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1757, ",", 1757, 1, true);
#nullable restore
#line 44 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
WriteAttributeValue(" ", 1758, statusId, 1759, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1768, ")", 1768, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    Rozpatrz\r\n                </button>\r\n            </div>\r\n");
#nullable restore
#line 48 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
            i += 1;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <p style=\"padding-top:40px; font-size: 20px; color: red\">");
#nullable restore
#line 51 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                                                            Write(ViewData["NoApplications"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        <div class=\"pageChanger\">\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9995a035ac3660ae1adc7e72e164b0f84ab22bf18609", async() => {
                WriteLiteral("\r\n                <a onclick=\"LeftBracketClick()\"><</a>\r\n                <button id=\"Button1\" class=\"pageChangerCircle\" name=\"pageNumber\"");
                BeginWriteAttribute("value", " value=", 2190, "", 2227, 1);
#nullable restore
#line 57 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
WriteAttributeValue("", 2197, ViewData["CurrentPageNumber"], 2197, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 57 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                                                                                                                 Write(ViewData["CurrentPageNumber"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                <button id=\"Button2\" class=\"pageChangerCircle\" name=\"pageNumber\"");
                BeginWriteAttribute("value", " value=", 2349, "", 2383, 1);
#nullable restore
#line 58 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
WriteAttributeValue("", 2356, ViewData["NextPageNumber"], 2356, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 58 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                                                                                                              Write(ViewData["NextPageNumber"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                <button class=\"pageChangerCircle\" disabled>...</button>\r\n                <button id=\"Button3\" class=\"pageChangerCircle\" name=\"pageNumber\"");
                BeginWriteAttribute("value", " value=", 2575, "", 2608, 1);
#nullable restore
#line 60 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
WriteAttributeValue("", 2582, ViewData["MaxPageNumber"], 2582, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 60 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                                                                                                             Write(ViewData["MaxPageNumber"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                <a onclick=\"RightBracketClick()\">></a>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
    <div class=""my-modal"" id=""modalVerification"">
        <div class=""my-modal-body"">
            Próbujesz rozpatrzyć już rozpatrzony wniosek.
            Czy chcesz zmienić swoją decyzję?
        </div>

        <button id=""ConfirmButton"" class=""modalLeftButton modalButton"" onclick=""ModalButtonClick(true)"">Tak</button>
        <button class=""modalRightButton modalButton"" onclick=""ModalButtonClick(false)"">Nie</button>

    </div>

</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        function LeftBracketClick() {

            var number = parseInt(document.getElementById(""Button1"").textContent);
            var nextNumber = parseInt(document.getElementById(""Button2"").textContent);

            number = Math.max(number - 1, 1);
            nextNumber = Math.min(number + 1, nextNumber);

            $(""#Button1"").text(number);
            $(""#Button1"").val(number);

            $(""#Button2"").text(nextNumber);
            $(""#Button2"").val(nextNumber);
        }

        function RightBracketClick() {

            var number = parseInt(document.getElementById(""Button1"").textContent);
            var nextNumber = parseInt(document.getElementById(""Button2"").textContent);
            var maxNumber = parseInt(document.getElementById(""Button3"").textContent);

            number = Math.min(number + 1, (Math.max(maxNumber - 2, 1)));
            nextNumber = Math.max(Math.min(number + 1, (Math.max(maxNumber - 1, 1))), nextNumber);

            $(""#Bu");
                WriteLiteral(@"tton1"").text(number);
            $(""#Button1"").val(number);

            $(""#Button2"").text(nextNumber);
            $(""#Button2"").val(nextNumber);
        }

        function FilterListClick() {
            var selectFilter = document.getElementById(""FilterList"");
            var selectOrder = document.getElementById(""OrderList"");
            window.location.href = """);
#nullable restore
#line 115 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                               Write(Url.Action("Index", "Weryfikacja"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?pageNumber=1"" + ""&filterOption="" + selectFilter.options[selectFilter.selectedIndex].value
                + ""&orderOption="" + selectOrder.options[selectOrder.selectedIndex].value;
        }

        function OrderListClick() {
            var selectFilter = document.getElementById(""FilterList"");
            var selectOrder = document.getElementById(""OrderList"");
            window.location.href = """);
#nullable restore
#line 122 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                               Write(Url.Action("Index", "Weryfikacja"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?pageNumber=1"" + ""&filterOption="" + selectFilter.options[selectFilter.selectedIndex].value
                + ""&orderOption="" + selectOrder.options[selectOrder.selectedIndex].value;
        }

        function VerificationButtonClick(id, status) {
            if (status == 2) VerficationStartClick(id);
            else {
                $(""#modalVerification"").fadeIn(800).css(""display"", ""block"");
                $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0.2)"").css(""pointer-events"", ""none"");
                $(""#ConfirmButton"").val(id);
            }
        }

        function ModalButtonClick(decision) {
            id = parseInt($(""#ConfirmButton"").attr(""value""));
            $(""#modalVerification"").css(""display"", ""none"");
            $(""#overlay"").css(""background-color"", ""rgba(0,0,0,0)"").css(""pointer-events"", ""all"");

            if (decision) VerficationStartClick(id);
        }

        function VerficationStartClick(id) {
            window.location.href = """);
#nullable restore
#line 144 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Weryfikacja\Index.cshtml"
                               Write(Url.Action("ApplicationDetails", "Weryfikacja"));

#line default
#line hidden
#nullable disable
                WriteLiteral("?id=\" + id;\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GOT.Models.Weryfikacja>> Html { get; private set; }
    }
}
#pragma warning restore 1591