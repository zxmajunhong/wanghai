using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
namespace Common
{
   public class CheckBox
    {
        //绑定checkboxlist
        public static void BindCheckBoxList(CheckBoxList cb, DataSet ds, string DataText, string DataValue)
        {
            cb.DataSource = ds;
            cb.DataTextField = DataText;
            cb.DataValueField = DataValue;
            cb.DataBind();
        }
        public static string GetChecked(CheckBoxList checkList, string separator)
        {
            string selval = "";
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].Selected)
                {
                    selval += checkList.Items[i].Value + separator;
                }
            }
            if (selval.Length > 1)
            {
                selval = selval.Substring(0, selval.LastIndexOf(separator));
            }
            return selval;
        }
        public static string SetChecked(CheckBoxList checkList, string SelectValueLists, string separator)
        {
            SelectValueLists = separator + SelectValueLists + separator;        //例如："0,1,1,2,1"->",0,1,1,2,1,"
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                checkList.Items[i].Selected = false;
                string val = separator + checkList.Items[i].Value + separator;
                if (SelectValueLists.IndexOf(val) != -1)
                {
                    checkList.Items[i].Selected = true;
                    SelectValueLists = SelectValueLists.Replace(val, separator);        //然后从原来的值串中删除已经选中了的
                    if (SelectValueLists == separator)        //selval的最后一项也被选中的话，此时经过Replace后，只会剩下一个分隔符
                    {
                        SelectValueLists += separator;        //添加一个分隔符
                    }
                }
            }
            SelectValueLists = SelectValueLists.Substring(1, SelectValueLists.Length - 2);        //除去前后加的分割符号
            return SelectValueLists;
        }
    }
}
