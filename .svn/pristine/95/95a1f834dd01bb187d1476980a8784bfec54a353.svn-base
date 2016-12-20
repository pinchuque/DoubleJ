using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace DoubleJ.Oms.Web.Extensions
{
    public static class TelerikExtensions
    {
        public static void KendoDatePickerFor<T>(HtmlHelper<T> source, Expression<Func<T, DateTime?>> expression, int tabindex)
        {
            source.Kendo().DatePickerFor(expression)
                .Min(new DateTime(1900, 1, 1))
                .Max(new DateTime(2099, 12, 31))
                .HtmlAttributes(new {tabindex})
                .Render();
        }
    }
}