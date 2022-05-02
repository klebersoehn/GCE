using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace GCE.Web
{
    public class BundleConfig
    {
        public class AsIsBundleOrderer : IBundleOrderer
        {
            public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
            {
                return files;
            }
        }

        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var bundle = new ScriptBundle("~/bundles/jquery") { Orderer = new AsIsBundleOrderer() };

            bundle.Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.mask.js")
                .Include("~/Scripts/jquery.maskMoney.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.js")
                .Include("~/Scripts/jquery.validate-vsdoc.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")
                .Include("~/Scripts/globalize.js")
                .Include("~/Scripts/globalize.culture.pt-BR.js")
                .Include("~/Scripts/jquery.validate.globalize.js")                
                .Include("~/Scripts/script.js");

            bundles.Add(bundle);

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender com ela. Após isso, quando você estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

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
