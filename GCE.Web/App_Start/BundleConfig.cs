using System.Web;
using System.Web.Optimization;

namespace GCE.Web
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/jquery.mask.min.js",
                        "~/Scripts/jquery.maskMoney.js",
                        "~/Scripts/script.js"));

            bundles.Add(new ScriptBundle("~/Scripts/Forms").Include(
                        "~/Scripts/jquery.mask.min.js",
                        "~/Scripts/jquery.maskMoney.js",
                        "~/Scripts/script.js",
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/globalize.js",
                        "~/Scripts/jquery.validate.globalize.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                 "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender com ela. Após isso, quando você estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap5.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/dataTables.bootstrap5.min.css"));
        }
    }
}
