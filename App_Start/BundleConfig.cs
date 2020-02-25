using System.Web;
using System.Web.Optimization;

namespace AssetManagement
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                            "~/Scripts/jquery-3.4.1.min.js",
                               "~/Scripts/DataTables/jquery.dataTables.min.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.select.js",
                          "~/Scripts/DataTables/dataTables.rowReorder.min.js", 
                           "~/Scripts/dataTables.buttons.min.js",
                             "~/Scripts/plotly/plotly-latest.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
           
                      

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                                   "~/Content/DataTables/css/rowReorder.dataTables.min.css",
                                     "~/Content/DataTables/css/font-awesome.min.css",
                              "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/select.dataTables.css",
                    "~/Content/DataTables/css/buttons.dataTables.css",
                    "~/Content/DataTables/css/buttons.dataTables.min",
                      "~/Content/DataTables/css/buttons.jqueryui.min.css"
         
                      ));
        }
    }
}
