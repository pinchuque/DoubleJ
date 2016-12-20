using System.Web.Optimization;

namespace DoubleJ.Oms.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                 "~/Scripts/kendo.all.min.js",
                 "~/Scripts/kendo.aspnetmvc.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/kendo.common.css",
                "~/Content/kendo.default.css",
                "~/Content/site.css"
                ));
            bundles.IgnoreList.Clear();

            BundleTable.EnableOptimizations = true;
        }
    }
}