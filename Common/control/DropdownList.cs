using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
namespace Common
{
    public class DropdownList
    {
        public static  void BindDropDownList(DropDownList ddl, DataSet ds, string Text, string Value, string SelectValue, bool showtype)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0].DefaultView;
                ddl.DataTextField = Text;
                ddl.DataValueField = Value;
                if (SelectValue != "")
                {
                    ddl.SelectedValue = SelectValue;
                }
                ddl.DataBind();
                if (showtype)
                {
                    ddl.Items.Insert(0, new ListItem("请选择", ""));
                }
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, new ListItem("暂无数据", ""));
            }
        }

        public static void BindSelect(HtmlSelect ddl, DataSet ds, string Text, string Value, bool showtype = false, string nodata = "暂无数据")
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds.Tables[0].DefaultView;
                ddl.DataTextField = Text;
                ddl.DataValueField = Value;
                
                ddl.DataBind();
                if (showtype)
                {
                    ddl.Items.Insert(0, new ListItem("请选择", ""));
                }
            }
            else
            {
                ddl.Items.Clear();
                ddl.Items.Insert(0, new ListItem(nodata, ""));
            }
        }
    }
}