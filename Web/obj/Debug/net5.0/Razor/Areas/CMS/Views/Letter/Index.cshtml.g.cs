#pragma checksum "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fc48a3077e48e1dc2805bbf6834b9df6c7707aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_CMS_Views_Letter_Index), @"mvc.1.0.view", @"/Areas/CMS/Views/Letter/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fc48a3077e48e1dc2805bbf6834b9df6c7707aa", @"/Areas/CMS/Views/Letter/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2050022ea622891cec66b0dba92b9d86fd8f9676", @"/Areas/CMS/Views/_ViewImports.cshtml")]
    public class Areas_CMS_Views_Letter_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Letter>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12 my-4 mx-auto"">
        <div class=""card shadow mb-4"">
            <div class=""card-header"">
                Gelen Ba??vurular
            </div>
            <div class=""card-body"">
                <div class=""table-responsive"">
                    <table class=""table table-striped table-bordered dataTable"" id=""tablom"">
                        <thead>
                            <tr>
                                <th>Ad Soyad</th>
                                <th>Email</th>
                                <th>Mesaj</th>
                                <th>Konu</th>
                                <th>Tarih</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 26 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                             if (Model == null || Model.Count() == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n                                    <td colspan=\"8\" class=\"text-center\">\n                                        Siyah?? bo??dur\n                                    </td>\n                                </tr>\n");
#nullable restore
#line 33 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                 foreach (var letter in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr data-id=\"\">\n                                        <td>\n                                            ");
#nullable restore
#line 40 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                        Write(letter.FullName.Length > 30 ? letter.FullName.Substring(0, 30) : letter.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 43 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                        Write(letter.Email.Length > 30 ? letter.Email.Substring(0, 30) : letter.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 46 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                        Write(letter.Message.Length > 30 ? letter.Message.Substring(0, 30) : letter.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 49 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                        Write(letter.Subject.Length > 30 ? letter.Subject.Substring(0, 30) : letter.Subject);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                        <td>\n                                            ");
#nullable restore
#line 52 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                       Write(letter.RecordedAtDate.ToString("dd/MM/yyyy HH:mm:ss"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                        </td>\n                                    </tr>\n");
#nullable restore
#line 55 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "/Users/mvollstagg/Documents/GitHub/interalrentacar/Web/Areas/CMS/Views/Letter/Index.cshtml"
                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\n                    </table>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $('#tablom').DataTable({
            language: {
                info: ""_TOTAL_ kay??ttan _START_ - _END_ kay??t g??steriliyor."",
                infoEmpty:      ""G??sterilecek hi?? kay??t yok."",
                loadingRecords: ""Kay??tlar y??kleniyor."",
                zeroRecords: ""Tablo bo??"",
                search: ""Arama:"",
                infoFiltered:   ""(toplam _MAX_ kay??ttan filtrelenenler)"",
                buttons: {
                    copyTitle: ""Panoya kopyaland??."",
                    copySuccess:""Panoya %d sat??r kopyaland??"",
                    copy: ""Kopyala"",
                    print: ""Yazd??r"",
                },

                paginate: {
                    first: ""??lk"",
                    previous: ""??nceki"",
                    next: ""Sonraki"",
                    last: ""Son""
                },
                responsive: true
            }
        });
        
        $(document).on(""change"", "".custom-select"", function () {
            var count = $(this).val();
        ");
                WriteLiteral("    $.ajax({\n                type: \"GET\",\n                url: \"/cms/mektub?count=\" + count,\n            });\n        })\n    </script>\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Letter>> Html { get; private set; }
    }
}
#pragma warning restore 1591
