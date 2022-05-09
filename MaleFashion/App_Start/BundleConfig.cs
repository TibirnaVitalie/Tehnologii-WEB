using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MaleFashion.Web.App_Start
{
     public static class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {
               bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/elegant-icons/css").Include("~/Vendors/elegant-icons/elegant-icons.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/magnific-popup/css").Include("~/Vendors/magnific-popup/magnific-popup.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/nice-select/css").Include("~/Vendors/nice-select/nice-select.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/owl-carousel/css").Include("~/Vendors/owl-carousel/owl.carousel.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/slicknav/css").Include("~/Vendors/slicknav/slicknav.min.css", new CssRewriteUrlTransform()));
               bundles.Add(new StyleBundle("~/bundles/main/css").Include("~/Content/scss/style.css", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include("~/Scripts/jquery-3.3.1.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include("~/Scripts/bootstrap.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/nice-select/js").Include("~/Vendors/jquery/jquery.nice-select.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/nicescroll/js").Include("~/Vendors/jquery/jquery.nicescroll.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/magnific-popup/js").Include("~/Vendors/jquery/jquery.magnific-popup.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/countdown/js").Include("~/Vendors/jquery/jquery.countdown.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/slicknav/js").Include("~/Vendors/jquery/jquery.slicknav.js"));
               bundles.Add(new ScriptBundle("~/bundles/mixitup/js").Include("~/Vendors/mixitup/mixitup.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/owl-carousel/js").Include("~/Vendors/owl-carousel/owl.carousel.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/unobtrusive/js").Include("~/Scripts/jquery.unobtrusive-ajax.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/main/js").Include("~/Scripts/main.js"));
          }
     }
}