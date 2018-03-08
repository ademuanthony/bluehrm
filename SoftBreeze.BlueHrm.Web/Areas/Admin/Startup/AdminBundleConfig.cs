using System.Web.Optimization;
using SoftBreeze.BlueHrm.Web.Bundling;

namespace SoftBreeze.BlueHrm.Web.Areas.Admin.Startup
{
    public static class MpaBundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //LIBRARIES

            AddMpaCssLibs(bundles, false);
            AddMpaCssLibs(bundles, true);

            bundles.Add(
                new ScriptBundle("~/Bundles/admin/libs/js")
                    .Include(
                        ScriptPaths.Json2,
                        ScriptPaths.JQuery,
                        ScriptPaths.JQuery_Migrate,
                        ScriptPaths.JQuery_UI,
                        ScriptPaths.JQuery_Validation,
                        ScriptPaths.Bootstrap,
                        ScriptPaths.Bootstrap_Hover_Dropdown,
                        ScriptPaths.JQuery_Slimscroll,
                        ScriptPaths.JQuery_BlockUi,
                        ScriptPaths.JQuery_Cookie,
                        ScriptPaths.JQuery_Uniform,
                        ScriptPaths.JQuery_Ajax_Form,
                        ScriptPaths.JQuery_jTable,
                        ScriptPaths.Morris,
                        ScriptPaths.Morris_Raphael,
                        ScriptPaths.JQuery_Sparkline,
                        ScriptPaths.JsTree,
                        ScriptPaths.Bootstrap_Switch,
                        ScriptPaths.SpinJs,
                        ScriptPaths.SpinJs_JQuery,
                        ScriptPaths.SweetAlert,
                        ScriptPaths.Toastr,
                        ScriptPaths.MomentJs,
                        ScriptPaths.Bootstrap_DateRangePicker,
                        ScriptPaths.Bootstrap_Select,
                        ScriptPaths.Underscore,
                        ScriptPaths.Abp,
                        ScriptPaths.Abp_JQuery,
                        ScriptPaths.Abp_Toastr,
                        ScriptPaths.Abp_BlockUi,
                        ScriptPaths.Abp_SpinJs,
                        ScriptPaths.Abp_SweetAlert,
                        ScriptPaths.Abp_jTable
                    ).ForceOrdered()
                );

            //COMMON (for MPA)
            bundles.Add(
                new ScriptBundle("~/Bundles/Admin/Common/js")
                    .IncludeDirectory("~/Areas/Admin/Common/Scripts", "*.js", true)
                    .ForceOrdered()
                );

            //METRONIC

            AddAppMetrinicCss(bundles, isRTL: false);
            AddAppMetrinicCss(bundles, isRTL: true);

            bundles.Add(
              new ScriptBundle("~/Bundles/Admin/metronic/js")
                  .Include(
                      "~/metronic/assets/global/scripts/app.js",
                      "~/metronic/assets/admin/layout4/scripts/layout.js"
                  ).ForceOrdered()
              );
        }

        private static void AddMpaCssLibs(BundleCollection bundles, bool isRTL)
        {
            bundles.Add(
                new StyleBundle("~/Bundles/Admin/libs/css" + (isRTL ? "RTL" : ""))
                    .Include(StylePaths.JQuery_UI, new CssRewriteUrlTransform())
                    .Include(StylePaths.Jtable_JQueryUi, new CssRewriteUrlTransform())
                    .Include(StylePaths.FontAwesome, new CssRewriteUrlTransform())
                    .Include(StylePaths.Simple_Line_Icons, new CssRewriteUrlTransform())
                    .Include(StylePaths.FamFamFamFlags, new CssRewriteUrlTransform())
                    .Include(isRTL ? StylePaths.BootstrapRTL : StylePaths.Bootstrap, new CssRewriteUrlTransform())
                    .Include(StylePaths.JQuery_Uniform, new CssRewriteUrlTransform())
                    .Include(StylePaths.JsTree, new CssRewriteUrlTransform())
                    .Include(StylePaths.Morris)
                    .Include(StylePaths.SweetAlert)
                    .Include(StylePaths.Toastr)
                    .Include(StylePaths.Bootstrap_DateRangePicker)
                    .Include(StylePaths.Bootstrap_Switch)
                    .Include(StylePaths.Bootstrap_Select)
                    .ForceOrdered()
                );
        }

        private static void AddAppMetrinicCss(BundleCollection bundles, bool isRTL)
        {
            bundles.Add(
                new StyleBundle("~/Bundles/Admin/metronic/css" + (isRTL ? "RTL" : ""))
                    .Include("~/metronic/assets/global/css/components-md" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlTransform())
                    .Include("~/metronic/assets/global/css/plugins-md" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlTransform())
                    .Include("~/metronic/assets/admin/layout4/css/layout" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlTransform())
                    .Include("~/metronic/assets/admin/layout4/css/themes/light" + (isRTL ? "-rtl" : "") + ".css", new CssRewriteUrlTransform())
                    .ForceOrdered()
                );
        }
    }
}