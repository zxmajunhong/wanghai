using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data;
namespace Common
{
    /// <summary>
    /// 重写基类（页面加载前执行相同方法）
    /// </summary>
    public class MasterModule : IHttpModule
    {
        HttpApplication app;
        public virtual void Init(HttpApplication app)
        {
            this.app = app;
            app.PreRequestHandlerExecute += new EventHandler(HandleEvent);
        }
        public virtual void Dispose()
        {
            app.PreRequestHandlerExecute -= new EventHandler(HandleEvent);
        }
        void HandleEvent(object sender, EventArgs e)
        {
            if (app.Context.Handler is Page)
            {
                Page p = (Page)app.Context.Handler;
                p.Load += new EventHandler(HandleLoad);
            }
        }
        void HandleLoad(object sender, EventArgs e)
        {
            string filename = HttpContext.Current.Request.Path;
            string node = filename.Substring(filename.LastIndexOf("."));
            if (node == ".aspx")
            {
                HttpContext context = app.Context;
                Common.Description.AddCss("Content/css/web.css", 1);
            }
        }

    }
}
