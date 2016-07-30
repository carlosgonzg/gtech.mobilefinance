using System.Web;
using System.Web.Optimization;

namespace gtech.mobilefinance.api
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/js/bootstrap/dist/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/js/angular/angular.min.js", 
                      "~/js/angular-animate/angular-animate.min.js",
                      "~/js/angular-aria/angular-aria.min.js",
                      "~/js/angular-cookies/angular-cookies.min.js",
                      "~/js/angular-messages/angular-messages.min.js",
                      "~/js/angular-mocks/angular-mocks.js",
                      "~/js/angular-resource/angular-resource.min.js",
                      "~/js/angular-route/angular-route.min.js",
                      "~/js/angular-sanitize/angular-sanitize.min.js",
                      "~/js/angular-touch/angular-touch.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/scripts").Include(
                      "~/scripts/app.js",
                      "~/scripts/services/*.js",
                      "~/scripts/controllers/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
