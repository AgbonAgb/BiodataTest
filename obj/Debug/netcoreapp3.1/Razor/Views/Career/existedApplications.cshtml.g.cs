#pragma checksum "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6472d5d7e924f1c16d10c68f4a849370f37baf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Career_existedApplications), @"mvc.1.0.view", @"/Views/Career/existedApplications.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6472d5d7e924f1c16d10c68f4a849370f37baf9", @"/Views/Career/existedApplications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8090ed2117039601fad8ecb1dca21a8dfcb0bf8c", @"/Views/_ViewImports.cshtml")]
    public class Views_Career_existedApplications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BiodataTest.Models.ApplicationDetails>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("categoryid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "categoryid", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Career", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "existedApplications", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6472d5d7e924f1c16d10c68f4a849370f37baf95973", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n        //$(function () {\r\n        //    $(\'#txtStartDate\').datetimepicker();\r\n        //});\r\n\r\n\r\n");
                WriteLiteral("    </script>\r\n");
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
            WriteLiteral("\r\n\r\n\r\n<!--div class=\"row\">\r\n   <div class=\"col-md-12\">\r\n       <form asp-controller=\"Career\" asp-action=\"existedApplications\" method=\"get\">\r\n           <p>\r\n               Search With: <input type=\"text\" name=\"SearchString\" id=\"SearchString\" />-->\r\n");
            WriteLiteral("\r\n<!--<input type=\"Submit\" value=\"Search\" class=\"btn btn-default-alt\" />\r\n            </p>\r\n\r\n        </form>\r\n\r\n    </div>\r\n</div>-->\r\n<div class=\"panel panel-default\">\r\n    <div class=\"panel-body\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6472d5d7e924f1c16d10c68f4a849370f37baf97689", async() => {
                WriteLiteral(@"


            <div class=""panel panel-primary"">
                <div class=""panel-heading"">Filter Section</div>
                <div class=""panel-body"">

                    <div class=""row"">
                        <div class=""col-md-6"">
                            <div class=""form-group"">
                                <label class=""control-label"">Search with Career Category</label>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6472d5d7e924f1c16d10c68f4a849370f37baf98391", async() => {
                    WriteLiteral("\r\n                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 72 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(@ViewBag.listofCategory,"CategoryID","CategoryName"));

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n                        <div class=\"col-md-6\">\r\n                            <div class=\"form-group\">\r\n");
                WriteLiteral(@"                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-3"">
                            <div class=""form-group"">
                                <label class=""control-label"">Start Date</label>
                                <input type=""date"" id=""StartDate"" name=""StartDate"" />
                            </div>
                        </div>

                        <div class=""col-md-3"">
                            <div class=""form-group"">
                                <label class=""control-label"">End Date</label>
                                <input type=""date"" id=""EndDate"" name=""EndDate"" />
                            </div>
                        </div>
                    </div>

                    <input type=""submit"" value=""Search"" class=""btn btn-primary"" />
                </div>
            </div>

        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b6472d5d7e924f1c16d10c68f4a849370f37baf913271", async() => {
                WriteLiteral("Back resources");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            WriteLiteral(@"<div class=""panel panel-success"">
    <div class=""panel-heading""></div>
    <div class=""panel-body"">
        <div class=""row"">
            <table class=""table-bordered"">
                <thead class=""table th"">
                    <tr>
                        <th>
");
            WriteLiteral("                            ID\r\n                        </th>\r\n                        <th>\r\n");
            WriteLiteral("                            Career\r\n                        </th>\r\n                        <th>\r\n");
            WriteLiteral("                            Category\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 135 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                       Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 138 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                       Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n\r\n                        <th hidden>\r\n                            ");
#nullable restore
#line 142 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th hidden>\r\n");
            WriteLiteral("                            Phone\r\n                        </th>\r\n                        <th hidden>\r\n");
            WriteLiteral("                            Address\r\n                        </th>\r\n                        <th>\r\n");
            WriteLiteral("                            Years\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 157 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                       Write(Html.DisplayNameFor(model => model.TransDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n\r\n\r\n                        <th hidden>\r\n                            ");
#nullable restore
#line 162 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                       Write(Html.DisplayNameFor(model => model.approved));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n");
            WriteLiteral("\r\n                        <th>\r\n                            Actions\r\n                        </th>\r\n\r\n                    </tr>\r\n                </thead>\r\n                <tbody class=\"table td\">\r\n");
#nullable restore
#line 184 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 188 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ApplicationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 191 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CareerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 194 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 197 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 200 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n\r\n                            <td hidden>\r\n                                ");
#nullable restore
#line 204 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td hidden>\r\n                                ");
#nullable restore
#line 207 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td hidden>\r\n                                ");
#nullable restore
#line 210 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 213 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.yearsExpe));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n");
            WriteLiteral("                                ");
#nullable restore
#line 218 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.Raw(item.TransDate.ToString("dd-MM-yyyy HH:mm")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n\r\n\r\n                            <td hidden>\r\n                                ");
#nullable restore
#line 223 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.approved));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td hidden>\r\n                                ");
#nullable restore
#line 226 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CvPath));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
            WriteLiteral("                            <td>\r\n");
#nullable restore
#line 241 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                                 if (User.IsInRole("Admin"))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div>\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 10184, "\"", 10259, 1);
#nullable restore
#line 245 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 10191, Url.Action("ViewDetails", "Career", new { Id = item.ApplicationId}), 10191, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View Details</a>\r\n                                        </li>\r\n\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 10437, "\"", 10510, 1);
#nullable restore
#line 249 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 10444, Url.Action("OnGetDownloadCV", "Career", new { Id = item.CvPath }), 10444, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View CV</a>\r\n                                        </li>\r\n\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 10683, "\"", 10756, 1);
#nullable restore
#line 253 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 10690, Url.Action("ApproveCV", "Career", new { Id = item.ApplicationId}), 10690, 66, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Approve</a>\r\n                                        </li>\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 10927, "\"", 10999, 1);
#nullable restore
#line 256 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 10934, Url.Action("RejectCV", "Career", new { Id = item.ApplicationId}), 10934, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Reject</a>\r\n                                        </li>\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 11169, "\"", 11247, 1);
#nullable restore
#line 259 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 11176, Url.Action("AddUserCartlog", "Career", new { Id = item.ApplicationId}), 11176, 71, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\'Are you sure of adding this to your cartlog?\')\">Add to Cartlog</a>\r\n                                        </li>\r\n\r\n                                    </div>\r\n");
#nullable restore
#line 263 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                                }
                                else if (User.IsInRole("Employer"))
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div>\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 11726, "\"", 11801, 1);
#nullable restore
#line 268 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 11733, Url.Action("ViewDetails", "Career", new { Id = item.ApplicationId}), 11733, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View Details</a>\r\n                                        </li>\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 11977, "\"", 12055, 1);
#nullable restore
#line 271 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 11984, Url.Action("AddUserCartlog", "Career", new { Id = item.ApplicationId}), 11984, 71, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\'Are you sure of adding this to your cartlog?\')\">Add to Cartlog</a>\r\n                                        </li>\r\n\r\n                                    </div>\r\n");
#nullable restore
#line 275 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div>\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 12503, "\"", 12578, 1);
#nullable restore
#line 280 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 12510, Url.Action("ViewDetails", "Career", new { Id = item.ApplicationId}), 12510, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View Details</a>\r\n                                        </li>\r\n                                        <li class=\"nav-item\">\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 12754, "\"", 12832, 1);
#nullable restore
#line 283 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
WriteAttributeValue("", 12761, Url.Action("AddUserCartlog", "Career", new { Id = item.ApplicationId}), 12761, 71, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\'Are you sure of adding this to your cartlog?\')\">Add to Cartlog</a>\r\n                                        </li>\r\n\r\n                                    </div>\r\n");
#nullable restore
#line 287 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 292 "C:\Users\Godwin\source\repos\BiodataTest\Views\Career\existedApplications.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BiodataTest.Models.ApplicationDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
