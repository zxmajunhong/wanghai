using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI;
namespace Common
{
    public static class LoadJsControl
    {
        //加载编辑器
        private static string KindEditor = "Content/KindEditor/";

        public static void LoadEditor(string TextAreaId, string FormId,bool IsSimple=true,bool HasUploadImg=false)

        {
            if (IsSimple)
            {
                LoadEditorSimple(TextAreaId, FormId, HasUploadImg);
            }
            else
            {
                Description.AddCss(KindEditor + "themes/default/default.css");
                Description.AddCss(KindEditor + "plugins/code/prettify.css");
                Description.AddJavaScript(KindEditor + "kindeditor.js");
                Description.AddJavaScript(KindEditor + "lang/zh_CN.js");
                Description.AddJavaScript(KindEditor + "plugins/code/prettify.js");
                Page page = (Page)System.Web.HttpContext.Current.Handler;
                HtmlGenericControl Js = new HtmlGenericControl();
                string localhost = WebConfig.domain + "/";
                Js.TagName = "script";
                Js.Attributes.Add("type", "text/javascript");
                Js.Attributes.Add("charset", "UTF-8");
                Js.InnerHtml = "KindEditor.ready(function (K) {var editor1 = K.create('#" + TextAreaId + "', {cssPath: '" + localhost + KindEditor + "plugins/code/prettify.css',uploadJson: '" + localhost + KindEditor + "ashx/upload_json.ashx',fileManagerJson: '" + KindEditor + "ashx/file_manager_json.ashx',allowFileManager: true,afterCreate: function () {var self = this;K.ctrl(document, 13, function () {self.sync();K('form[name=" + FormId + "]')[0].submit();});K.ctrl(self.edit.doc, 13, function () {self.sync();K('form[name=" + FormId + "]')[0].submit();});}});prettyPrint();}); ";
                page.Page.Header.Controls.Add(Js);
            }
        }

        private  static void LoadEditorSimple(string TextAreaId, string FormId,bool HasUploadImg=false)
        {
            Description.AddCss(KindEditor+"themes/default/default.css");
            Description.AddJavaScript(KindEditor+"kindeditor.js");
            Description.AddJavaScript(KindEditor+"lang/zh_CN.js");

            Page page = (Page)System.Web.HttpContext.Current.Handler;
            HtmlGenericControl Js = new HtmlGenericControl();
            string localhost = WebConfig.domain + "/";
            Js.TagName = "script";
            Js.Attributes.Add("type", "text/javascript");
            Js.Attributes.Add("charset", "UTF-8");
            string upimg = "";
            string img = "";
            if (HasUploadImg)
            {
                img = "'image',";
                upimg = "allowImageUpload : true,";
            }
            else
            {
                upimg = "allowImageUpload : false,";
            }
            Js.InnerHtml = "KindEditor.ready(function(K) {K.create('#" + TextAreaId + "', {uploadJson: '" + localhost + KindEditor+"ashx/upload_json.ashx',fileManagerJson: '"+KindEditor+"ashx/file_manager_json.ashx',allowFileManager: true,resizeType : 1,allowPreviewEmoticons : false,"+upimg+"items : ['fontname', 'fontsize', '|', 'textcolor', 'bgcolor', 'bold', 'italic', 'underline','removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist','insertunorderedlist', '|', 'emoticons',"+img+" 'link']});}); ";
            page.Page.Header.Controls.Add(Js);
        }
    }
}
