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
    public partial class LoadTargetHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] != null)
            {
                string typeID = Request.QueryString["type"].ToString();
                if (typeID != string.Empty)
                {
                    int? targetTypeID = GetTargetType(typeID);
                    if (targetTypeID != null)
                    {
                        RpPropertyBindData(Convert.ToInt32(targetTypeID));
                    }
                }
            }
        }

        /// <summary>
        /// 绑定标的属性列表（repeater控件）
        /// </summary>
        private void RpPropertyBindData(int targetTypeId)
        {
            TargetPropertyManager tpManager = new TargetPropertyManager();
            string where = string.Format("TargetTypeId = {0} and IsRequired='true'", targetTypeId);

            rpTargetProperty.DataSource = tpManager.GetList(where);
            rpTargetProperty.DataBind();

        }

        private int? GetTargetType(string proTypeID)
        {
            TargetTypeManager targetType = new TargetTypeManager();

            ProductTypeManager proTypeBLL = new ProductTypeManager();
            ProductType proTypeModel = proTypeBLL.GetModel(proTypeID);
            if (proTypeModel != null)
            {
                TargetType tgModel = targetType.GetModel(Convert.ToInt32(proTypeModel.TargetTypeId));
                if (tgModel != null)
                {
                    ltrTargetType.Text = tgModel.TypeName;
                }
                return proTypeModel.TargetTypeId;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 根据数据类型生成HTML
        /// </summary>
        /// <param name="dataType">数据类型</param>
        /// <param name="typeEnumID">如果为多选一，对应的选项表ID</param>
        /// <returns>生成的HTML</returns>
        public string GetHtmlControl(int dataType, object typeEnumID)
        {
            TargetEnumManager enumBLL = new TargetEnumManager();

            StringBuilder html = new StringBuilder();
            switch (dataType)
            {
                //文字描述
                case 0:
                    html.Append("<input type='text' dataType='Require' msg='请确认标的信息都已经填写' />");
                    break;
                //是非判断
                case 3:
                    html.Append("<select><option value='1' selected='selected'>是</option><option value='0'>否</option></select>");
                    break;
                //日期
                case 5:
                    html.Append("<input type='text' class='Wdate' dataType='Require' msg='请确认标的信息都已经填写' onFocus='WdatePicker({isShowClear:false,readOnly:true})' />");
                    break;
                //多选一
                case 9:
                    if (typeEnumID == null)
                        break;
                    DataTable dtEnum = enumBLL.GetList(string.Format("EnumTypeId={0}", typeEnumID));

                    html.Append("<select>");
                    for (int i = 0; i < dtEnum.Rows.Count; i++)
                    {
                        html.AppendFormat("<option value='{0}' >{1}</option>", i, dtEnum.Rows[i]["EnumValue"]);
                    }
                    html.Append("</select>");
                    break;
                default:
                    break;
            }
            return html.ToString();
        }
    }
}