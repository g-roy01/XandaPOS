using System.Web;
using System.Web.Optimization;

namespace XandaPOS
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include( 
                      "~/Content/assets/api/jqueryvalidate/jquery.validate.min.js",
                      "~/Content/assets/api/apexcharts/apexcharts.js",
                      "~/Content/assets/api/apexcharts/scriptcharts.js",
                      "~/Content/assets/api/pace/pace.js",
                      "~/Content/assets/api/mcustomscrollbar/jquery.mCustomScrollbar.concat.min.js",
                      "~/Content/assets/api/quill/quill.min.js",
                       "~/Content/api/multiple-select/multiple-select.min.js",
                      "~/Content/assets/api/datatable/jquery.dataTables.min.js" 
                      ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                    "~/Content/assets/js/plugin.bundle.min.js",
                    "~/Content/assets/js/bootstrap.bundle.min.js",
                    "~/Content/assets/js/sweetalert.js",
                    "~/Content/assets/js/sweetalert1.js",
                    "~/Content/assets/js/script.bundle.js"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/masterDataJS").Include(
                   "~/ClientScripts/MasterData.js"
                   ));











            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/style.css",
                      "~/Content/assets/api/pace/pace-theme-flat-top.css",
                      "~/Content/assets/api/mcustomscrollbar/jquery.mCustomScrollbar.css",
                      "~/Content/assets/api/datatable/jquery.dataTables.min.css"));
        }
    }
}
