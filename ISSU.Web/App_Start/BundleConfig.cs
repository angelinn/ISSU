using System.Web;
using System.Web.Optimization;

namespace ISSU.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/core/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/core/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/core/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/core/bootstrap.js",
                      "~/Scripts/core/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/core/angular.js",
                "~/Scripts/core/angular-route.js"));

            bundles.Add(new ScriptBundle("~/bundles/susiApp").Include(
                "~/Scripts/susiApp.routes.js",
                "~/Scripts/susiApp.js",
                "~/Scripts/interfaces/susiApp.interfaces.js",
                "~/Scripts/interfaces/susiApp.models.js",
                "~/Scripts/services/susiApp.services.js",
                "~/Scripts/controllers/susiApp.controllers.js"));

            foreach (var bundle in bundles) 
            {
                bundle.Transforms.Clear();
            }
        }
    }
}
