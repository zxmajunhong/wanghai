using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Text;
using System.Data;

namespace EtNet_Web.Pages.Policy
{
    public partial class UCTarget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindTarget(int policyID) 
        {
            IList<To_PolicyTarget> targetList = To_PolicyTargetManager.GetListByPolicy(policyID);

            if (targetList.Count > 0)
            {
                rpTargetProperty.DataSource = targetList;
                rpTargetProperty.DataBind();

                TargetTypeManager tpBLL = new TargetTypeManager();
                TargetType tpModel = tpBLL.GetModel(targetList[0].PropertyTypeID);
                if (tpModel != null)
                {
                    ltrTargetType.Text = tpModel.TypeName;
                }
            }
        }

        public string GetValue(object value, int dataType, int id, int typeID)
        {
            StringBuilder html = new StringBuilder();
            switch (dataType)
            {
                //文字描述
                case 0:
                    html.AppendFormat("<input type='text' value='{0}' />", value);
                    break;
                //是非判断
                case 3:
                    if (value.ToString() == "是")
                        html.Append("<select><option value='1' selected='selected'>是</option><option value='0'>否</option></select>");
                    else
                        html.Append("<select><option value='1'>是</option><option value='0' selected='selected'>否</option></select>");
                    break;
                //日期
                case 5:
                    html.AppendFormat("<input type='text' class='Wdate' value='{0}' onFocus='WdatePicker({1}isShowClear:false,readOnly:true{2})' />", value,"{","}");
                    break;
                //多选一
                case 9:
                    TargetPropertyManager tpBLL = new TargetPropertyManager();
                    TargetEnumManager enumBLL = new TargetEnumManager();
                    TargetProperty tpModel = tpBLL.GetModel(typeID, id);
                    if (tpModel != null)
                    {
                        DataTable dtEnum = enumBLL.GetList(string.Format("EnumTypeId={0}", tpModel.EnumTypeId));

                        html.Append("<select>");
                        for (int i = 0; i < dtEnum.Rows.Count; i++)
                        {
                            if (value.ToString().Trim() == dtEnum.Rows[i]["EnumValue"].ToString().Trim())
                                html.AppendFormat("<option value='{0}' selected='selected' >{1}</option>", i, dtEnum.Rows[i]["EnumValue"]);
                            else
                                html.AppendFormat("<option value='{0}' >{1}</option>", i, dtEnum.Rows[i]["EnumValue"]);
                        }
                        html.Append("</select>");
                    }
                    else
                    {
                        html.Append("<select>");
                        html.AppendFormat("<option value='' >{0}</option>", value);
                        html.Append("</select>");
                    }
                    break;
                default:
                    break;
            }
            return html.ToString();
        }
    }
}