#pragma checksum "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b04da89edc3c1f812f21c09736da4dd963a3c37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Career_MyCart), @"mvc.1.0.view", @"/Views/Career/MyCart.cshtml")]
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
#line 1 "C:\Users\Godwin\source\repos\BiodataTest\Views\_ViewImports.cshtml"
using BiodataTest;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Godwin\source\repos\BiodataTest\Views\_ViewImports.cshtml"
using BiodataTest.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b04da89edc3c1f812f21c09736da4dd963a3c37", @"/Views/Career/MyCart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8090ed2117039601fad8ecb1dca21a8dfcb0bf8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Career_MyCart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BiodataTest.ViewModels.ShoppingCartItemViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "existedApplications", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Career", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "ShoppingCartItem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
  
    ViewData["Title"] = "MyCart";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"panel panel-default\">\r\n    <div class=\"panel-body\">\r\n        \r\n");
#nullable restore
#line 12 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
         if (Model.Cartitems != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"container-fluid\">\r\n\r\n                <div class=\"panel panel-success\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b04da89edc3c1f812f21c09736da4dd963a3c375268", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@"                        <div class=""panel-body"">

                            <div class=""row"">
                                <div class=""col-md-6"" style=""text-align:left"">
                                    <div class=""form-group"">
                                        <div>
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b04da89edc3c1f812f21c09736da4dd963a3c375908", async() => {
                    WriteLiteral("Back resources");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
                                </div>
                                <div class=""col-md-6"" style=""text-align:right"">
                                    <div class=""form-group"">


                                        <div>
");
                WriteLiteral("                                            <a");
                BeginWriteAttribute("href", " href=\"", 1339, "\"", 1419, 1);
#nullable restore
#line 38 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
WriteAttributeValue("", 1346, Url.Action("CheckOut", "ShoppingCartItem", new { id =@Model.EmployerId}), 1346, 73, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">CheckOut</a>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n\r\n");
                WriteLiteral("                            </div>\r\n                        </div>\r\n\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <div class=""panel-heading"">My Cart Items</div>
                    <div class=""panel-body"">
                        <div class=""row"">

                            <table class=""table-bordered"">
                                <thead class=""table th"">
                                    <tr>
                                        <th>
");
            WriteLiteral("                                            App Id\r\n                                        </th>\r\n                                        <th>\r\n");
            WriteLiteral("                                            Category Name\r\n                                        </th>\r\n                                        <th>\r\n");
            WriteLiteral("                                            Career Name\r\n                                        </th>\r\n                                        <th hidden>\r\n                                            ");
#nullable restore
#line 68 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                       Write(Html.DisplayNameFor(model => model.EmployerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n");
            WriteLiteral("                                            FirstName\r\n                                        </th>\r\n                                        <th>\r\n");
            WriteLiteral("                                            LastName\r\n                                        </th>\r\n                                        <th>\r\n");
            WriteLiteral("                                            Years Exp\r\n                                        </th>\r\n                                        <th>\r\n");
            WriteLiteral(@"                                            Amount
                                        </th>

                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody class=""table td"">

");
#nullable restore
#line 92 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                     foreach (var item in Model.Cartitems)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 96 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.ApplicationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td hidden>\r\n                                                ");
#nullable restore
#line 99 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CategoryID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td hidden>\r\n                                                ");
#nullable restore
#line 102 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CareerID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 105 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 108 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CareerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td hidden>\r\n                                                ");
#nullable restore
#line 111 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.EmployerId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 114 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 117 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 120 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.yearsExpe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 123 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td hidden>\r\n                                                ");
#nullable restore
#line 126 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.transDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1b04da89edc3c1f812f21c09736da4dd963a3c3716961", async() => {
                WriteLiteral("Remove Item");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 129 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                                                                                           WriteLiteral(item.ShoppingCartItemId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 132 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"


                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <tr>
                                    <tr>
                                        <td>Total Amount:</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            ");
#nullable restore
#line 144 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"
                                       Write(Model.ShoppingCartTotal);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </td>
                                    </tr>

                                    </tr>

                                </tbody>
                            </table>
                        </div>


                    </div>
                </div>
            </div>
");
#nullable restore
#line 158 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\MyCart.cshtml"




        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BiodataTest.ViewModels.ShoppingCartItemViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
