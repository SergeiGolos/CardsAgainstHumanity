using System.Web.Optimization;

namespace CardsAgainstHumanity.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));


            bundles.Add(new ScriptBundle("~/bundles/src")
                .Include("~/App/application.js")
                .IncludeDirectory("~/App/Controllers/", "*.js")
                .IncludeDirectory("~/App/Factories/", "*.js"));                


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
