using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DoubleJ.Oms.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name,
                                                                       Func<T, string> value, Func<T, bool> isSelected,
                                                                       string defaultText, string defaultValue)
        {
            List<SelectListItem> selItems = items.Select(item => new SelectListItem
                {
                    Text = name(item),
                    Value = value(item),
                    Selected = isSelected(item)
                }).ToList();

            if (!string.IsNullOrEmpty(defaultText))
            {
                selItems.Insert(0,
                                selItems.Find(item => item.Selected) == null
                                    ? new SelectListItem {Text = defaultText, Value = defaultValue, Selected = true}
                                    : new SelectListItem {Text = defaultText, Value = defaultValue});
            }
            return selItems;
        }

        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name,
                                                                       Func<T, string> name2, Func<T, string> value,
                                                                       Func<T, bool> isSelected, string defaultText,
                                                                       string defaultValue, string formatText)
        {
            var selItems = items.Select(item => new SelectListItem
                {
                    Text = string.Format(formatText, name(item), name2(item)),
                    Value = value(item),
                    Selected = isSelected(item)
                }).ToList();

            if (!string.IsNullOrEmpty(defaultText))
            {
                selItems.Insert(0,
                                selItems.Find(item => item.Selected) == null
                                    ? new SelectListItem {Text = defaultText, Value = defaultValue, Selected = true}
                                    : new SelectListItem {Text = defaultText, Value = defaultValue});
            }
            return selItems;
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items,
                                                                            Func<T, string> name, Func<T, string> value,
                                                                            IEnumerable<string> selectedValues)
        {
            if (items == null)
                return new List<SelectListItem>();

            if (selectedValues == null)
                selectedValues = new List<string>();

            return items.ToMultiSelectListItems(name, value, x => selectedValues.Contains(value(x)));
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items,
                                                                            Func<T, string> name, Func<T, string> value,
                                                                            Func<T, bool> isSelected)
        {
            if (items == null)
                return new List<SelectListItem>();

            return items.Select(item => new SelectListItem
                {
                    Text = name(item),
                    Value = value(item),
                    Selected = isSelected(item)
                });
        }
    }
}
