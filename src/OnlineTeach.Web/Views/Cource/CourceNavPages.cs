using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Views.Cource
{
    public static class CourceNavPages
    {
        public static string ActivePage => "ActivePage";
        public static string Index => "Index";
        public static string Edit => "Edit";
        public static string Delete => "Delete";
        public static string Create => "Create";
        public static string IndexNavClass(ViewContext Viewontext) => PageNavClass(Viewontext, Index);
        public static string EditNavClass(ViewContext viewContext) => PageNavClass(viewContext, Edit);
        public static string DeleteNavClass(ViewContext viewContext) => PageNavClass(viewContext, Delete);
        public static string CreateNavClass(ViewContext viewContext) => PageNavClass(viewContext, Create);
        private static string PageNavClass(ViewContext ViewContext, string page)
        {
            var activePage = ViewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
        public static void SetActivePage(this ViewDataDictionary viewData, string activePage) => viewData["ActivePage"] = activePage;

    }
}
