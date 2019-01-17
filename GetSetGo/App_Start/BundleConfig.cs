using System.Web;
using System.Web.Optimization;

namespace GetSetGo
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap.bundle.js",
                        "~/scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/datatables.js",
                        "~/scripts/typeahead.bundle.js",
                        "~/scripts/toastr.js",
                        "~/scripts/moment.min.js",
                        "~/Scripts/gijgo/combined/gijgo.min.js",
                        "~/Content/fontawesome/js/all.js",
                        "~/Scripts/sidebar.js",
                        //"~/Scripts/sidebar-pro.js",
                        "~/Scripts/site.js",
                        "~/Scripts/HighCharts/highcharts.js",
                        "~/Scripts/HighCharts/exporting.js",
                        "~/Scripts/HighCharts/export-data.js",
                        "~/Scripts/popper.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Scripts/DataTables/datatables.css",
                        "~/Content/gijgo/combined/gijgo.min.css",
                        "~/content/typeahead.css",
                        "~/content/toastr.css",
                        "~/content/sidebar.css",
                        //"~/content/sidebar-pro.css",
                        "~/content/fontawesome/css/all.css",
                        "~/Content/site.css"));
        }
    }
}
