#pragma checksum "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3339dcf07c129349efa75a1d900de37f5574ffc1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "C:\Git\Test\Teste\Teste.WebAPI\Views\_ViewImports.cshtml"
using Teste.WebAPI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Git\Test\Teste\Teste.WebAPI\Views\_ViewImports.cshtml"
using Teste.WebAPI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3339dcf07c129349efa75a1d900de37f5574ffc1", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"086ea765944b41534aff537aa8d46cb83b4e9a5d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ErrorViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1 class=\"text-danger\">Error.</h1>\n<h2 class=\"text-danger\">An error occurred while processing your request.</h2>\n\n");
#nullable restore
#line 9 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
 if (Model.ShowRequestId)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\n        <strong>Request ID:</strong> <code>");
#nullable restore
#line 12 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
                                      Write(Model.RequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</code>\n    </p>\n");
#nullable restore
#line 14 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>Development Mode</h3>\n");
#nullable restore
#line 17 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
 foreach (var erro in Model.Errors)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\r\n        Codigo Erro: ");
#nullable restore
#line 20 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
                Write(erro.Codigo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n    <p>\r\n        Descricao: ");
#nullable restore
#line 23 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
              Write(erro.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n");
#nullable restore
#line 25 "C:\Git\Test\Teste\Teste.WebAPI\Views\Shared\Error.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ErrorViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
