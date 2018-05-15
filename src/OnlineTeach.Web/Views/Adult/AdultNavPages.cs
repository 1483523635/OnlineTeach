using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.Views.Adult
{
    public static class AdultNavPages
    {
        public static string ActivePageKey => "ActivePage";
        public static string Index => "Index";
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;

        }
        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData["ActivePage"] = activePage;
    }
}
