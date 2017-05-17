using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using EtNet_BLL;
using EtNet_Models;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace EtNet_Web.Pages.Product
{
    public partial class TargetEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                InitData();
        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="targetId"></param>
        private void InitData()
        {
            object typeId = Request.QueryString["typeid"]; //标的种类编号
            object targetId = Request.QueryString["targetid"];
            object action = Request.QueryString["action"];
            TargetProperty targetModel = new TargetProperty();
            TargetPropertyManager targetBLL = new TargetPropertyManager();
            targetModel = targetBLL.GetModel(Convert.ToInt32(typeId), Convert.ToInt32(targetId));


            if (typeId == null || action == null || typeId.ToString() == string.Empty || action.ToString() == string.Empty)
                return;
            if (action.ToString() == "edit" && targetId != null && targetId.ToString() != string.Empty)
            {
                txtName.Text = targetModel.PropertyName;
                txtNum.Text = targetModel.PropertyNO;

                if (targetModel.MainFlag != null)
                {
                    if (targetModel.MainFlag == true)
                        chkMain.SelectedIndex = 0;
                    else
                        chkMain.SelectedIndex = 1;

                }
                if (targetModel.IsRequired != null)
                {
                    this.isrequired.Checked = (bool)targetModel.IsRequired;
                }
                else
                {
                    this.isrequired.Checked = false;
                }

                //根据数据类型设定选中项(0：文字描述；3：是非判断；5：日期；9：多选一)
                ListItem item = rdoDataType.Items.FindByValue(targetModel.PropertyType.ToString());
                item.Selected = true;
                ListItem selItem = rdoDataType.Items.FindByValue("9");
                if (targetModel.PropertyType == 9)
                {
                    selItem.Enabled = true;
                    List<TargetEnum> enumModel = new List<TargetEnum>();
                    TargetEnumManager enumBLL = new TargetEnumManager();

                    enumModel = enumBLL.GetModelList(string.Format("EnumTypeId={0}", targetModel.EnumTypeId));
                    if (enumModel.Count > 0)
                    {
                        foreach (TargetEnum enumItem in enumModel)
                        {
                            LtlEnum.Text += string.Format("<tr><td><input class='tbxprocess' value='{0}' type='text' /></td><td><img class='add imgBtn' onclick='addRow()' alt='添加一行' src='Image/add.png' /></td></tr>", enumItem.EnumValue);
                        }
                    }
                    else
                    {
                        LtlEnum.Text = "<tr><td><input class='tbxprocess' type='text' /></td><td><img class='add imgBtn' onclick='addRow()' alt='添加一行' src='Image/add.png' /><img class='delete imgBtn' onclick='delRow(this)' alt='删除' src='Image/backto.png' /></td></tr>";
                    }
                    this.HidShow.Value = "true";
                }
                else
                {
                    selItem.Enabled = false;
                    this.HidShow.Value = "false";
                }
                rdoDataType.Items.FindByValue("0").Enabled = rdoDataType.Items.FindByValue("3").Enabled =
                    rdoDataType.Items.FindByValue("5").Enabled = !selItem.Enabled;
            }
                //自动生成标的编号
            else if (action.ToString() == "new")
            {
                StringBuilder num = new StringBuilder();
                TargetTypeManager typeBll = new TargetTypeManager();
                TargetType type = typeBll.GetModel(Convert.ToInt32(typeId));
                for (int i = 1; i < 100; i++)
                {
                    num.Append(type.TypeNo);

                    if (i.ToString().Length == 1)
                        num.Append("0");

                    num.Append(i.ToString());
                    if (!ExitsNum(num.ToString()))
                        break;
                    else
                        num.Clear();
                }
                txtNum.Text = num.ToString();

                LtlEnum.Text = "<tr><td><input class='tbxprocess' type='text' /></td><td><img class='add imgBtn' onclick='addRow()' alt='添加一行' src='Image/add.png' /><img class='delete imgBtn' onclick='delRow(this)' alt='删除' src='Image/backto.png' /></td></tr>";
            }
        }

        /// <summary>
        /// 判断是否存在该编号
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private bool ExitsNum(string num)
        {
            TargetPropertyManager targetBLL = new TargetPropertyManager();
            string where = string.Format("PropertyNO = '{0}'", num);
            DataTable dt = targetBLL.GetList(where);
            return dt.Rows.Count > 0 ? true : false;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            object typeId = Request.QueryString["typeid"];
            object targetId = Request.QueryString["targetid"];
            object action = Request.QueryString["action"];

            if (typeId == null || action == null || typeId.ToString() == string.Empty || action.ToString() == string.Empty)
                return;

            bool flag = false;
            if (action.ToString() == "edit" && targetId != null && targetId.ToString() != string.Empty)
                flag = UpdateAction(Convert.ToInt32(typeId), Convert.ToInt32(targetId));
            else if (action.ToString() == "new")
                flag = AddAction(Convert.ToInt32(typeId));

            if (flag)
                Response.Redirect("TargetManager.aspx");
            else
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script>alert('保存数据失败')</script>");
        }


        private bool UpdateAction(int typeId, int targetId)
        {
            TargetProperty targetModel = new TargetProperty();
            TargetPropertyManager targetBLL = new TargetPropertyManager();

            targetModel = targetBLL.GetModel(typeId, targetId);
            if (HidMainFlag.Value == string.Empty)
            {
                targetModel.MainFlag = null;
            }
            else
            {
                targetModel.MainFlag = HidMainFlag.Value == "chkMain_0" ? true : false;
            }

            targetModel.IsRequired = this.isrequired.Checked;//是否必填

            targetModel.PropertyName = txtName.Text;
            targetModel.PropertyType = Convert.ToInt32(rdoDataType.SelectedValue);

            if (rdoDataType.Items.FindByValue("9").Selected)//数据类型为多选一
            {
                TargetEnum enumModel = new TargetEnum();
                TargetEnumManager enumBLL = new TargetEnumManager();

                string temp = HidItem.Value;
                if (temp.EndsWith("$￥$"))
                    temp = temp.TrimEnd("$￥$".ToCharArray());
                temp = temp.Replace("$￥$", "$");
                string[] enumValues = temp.Split('$');

                int id = targetModel.EnumTypeId;

                enumBLL.Delete(id);

                enumModel.EnumTypeId = id;
                for (int i = 0; i < enumValues.Count(); i++)
                {
                    enumModel.EnumId = i + 1;
                    enumModel.EnumValue = enumValues[i];
                    enumBLL.Add(enumModel);
                }

            }
            return targetBLL.Update(targetModel);

        }

        /// <summary>
        /// 添加标的信息
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        private bool AddAction(int typeId)
        {
            TargetProperty targetModel = new TargetProperty();
            TargetPropertyManager targetBLL = new TargetPropertyManager();

            TargetEnum enumModel = new TargetEnum();
            TargetEnumManager enumBLL = new TargetEnumManager();

            if (HidMainFlag.Value == string.Empty)
            {
                targetModel.MainFlag = null;
            }
            else
            {
                targetModel.MainFlag = HidMainFlag.Value == "chkMain_0" ? true : false; //判断是否是主标
            }

            targetModel.IsRequired = this.isrequired.Checked; //判断是否必填

            targetModel.PropertyName = txtName.Text; //标的描述
            targetModel.PropertyType = Convert.ToInt32(rdoDataType.SelectedValue); //数据类型
            try
            {
                targetModel.PropertyId = targetBLL.GetMaxID(typeId) + 1;//自动生成
            }
            catch (Exception)
            {
                targetModel.PropertyId = 0;
            }
            targetModel.EnumTypeId = 0; //属性数据关联id
            targetModel.PropertyNO = txtNum.Text; //标的编号
            targetModel.TargetTypeId = typeId; //标的种类关联id

            if (rdoDataType.Items.FindByValue("9").Selected)//数据类型为多选一
            {
                targetModel.EnumTypeId = enumBLL.GetMaxId() + 1;

                enumModel.EnumTypeId = enumBLL.GetMaxId() + 1;

                string temp = HidItem.Value;
                if (temp.EndsWith("$￥$"))
                    temp = temp.TrimEnd("$￥$".ToCharArray());
                temp = temp.Replace("$￥$", "$");
                string[] enumValues = temp.Split('$');

                for (int i = 0; i < enumValues.Count(); i++)
                {
                    enumModel.EnumId = i + 1;
                    enumModel.EnumValue = enumValues[i];
                    enumBLL.Add(enumModel);
                }
            }

            return targetBLL.Add(targetModel);
        }

    }
}