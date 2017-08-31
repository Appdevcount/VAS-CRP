using System.Web.Optimization;

namespace VAS_CRP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterLayout(bundles);
            RegisterShared(bundles);
            RegisterAccount(bundles);
            //BundleTable.EnableOptimizations = true;
        }

        private static void RegisterShared(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Scripts/Shared/Layout").Include(
                "~/Scripts/Shared/_Layout.js"));
        }
        private static void RegisterAccount(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Scripts/Account/Login").Include(
                "~/Scripts/Account/Login.js"));

            bundles.Add(new ScriptBundle("~/bundles/Scripts/Account/Register").Include(
                "~/Scripts/Account/Register.js"));
        }
        private static void RegisterLayout(BundleCollection bundles)
        {
            // bootstrap
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/bootstrap/js").Include(
                "~/Content/ACustom/bootstrap/js/bootstrap.min.js"));

            //bundles.Add(new StyleBundle("~/bundles/Content/ACustom/bootstrap/css").Include(
            //    "~/Content/ACustom/bootstrap/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/bootstrap/css").Include(
                "~/Content/ACustom/bootstrap/css/bootstrap.min.css"));

            // dist
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/dist/js").Include(
                "~/Content/ACustom/dist/js/app.js"));

            //bundles.Add(new StyleBundle("~/bundles/Content/ACustom/dist/css").Include(
            //    "~/Content/ACustom/dist/css/admin-lte.min.css"));
            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/dist/css").Include(
          "~/Content/ACustom/dist/css/admin-lte.min.css"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/dist/css/skins").Include(
                "~/Content/ACustom/dist/css/skins/_all-skins.min.css"));

            // plugins | datatables
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/datatables/js").Include(
                                         "~/Content/ACustom/plugins/datatables/js/jquery.dataTables.min.js",
                                         "~/Content/ACustom/plugins/datatables/js/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/datatables/css").Include(
                                        "~/Content/ACustom/plugins/datatables/css/dataTables.bootstrap.css"));

            // plugins | datepicker
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/datepicker/js").Include(
                                         "~/Content/ACustom/plugins/datepicker/js/bootstrap-datepicker.js",
                                         "~/Content/ACustom/plugins/datepicker/js/locales/bootstrap-datepicker*"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/datepicker/css").Include(
                                        "~/Content/ACustom/plugins/datepicker/css/datepicker3.css"));

            // plugins | daterangepicker
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/daterangepicker/js").Include(
                                         "~/Content/ACustom/plugins/daterangepicker/js/moment.min.js",
                                         "~/Content/ACustom/plugins/daterangepicker/js/daterangepicker.js"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/daterangepicker/css").Include(
                                        "~/Content/ACustom/plugins/daterangepicker/css/daterangepicker-bs3.css"));

            // plugins | fastclick
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/fastclick/js").Include(
                                         "~/Content/ACustom/plugins/fastclick/js/fastclick.min.js"));
            
            // plugins | font-awesome
            //bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/font-awesome/css").Include(
            //                            "~/Content/ACustom/plugins/font-awesome/css/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/font-awesome/css").Include(
                                        "~/Content/ACustom/plugins/font-awesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));
            //for font-awesome resources not loading issue- referred this - http://stackoverflow.com/questions/22700385/font-awesome-not-working-bundleconfig-in-mvc5
            
            // plugins | icheck
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/icheck/js").Include(
                                         "~/Content/ACustom/plugins/icheck/js/icheck.min.js"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/icheck/css").Include(
                                        "~/Content/ACustom/plugins/icheck/css/all.css"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/icheck/css/flat").Include(
                                        "~/Content/ACustom/plugins/icheck/css/flat/flat.css"));

            //bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/icheck/css/sqare/blue").Include(
            //                            "~/Content/ACustom/plugins/icheck/css/sqare/blue.css"));
            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/icheck/css/sqare/blue").Include(
                                        "~/Content/ACustom/plugins/icheck/css/sqare/blue.css"));

            // plugins | input-mask
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/input-mask/js").Include(
                                         "~/Content/ACustom/plugins/input-mask/js/jquery.inputmask.js",
                                         "~/Content/ACustom/plugins/input-mask/js/jquery.inputmask.date.extensions.js",
                                         "~/Content/ACustom/plugins/input-mask/js/jquery.inputmask.extensions.js"));

            // plugins | ionicons
            //bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/ionicons/css").Include(
            //                            "~/Content/ACustom/plugins/ionicons/css/ionicons.min.css"));
            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/ionicons/css").Include(
                                        "~/Content/ACustom/plugins/ionicons/css/ionicons.min.css"));
            
            // plugins | jquery
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/jquery/js").Include(
                                         "~/Content/ACustom/plugins/jquery/js/jQuery-2.1.4.min.js"));

            // plugins | jquery-validate
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/jquery-validate/js").Include(
                                         "~/Content/ACustom/plugins/jquery-validate/js/jquery.validate*"));

            // plugins | jquery-ui
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/jquery-ui/js").Include(
                                         "~/Content/ACustom/plugins/jquery-ui/js/jquery-ui.min.js"));

            // plugins | jvectormap
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/jvectormap/js").Include(
                                         "~/Content/ACustom/plugins/jvectormap/js/jquery-jvectormap-1.2.2.min.js",
                                         "~/Content/ACustom/plugins/jvectormap/js/jquery-jvectormap-world-mill-en.js"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/jvectormap/css").Include(
                                        "~/Content/ACustom/plugins/jvectormap/css/jquery-jvectormap-1.2.2.css"));
            
            // plugins | momentjs
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/momentjs/js").Include(
                                         "~/Content/ACustom/plugins/momentjs/js/moment.min.js"));
            
            // plugins | slimscroll
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/slimscroll/js").Include(
                                         "~/Content/ACustom/plugins/slimscroll/js/jquery.slimscroll.min.js"));
            
            // plugins | timepicker
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/timepicker/js").Include(
                                         "~/Content/ACustom/plugins/timepicker/js/bootstrap-timepicker.min.js"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/timepicker/css").Include(
                                        "~/Content/ACustom/plugins/timepicker/css/bootstrap-timepicker.min.css"));
            
            // plugins | select2
            bundles.Add(new ScriptBundle("~/bundles/Content/ACustom/plugins/select2/js").Include(
                                         "~/Content/ACustom/plugins/select2/js/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/bundles/Content/ACustom/plugins/select2/css").Include(
                                        "~/Content/ACustom/plugins/select2/css/select2.min.css"));
            
        }
    }
}
