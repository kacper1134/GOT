#pragma checksum "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec4fc9387621095aac759c42c7f2c0679a513d1d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wycieczka_Map), @"mvc.1.0.view", @"/Views/Wycieczka/Map.cshtml")]
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
#nullable restore
#line 1 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
using GOT.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec4fc9387621095aac759c42c7f2c0679a513d1d", @"/Views/Wycieczka/Map.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bab7eab681533ea974c0065c885cfc63e5e5921a", @"/Views/_ViewImports.cshtml")]
    public class Views_Wycieczka_Map : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RouteViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/map.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
  
    ViewData["Title"] = "Trasa";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec4fc9387621095aac759c42c7f2c0679a513d1d4816", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec4fc9387621095aac759c42c7f2c0679a513d1d5078", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec4fc9387621095aac759c42c7f2c0679a513d1d6256", async() => {
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
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/pretty-checkbox@3.0/dist/pretty-checkbox.min.css\" />\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ec4fc9387621095aac759c42c7f2c0679a513d1d8260", async() => {
                WriteLiteral("\r\n    <div id=\"map\"> </div>\r\n");
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
            WriteLiteral("\r\n\r\n</html>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        var points = ");
#nullable restore
#line 22 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
                Write(Html.Raw(ViewData["serialized-points"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        var routes = ");
#nullable restore
#line 23 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
                Write(Html.Raw(ViewData["serialized-routes"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        var tripNumber = ");
#nullable restore
#line 24 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
                    Write(Html.Raw(ViewData["TripNumber"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        var verificationNumber = ");
#nullable restore
#line 25 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
                            Write(Html.Raw(ViewData["VerificationNumber"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        var callerController = ");
#nullable restore
#line 26 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
                          Write(Html.Raw(ViewData["Controller"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(";\r\n        var callerAction = ");
#nullable restore
#line 27 "C:\Users\kacpe\Desktop\GOT-Project\Etap 4\GOT\Views\Wycieczka\Map.cshtml"
                      Write(Html.Raw(ViewData["Action"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        function initMap() {
            var location = new google.maps.LatLng(50.76, 15.73);
            var mapProperties = {center: location, zoom: 10, scrollwheel: true, draggable: true, disableDefaultUI: true, mapTypeId: 'terrain', minZoom: 6, maxZoom: 15};
            var map = new google.maps.Map(document.getElementById(""map""), mapProperties);
            var markers = new Array(points.length);
            var mapRoutes = new Array(routes.length);

            const markerIcon = ""/images/point.png"";

            for (const index in points) {
                let point = points[index];

                location = new google.maps.LatLng(point.Szerokosc_Geograficzna, point.Dlugosc_Geograficzna);

                markers[index] = new google.maps.Marker({
                    position: location,
                    icon: markerIcon
                });
                markers[index].setMap(map);
            }

            for(const index in routes) {
                let route = route");
                WriteLiteral(@"s[index];
                let beginning = points.filter((point) => {return point.Numer === route.Numer_Punktu_Poczatkowego})[0];
                let ending = points.filter((point) => {return point.Numer === route.Numer_Punktu_Koncowego})[0];

                const coordinates = [
                    {lat: beginning.Szerokosc_Geograficzna, lng: beginning.Dlugosc_Geograficzna},
                    {lat: ending.Szerokosc_Geograficzna, lng: ending.Dlugosc_Geograficzna},
                ];

                const routeColor = GetColorForRouteType(route.Kolor);

                const dash = {
                    path: 'M 0, -1 0, 1',
                    strokeOpacity: 1,
                    scale: 4
                }

                const mapRoute = new google.maps.Polyline({
                    path: coordinates,
                    geodesic: true,
                    strokeColor: routeColor,
                    strokeOpacity: 0,
                    strokeWeight: 100,
                    ico");
                WriteLiteral(@"ns: [{
                        icon: dash,
                        offset: '0',
                        repeat: '20px'
                    }]
                });

                mapRoutes[index] = mapRoute;

                mapRoute.setMap(map);
            }

            map.zoom_changed = function() {
                for (const index in markers) {
                    let marker = markers[index];

                    if (map.getZoom() < 9) {
                        marker.setVisible(false);
                    } else {
                        marker.setVisible(true);
                    }
                }

                for (const index in mapRoutes) {
                    let mapRoute = mapRoutes[index];

                    if (map.getZoom() < 9) {
                        mapRoute.setVisible(false);
                    } else {
                        mapRoute.setVisible(true);
                    }
                }
            }

            var addRouteButton = AddRo");
                WriteLiteral(@"uteButton(document.createElement(""button""));

            map.controls[google.maps.ControlPosition.BOTTOM_RIGHT].push(addRouteButton);
        }

        function GetColorForRouteType(routeType) {
            switch(routeType) {
                case 0:
                    return ""#FF2400"";
                case 1:
                    return ""#3F37C9"";
                case 2:
                    return ""#F9C74F"";
                case 3:
                    return ""#32CD32"";
                case 4:
                    return ""#000000"";
                default:
                    return ""#777777"";
            }
        }

        function AddRouteButton(routeButton) {
            routeButton.classList.add(""standard-button"");

            routeButton.innerText = ""Powrót"";

            routeButton.setAttribute(""data-toggle"", ""modal"");
            routeButton.setAttribute(""data-backdrop"", ""false"");
            routeButton.setAttribute(""onclick"", ""ClickReturnButton()"");

            re");
                WriteLiteral(@"turn routeButton;
        }


        function ClickReturnButton() {
            if (verificationNumber != -1)
            {
                window.location.href = ""/"" + callerController + ""/"" + callerAction + ""?id"" + ""="" + verificationNumber;
            }
            else
            {
                window.location.href = ""/"" + callerController + ""/"" + callerAction + ""?tripNumber"" + ""="" + tripNumber;
            }
        }

        let findMatchingPoints = function(text) {
            return points.map(point => point.Nazwa)
            .filter(name => name.toLowerCase().includes(text.toLowerCase()));
        }


        window.onload = function() {
            $(""#points"").empty();
        }

    </script>
    <script async defer src=""https://maps.googleapis.com/maps/api/js?key=AIzaSyCpRI3hcuVN05u48uFMYYmSU3p34_wLgNY&callback=initMap"">
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RouteViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591