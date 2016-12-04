/* http://www.zkea.net/ Copyright 2016 ZKEASOFT http://www.zkea.net/licenses */
using Easy.MetaData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ZKEACMS.MetaData;
using ZKEACMS.Widget;

namespace ZKEACMS.Article.Models
{
    [ViewConfigure(typeof(ArticleSummaryWidgetMetaData)),Table("ArticleSummaryWidget")]
    public class ArticleSummaryWidget : BasicWidget
    {
        public string SubTitle { get; set; }
        public string DetailLink { get; set; }
        public string Summary { get; set; }
        public string Style { get; set; }
    }
    class ArticleSummaryWidgetMetaData : WidgetMetaData<ArticleSummaryWidget>
    {
        protected override void ViewConfigure()
        {
            base.ViewConfigure();
            ViewConfig(m => m.SubTitle).AsTextBox().Order(NextOrder());
            ViewConfig(m => m.Style).AsDropDownList().Order(NextOrder())
                .DataSource(() =>
                    new Dictionary<string, string> { 
                    { "bs-callout-default", "默认" },
                    { "bs-callout-danger", "危险" }, 
                    { "bs-callout-warning", "警告" }, 
                    { "bs-callout-info", "信息" } ,
                    { "bs-callout-success", "成功" } 
            }); ;
            ViewConfig(m => m.DetailLink).AsTextBox().Order(NextOrder()).AddClass("select").AddProperty("data-url", Urls.SelectPage);
            ViewConfig(m => m.Summary).AsTextArea().Order(NextOrder()).AddClass("html");
        }
    }

}