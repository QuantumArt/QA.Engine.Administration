using System.Web.Optimization;

namespace QA.Engine.Administration.WebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", "~/Scripts/jquery.cookie.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/validation-requiredif.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/json2.js",
                "~/Scripts/pmrpc.js",
                "~/Scripts/script.js",
                "~/Scripts/T4MvcJs/T4MvcJs.js"));

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/kendoui/kendo.all.js"));
            bundles.Add(new ScriptBundle("~/bundles/qp").Include("~/Scripts/qp/QP8BackendApi.Interaction.js", "~/Scripts/qp.scripts.js"));
            bundles.Add(new ScriptBundle("~/bundles/contextmenu").Include("~/Scripts/jquery.jeegoocontext.js", "~/Scripts/jquery.livequery.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/shared/menu").Include("~/Scripts/pages/shared/menu.js"));
            bundles.Add(new ScriptBundle("~/bundles/pages/shared/toolbar").Include("~/Scripts/pages/shared/toolbar.js"));
            bundles.Add(new ScriptBundle("~/bundles/pages/sitemap/index").Include(
                "~/Scripts/pages/sitemap/sitemap.crud.dialog.js",
                "~/Scripts/pages/sitemap/sitemap.contextmenu.js",
                "~/Scripts/pages/sitemap/sitemap.tabs.js",
                "~/Scripts/pages/sitemap/sitemap.splitter.js",
                "~/Scripts/pages/sitemap/sitemap.filter.js",
                "~/Scripts/pages/sitemap/sitemap.toolbar.js",
                "~/Scripts/pages/sitemap/sitemap.add.dialog.js",
                "~/Scripts/pages/sitemap/sitemap.remove.dialog.js",
                "~/Scripts/pages/sitemap/sitemap.move.dialog.js",
                "~/Scripts/pages/sitemap/sitemap.treeactions.js",
                "~/Scripts/pages/sitemap/index.js",
                "~/Scripts/pages/sitemap/common.js",
                "~/Scripts/pages/sitemap/regions.js",
                "~/Scripts/pages/sitemap/widgets.js",
                "~/Scripts/pages/sitemap/contentversions.js",
                "~/Scripts/pages/sitemap/info.js",
                "~/Scripts/proxy.client.js"));

            bundles.Add(new ScriptBundle("~/bundles/pages/sitemap/archive").Include(
                "~/Scripts/pages/sitemap/archive.js",
                "~/Scripts/pages/sitemap/sitemap.delete.dialog.js",
                "~/Scripts/pages/sitemap/sitemap.restore.dialog.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css/sitemap/index").Include("~/Content/pages/sitemap/index.css"));
            bundles.Add(new StyleBundle("~/Content/css/sitemap/widgets").Include("~/Content/pages/sitemap/widgets.css"));
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/kendoui/style").Include("~/Content/kendoui/kendo.common.css", "~/Content/kendoui/kendo.default.css"));
            bundles.Add(new StyleBundle("~/Content/contextmenu").Include("~/Content/cm/skins/cm_default/style.css", "~/Content/cm/skins/qp8/jquery.jeegoocontext.qp8.css"));
            BundleTable.EnableOptimizations = false;
        }
    }
}
