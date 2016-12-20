using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace DoubleJ.Oms.LabelManager.Extensions
{
    internal static class LabelManagerExtensions
    {
        internal static void FindDescendantsByType(this Visual element, Type type, string name, List<Visual> foundElements)
        {
            if (foundElements == null)
                foundElements = new List<Visual>();

            if (element == null) return;
            if (element.GetType() == type)
            {
                var fe = element as FrameworkElement;
                if (fe != null)
                {
                    if (fe.Name.Contains(name))
                    {
                        foundElements.Add(fe);
                        return;
                    }
                }
            }

            if (element is FrameworkElement)
                (element as FrameworkElement).ApplyTemplate();

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                var visual = VisualTreeHelper.GetChild(element, i) as Visual;
                FindDescendantsByType(visual, type, name, foundElements);
            }
        }

        internal static T GetAncestorOfType<T>(this FrameworkElement child) where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(child);
            if (parent != null && !(parent is T))
                return GetAncestorOfType<T>((FrameworkElement)parent);
            return (T)parent;
        }

        internal static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        /// <summary>
        /// Find elements by searchText in container and apply style
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="styleProperty"></param>
        /// <param name="container"></param>
        /// <param name="searchText"></param>
        /// <param name="styleName"></param>
        internal static void ApplyStyle<T>(DependencyProperty styleProperty, Visual container, string searchText, string styleName)
        {
            List<Visual> foundElements = new List<Visual>();
            container.FindDescendantsByType(typeof(T), searchText, foundElements);

            foreach (var element in foundElements)
            {
                var sidePanel = element as FrameworkElement;
                if (sidePanel == null || !sidePanel.IsVisible)
                    continue;
                sidePanel.SetResourceReference(styleProperty, styleName);
            }
        }
    }
}
