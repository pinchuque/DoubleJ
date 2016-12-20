using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;

namespace DoubleJ.Oms.Model.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name,
            Func<T, string> value, Func<T, bool> isSelected)
        {
            var selItems = items
                .Select(item => new SelectListItem
                {
                    Text = name(item),
                    Value = value(item),
                    Selected = isSelected(item)
                })
                .ToList();
            return selItems;
        }

        public static void RemoveByPredicate<T>(this ObservableCollection<T> collection, Func<T, bool> condition)
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (condition(collection[i]))
                {
                    collection.RemoveAt(i);
                }
            }
        }

        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, Func<T, bool> isSelected, string defaultText, string defaultValue)
        {
            var selItems = items
                .Select(item => new SelectListItem
                {
                    Text = name(item),
                    Value = value(item),
                    Selected = isSelected(item)
                })
                .ToList();

            if (!string.IsNullOrEmpty(defaultText))
            {
                selItems.Insert(0, new SelectListItem
                {
                    Text = defaultText,
                    Value = defaultValue,
                    Selected = selItems.All(item => !item.Selected)
                });
            }

#if DEBUG
            var a = selItems.Where(x => x.Selected).ToArray();
#endif

            return selItems;
        }
    }
}
