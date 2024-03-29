﻿using System.Web;
using System.Web.Optimization;

namespace ClientWeb
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                      "~/Content/Custom.css"));

            bundles.Add(new ScriptBundle("~/bundles/datapicker").Include(
                      "~/Scripts/jquery.datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/datapicker-php").Include(
                      "~/Scripts/php-date-formatter.min.js"));

            bundles.Add(new StyleBundle("~/Content/datapicker").Include(
                      "~/Content/jquery.datetimepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/file-task").Include(
                        "~/Scripts/Business/Task/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/telefonovalidator").Include(
                        "~/Scripts/Validations/telefonovalidator.js"));
        }
    }
}
