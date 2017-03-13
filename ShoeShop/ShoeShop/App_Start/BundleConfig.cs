using System.Web.Optimization;

namespace ShoeShop
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/megamenu").Include(
                        "~/Assets/Client/js/megamenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/movetop").Include(
                        "~/Assets/Client/js/move-top.js"));

            bundles.Add(new ScriptBundle("~/bundles/easing").Include(
                        "~/Assets/Client/js/easing.js"));
            bundles.Add(new ScriptBundle("~/bundles/jscrollpane").Include(
                        "~/Assets/Client/js/jquery.jscrollpane.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/etalage").Include(
                        "~/Assets/Client/js/jquery.etalage.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Assets/Client/css/css").Include(
                      "~/Assets/Client/css/megamenu.css",
                      "~/Assets/Client/css/style.css", 
                      "~/Assets/Client/css/form.css",
                      "~/Assets/Client/css/etalage.css"));
        }
    }
}
