#pragma checksum "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "091f8994cac76af77cc312db84877823af0c4164"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CMS_Views_Home_Index), @"mvc.1.0.view", @"/Areas/CMS/Views/Home/Index.cshtml")]
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
#line 1 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/_ViewImports.cshtml"
using Web.Areas.CMS.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/_ViewImports.cshtml"
using Utilities.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/_ViewImports.cshtml"
using Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/_ViewImports.cshtml"
using Data.DAL;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"091f8994cac76af77cc312db84877823af0c4164", @"/Areas/CMS/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2050022ea622891cec66b0dba92b9d86fd8f9676", @"/Areas/CMS/Views/_ViewImports.cshtml")]
    public class Areas_CMS_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Hoş geldiniz :)</h1>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor httpAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public MainContext context { get; private set; }
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
