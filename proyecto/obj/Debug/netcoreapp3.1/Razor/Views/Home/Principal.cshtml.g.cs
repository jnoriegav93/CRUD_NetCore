#pragma checksum "E:\Desarrollo\Proyectos\PyNetCore\solucion\proyecto\Views\Home\Principal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4955aa5c0192e0570453613d09533cb5b6b5f24c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Principal), @"mvc.1.0.view", @"/Views/Home/Principal.cshtml")]
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
#line 1 "E:\Desarrollo\Proyectos\PyNetCore\solucion\proyecto\Views\_ViewImports.cshtml"
using proyecto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Desarrollo\Proyectos\PyNetCore\solucion\proyecto\Views\_ViewImports.cshtml"
using proyecto.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4955aa5c0192e0570453613d09533cb5b6b5f24c", @"/Views/Home/Principal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c408a981cda364cb3b7366a3e1aa09923cb88b9e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Principal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<proyecto.Models.UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Desarrollo\Proyectos\PyNetCore\solucion\proyecto\Views\Home\Principal.cshtml"
  
    ViewData["Title"] = "Inicio";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h2 class=\"display-4\">Bienvenido usuario</h2>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<proyecto.Models.UserModel> Html { get; private set; }
    }
}
#pragma warning restore 1591