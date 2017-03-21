using System;
using System.Text;
using System.Web.Mvc;
using Empl.ViewModels;

namespace Empl.Helpers
{
    public static class Pagination
    {
        public static MvcHtmlString GenerateGoToPageLink(this HtmlHelper html, IndexViewModel pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.FilteredRowsTotal; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}