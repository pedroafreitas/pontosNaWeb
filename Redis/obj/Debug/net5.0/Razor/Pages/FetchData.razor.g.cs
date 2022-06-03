#pragma checksum "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "295d87efd2a64e0131d7f6c8b988ba6ab02cbea7"
// <auto-generated/>
#pragma warning disable 1591
namespace Redis.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Redis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Redis.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Cliente\pontosNaWeb\Redis\_Imports.razor"
using Microsoft.Extensions.Caching.Distributed;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
using Redis.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
using Redis.Extensions;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Weather forecast</h1>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>This component demonstrates fetching data from a service.</p>\r\n\r\n");
            __builder.OpenElement(2, "button");
            __builder.AddAttribute(3, "class", "btn btn-primary");
            __builder.AddAttribute(4, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
                                          LoadForecast

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(5, "Load Forecast");
            __builder.CloseElement();
#nullable restore
#line 14 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
 if(forecasts is null && loadLocation == string.Empty)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(6, "<p><em> Click the button to load the forecast</em></p>");
#nullable restore
#line 17 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
}
else if (forecasts is null)
{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(7, "<p><em>Loading...</em></p>");
#nullable restore
#line 21 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "h3" + " " + (
#nullable restore
#line 24 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
                    isCacheData

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(10, 
#nullable restore
#line 24 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
                                  loadLocation

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.OpenElement(11, "table");
            __builder.AddAttribute(12, "class", "table");
            __builder.AddMarkupContent(13, "<thead><tr><th>Date</th>\r\n                <th>Temp. (C)</th>\r\n                <th>Temp. (F)</th>\r\n                <th>Summary</th></tr></thead>\r\n        ");
            __builder.OpenElement(14, "tbody");
#nullable restore
#line 36 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
             foreach (var forecast in forecasts)
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(15, "tr");
            __builder.OpenElement(16, "td");
            __builder.AddContent(17, 
#nullable restore
#line 39 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
                         forecast.Date.ToShortDateString()

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                    ");
            __builder.OpenElement(19, "td");
            __builder.AddContent(20, 
#nullable restore
#line 40 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
                         forecast.TemperatureC

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                    ");
            __builder.OpenElement(22, "td");
            __builder.AddContent(23, 
#nullable restore
#line 41 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
                         forecast.TemperatureF

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                    ");
            __builder.OpenElement(25, "td");
            __builder.AddContent(26, 
#nullable restore
#line 42 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
                         forecast.Summary

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 44 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 47 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 49 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;
    private string loadLocation = string.Empty;
    private string isCacheData = string.Empty;

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Cliente\pontosNaWeb\Redis\Pages\FetchData.razor"
        

    private async Task LoadForecast()
    {
        forecasts = null;
        loadLocation = null;

        string recordKey = "WeatherForecast_" + DateTime.Now.ToString("yyyyMMdd_hhmm");

        forecasts = await cache.GetRecordAsync<WeatherForecast[]>(recordKey);
        
        if(forecasts is null)
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
            loadLocation = $"Loaded from API at {DateTime.Now}";
            isCacheData = string.Empty;

            await cache.SetRecordAsync(recordKey, forecasts);
        }
        else
        {
            loadLocation = $"Loaded from the cache at {DateTime.Now}";
            isCacheData = "text-danger";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDistributedCache cache { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
