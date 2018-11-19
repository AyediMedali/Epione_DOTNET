using System.Web;
using System.Web.Optimization;

namespace MVC
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

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/MyStyle/css").Include(
                      "~/Content/MyStylel.css",
                      "~/Content/all.css"));
            bundles.Add(new ScriptBundle("~/MyScript/js").Include(
                       "~/Scripts/MyScript.js", "~/Scripts/jquery.js"));


            bundles.Add(new StyleBundle("~/templatePatient/css").Include(
                     "~/Content/style2.css"));


            bundles.Add(new StyleBundle("~/fontawesome/css").Include(
               
                      "~/vendor/font-awesome-4.7/css/font-awesome.min.css",
                      "~/vendor/font-awesome-5/css/fontawesome-all.min.css"
                     ));


            bundles.Add(new StyleBundle("~/templateDoctors/css").Include(
                      "~/css/font-face.css",
                      "~/vendor/font-awesome-4.7/css/font-awesome.min.css",
                      "~/vendor/font-awesome-5/css/fontawesome-all.min.css",
                      "~/vendor/mdi-font/css/material-design-iconic-font.min.css",
                      "~/vendor/bootstrap-4.1/bootstrap.min.css",
                      "~/vendor/animsition/animsition.min.css",
                      "~/vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css",
                      "~/vendor/wow/animate.css",
                      "~/vendor/css-hamburgers/hamburgers.min.css",
                      "~/vendor/slick/slick.css",
                      "~/vendor/select2/select2.min.css",
                      "~/vendor/perfect-scrollbar/perfect-scrollbar.css",
                      "~/css/theme.css"));

            bundles.Add(new ScriptBundle("~/templateDoctors/js").Include(
                      "~/vendor/jquery-3.2.1.min.js", "~/vendor/bootstrap-4.1/popper.min.js",
                      "~/vendor/bootstrap-4.1/bootstrap.min.js",
                      "~/vendor/slick/slick.min.js",
                      "~/vendor/wow/wow.min.js",
                      "~/vendor/animsition/animsition.min.js",
                      "~/vendor/bootstrap-progressbar/bootstrap-progressbar.min.js",
                      "~/vendor/counter-up/jquery.waypoints.min.js",
                      "~/vendor/counter-up/jquery.counterup.min.js",
                      "~/vendor/circle-progress/circle-progress.min.js",
                      "~/vendor/perfect-scrollbar/perfect-scrollbar.js",
                      "~/vendor/chartjs/Chart.bundle.min.js",
                      "~/vendor/select2/select2.min.js",
                      "~/js/main.js"));


        }
    }
}
