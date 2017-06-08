using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FoodMap.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            /*new ScriptBundle("自己指定的JS檔虛擬位置")
              .Include("實體JS檔案存放位置")*/
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                  .Include("~/Scripts/jquery-{version}.js"
                        ));

            /*new StyleBundle("自己指定的css檔虛擬位置")
              .Include("實體css檔案存放位置")*/
            bundles.Add(new StyleBundle("~/bundles/css")
              .Include("~/Content/themes/base/autocomplete.css",
                       "~/Content/themes/base/button.css"
                    ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"
                        , "~/Scripts/jquery.unobtrusive*"));

            //當設定為true時,輸出則會顯示壓縮後的檔案
            //當為false,輸出則顯示個別檔案
            BundleTable.EnableOptimizations = true;

        }
    }
}