#pragma checksum "E:\Desarrollo\Proyectos\PyNetCore\solucion\proyecto\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c9b276ec8400b9069c9603de96fe99f2684182f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c9b276ec8400b9069c9603de96fe99f2684182f", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c408a981cda364cb3b7366a3e1aa09923cb88b9e", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<proyecto.Models.UserModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\Desarrollo\Proyectos\PyNetCore\solucion\proyecto\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Inicio";
    /*String usuario="";   
    
    if(TempData["login"]!=null){           
    Layout = "_Layout";
    usuario = TempData["login"].ToString();
    }
    else{           
    Layout = "_Layout_offline";
    }*/
    
    Layout = "_Layout_offline";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h2 class=\"display-4\">Bienvenido a la página principal.</h2>\r\n    <p>Necesitas ingresar para ver el contenido de la página.</p>\r\n\r\n    ");
#nullable restore
#line 21 "E:\Desarrollo\Proyectos\PyNetCore\solucion\proyecto\Views\Home\Index.cshtml"
Write(Html.ActionLink("Acceder al sistema", "Login", "Home", routeValues: null, 
    htmlAttributes: new { @class = "btn btn-primary", @role="button" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("  \r\n\r\n</div>\r\n");
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
