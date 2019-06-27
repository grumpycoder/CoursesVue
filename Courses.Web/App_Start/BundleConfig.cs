using System.Web.Optimization;

namespace Courses.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/css/clusters").Include(
                "~/js/app/clusters/styles*"));

            bundles.Add(new StyleBundle("~/css/programs").Include(
                "~/js/app/programs/styles*"));

            bundles.Add(new ScriptBundle("~/bundles/clusters")
                .Include(
                "~/js/app/clusters/runtime*",
                "~/js/app/clusters/es2015-polyfills*",
                "~/js/app/clusters/polyfills*",
                "~/js/app/clusters/main*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/programs")
                .Include(
                    "~/js/app/programs/runtime*",
                    "~/js/app/programs/es2015-polyfills*",
                    "~/js/app/programs/polyfills*",
                    "~/js/app/programs/main*"
                ));


            bundles.Add(new ScriptBundle("~/bundles/courses")
                .Include(
                    "~/js/app/courses/runtime*",
                    "~/js/app/courses/es2015-polyfills*",
                    "~/js/app/courses/polyfills*",
                    "~/js/app/courses/main*"
                ));

        }
    }
}
