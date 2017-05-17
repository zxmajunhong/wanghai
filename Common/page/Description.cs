using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace Common
{
  public static  class Description
    {
      public static  void SetMeta( string Title,string Keyword,string Description)
      {
          Page page = (Page)System.Web.HttpContext.Current.Handler;
          page.Title = Title;
          HtmlMeta keywords = new HtmlMeta(), description = new HtmlMeta();
          keywords.Name = "keywords";
          keywords.Content = Keyword;
          description.Name = "description";
          description.Content = Description;
          page.Header.Controls.Add(keywords);
          page.Header.Controls.Add(description);
      }
      public static void AddCss(string url)
      {
          Page page = (Page)System.Web.HttpContext.Current.Handler;
          HtmlLink link = new HtmlLink(); 
          link.Attributes.Add("type", "text/css"); 
          link.Attributes.Add("rel", "stylesheet"); 
          link.Attributes.Add("href",Common.WebConfig.domain+"/"+ url);//url为css路径 
          page.Page.Header.Controls.Add(link); 
      }
      public static void AddCss(string url,int Position)
      {
          Page page = (Page)System.Web.HttpContext.Current.Handler;
          HtmlLink link = new HtmlLink();
          link.Attributes.Add("type", "text/css");
          link.Attributes.Add("rel", "stylesheet");
          link.Attributes.Add("href", Common.WebConfig.domain + "/" + url);//url为css路径 
          page.Page.Header.Controls.AddAt(Position,link);
      }

      public static void AddJavaScript(string url)
      {
          Page page = (Page)System.Web.HttpContext.Current.Handler;
          HtmlGenericControl myJs = new HtmlGenericControl();

          myJs.TagName = "script";

          myJs.Attributes.Add("type", "text/javascript");

          myJs.Attributes.Add("src", Common.WebConfig.domain+"/" + url);
          myJs.Attributes.Add("charset", "UTF-8");
          page.Page.Header.Controls.Add(myJs);

      }

      public static void AddJsAtForm(string url)
      {
          Page page = (Page)System.Web.HttpContext.Current.Handler;
          HtmlGenericControl JsControl = new HtmlGenericControl("script");
          JsControl.Attributes.Add("type", "text/javascript");
          JsControl.Attributes.Add("src", Common.WebConfig.domain + "/" + url);
          JsControl.Attributes.Add("charset", "UTF-8");
          page.Form.Controls.Add(JsControl); 
      }
    }
}
