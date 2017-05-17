using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;
using EtNet_Models;
using System.Data;

namespace EtNet_Web.Pages.Finance
{
    public partial class Budget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //保单id
                object objPolicyID = Request.QueryString["policy"];
                int policyID = 0;
                //验证参数合法性
                if (objPolicyID == null || !Int32.TryParse(objPolicyID.ToString(), out policyID))
                {
                    form1.InnerHtml = "<p style='font-size:14px;'>参数不正确，请确保保单ID为1-9999999999之间的整数<br /><a href='../Policy/PolicyList.aspx'>返回保单列表</a></p>";
                    return;
                }

                //验证是否存在保单
                if (!ExitsPolicy(policyID))
                {
                    form1.InnerHtml = string.Format("<p style='font-size:14px;'>保单不存在，请确保存在ID为{0}的保单<br /><a href='../Policy/PolicyList.aspx'>返回保单列表</a></p>", policyID);
                    return;
                }

                LoadPremium(policyID);
                LoadRatio();
            }
        }

        /// <summary>
        /// 验证是否存在该保单
        /// </summary>
        /// <param name="policyID">保单ID</param>
        /// <returns></returns>
        private bool ExitsPolicy(int policyID)
        {
            To_Policy policyModel = To_PolicyManager.getTo_PolicyById(policyID);

            return policyModel != null;
        }

        /// <summary>
        /// 加载保费与经济费
        /// </summary>
        /// <param name="policyID">保单ID</param>
        private void LoadPremium(int policyID)
        {
            To_Policy policy = To_PolicyManager.getTo_PolicyById(policyID);
            TxtPremium.Text = policy.TotalPremium.ToString("F2"); //保费
            TxtBrokerage.Text = policy.TotalBrokerage.ToString("F2"); //经济费

            if (policy.IsDaidian == 1)
            {
                TxtExpPremium.Text = policy.TotalPremium.ToString("F2"); //代垫保费
                //DataTable dtPolicyDetail = To_PolicyDetailManager.GetListByPolicy(policyID);

                //if (dtPolicyDetail != null)
                //{
                //    double premium = 0;

                //    for (int i = 0; i < dtPolicyDetail.Rows.Count; i++)
                //    {
                //        premium += Convert.ToDouble(dtPolicyDetail.Rows[i]["premium"]);
                //    }

                //    TxtPremium.Text = premium.ToString("F2"); //保费
                //    TxtExpPremium.Text = premium.ToString("F2"); //代垫保费
                //}
            }
        }

        /// <summary>
        /// 加载默认比率
        /// </summary>
        private void LoadRatio()
        {
            IList<EtNet_Models.Parameter> parameters = ParameterManager.getParameterAll();
            if (parameters.Count > 0)
            {
                EtNet_Models.Parameter parameter = parameters[0];

                TxtZxfRatio.Text = parameter.ConRatio;//咨询费比率
                TxtGlfRatio.Text = parameter.BrokeRatio;//管理费比率
                TxtDklxRatio1.Text = parameter.Rate;//垫款利息比率1
                TxtDklxRatio2.Text = parameter.FreeDay.ToString();//垫款利息比率2
                TxtJjfsjRatio.Text = parameter.BrokeTaxRatio;//经纪费税金比率
                TxtFwfsjRatio.Text = parameter.ServiceTaxRatio;//服务费税金比率
                TxtOtherRatio.Text = parameter.OtherRatio;//其它税金比率
                TxtFwfRatio.Text = parameter.ServiceRatio;
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveData()
        {
            EtNet_Models.To_PolicyBudget budget = new EtNet_Models.To_PolicyBudget();

            //---------------------支出项
            budget.Exp_brokerageFeesTaxes = TxtJjfsj.Text.GetDoubleValue();//经纪费税金
            budget.Exp_brokerageFeesTaxesMark = TxtJjfsjMark.Text;//经纪费税金备注
            budget.Exp_brokerageFeesTaxesRatio = TxtJjfsjRatio.Text.GetDoubleValue();//经纪费税金比率
            budget.Exp_commission = TxtYj.Text.GetDoubleValue();//佣金
            budget.Exp_commissionMark = TxtYjMark.Text;//佣金备注
            budget.Exp_commissionRatio = TxtYjRatio.Text.GetDoubleValue();//佣金比率
            budget.Exp_consultingFees = TxtZxf.Text.GetDoubleValue();//咨询费
            budget.Exp_consultingFeesMark = TxtZxfmark.Text;//咨询费备注
            budget.Exp_consultingFeesRatio = TxtZxfRatio.Text.GetDoubleValue();//咨询费比率
            budget.Exp_interest = null;// TxtDklx.Text.GetDoubleValue();//垫款利息
            budget.Exp_interestMark = TxtDklxMark.Text;//垫款利息备注
            budget.Exp_interestRatio1 = TxtDklxRatio1.Text.GetDoubleValue();//垫款利息比率1
            budget.Exp_interestRatio2 = TxtDklxRatio2.Text.GetDoubleValue();//垫款利息比率2
            budget.Exp_managementFees = TxtGlf.Text.GetDoubleValue();//管理费
            budget.Exp_managementFeesMark = TxtGlfMark.Text;//管理费备注
            budget.Exp_managementFeesRatio = TxtGlfRatio.Text.GetDoubleValue();//管理费比率
            budget.Exp_other1 = TxtExpOther1.Text.GetDoubleValue();//其它支出项1
            budget.Exp_other1Mark = TxtExpOther1Mark.Text;//其它支出项1备注
            budget.Exp_other1Ratio = TxtExpOther1Ratio.Text.GetDoubleValue();//其它支出项1比率
            budget.Exp_other2 = TxtExpOther2.Text.GetDoubleValue();//其它支出项2
            budget.Exp_other2Mark = TxtExpOther2Mark.Text;//其它支出项2备注
            budget.Exp_other2Ratio = TxtExpOther2Ratio.Text.GetDoubleValue();//其它支出项2比率
            budget.Exp_other3 = TxtExpOther3.Text.GetDoubleValue();//其它支出项3
            budget.Exp_other3Mark = TxtExpOther3Mark.Text;//其它支出项3备注
            budget.Exp_other3Ratio = TxtExpOther3Ratio.Text.GetDoubleValue();//其它支出项3比率
            budget.Exp_other4 = TxtExpOther4.Text.GetDoubleValue();//其它支出项4
            budget.Exp_other4Mark = TxtExpOther4Mark.Text;//其它支出项4备注
            budget.Exp_other4Ratio = TxtExpOther4Ratio.Text.GetDoubleValue();//其它支出项4比率
            budget.Exp_other5 = TxtExpOther5.Text.GetDoubleValue();//其它支出项5
            budget.Exp_other5Mark = TxtExpOther5Mark.Text;//其它支出项5备注
            budget.Exp_other5Ratio = TxtExpOther5Ratio.Text.GetDoubleValue();//其它支出项5比率
            budget.Exp_otherTaxes = TxtOther.Text.GetDoubleValue();//其它税金
            budget.Exp_otherTaxesRatio = TxtOtherRatio.Text.GetDoubleValue();//其它税金比率
            budget.Exp_otherTaxesRatioMark = TxtOtherMark.Text;//其它税金备注
            budget.Exp_serviceCharge = TxtFwf.Text.GetDoubleValue();//服务费
            budget.Exp_serviceChargeMark = TxtFwfMark.Text;//服务费备注
            budget.Exp_serviceChargeRatio = TxtFwfRatio.Text.GetDoubleValue();//服务费比率
            budget.Exp_serviceChargeTaxes = TxtFwfsj.Text.GetDoubleValue();//服务费税金
            budget.Exp_serviceChargeTaxesMark = TxtFwfsjMark.Text;//服务费税金备注
            budget.Exp_serviceChargeTaxesRatio = TxtFwfsjRatio.Text.GetDoubleValue();//服务费税金比率
            budget.Exp_tiefei = TxtTf.Text.GetDoubleValue();//贴费
            budget.Exp_tiefeiMark = TxtTfMark.Text;//贴费备注
            budget.Exp_tiefeiRatio = TxtTfRatio.Text.GetDoubleValue();//贴费比率

            //---------------------收入项
            budget.Income_brokerageFees = TxtBrokerage.Text.GetDoubleValue();//经纪费
            budget.Income_brokerageFeesMark = TxtBrokerageMark.Text;//经纪费备注
            budget.Income_other1 = TxtIncomeOther1.Text.GetDoubleValue();//其它收入项1
            budget.Income_other1Mark = TxtIncomeOther1Mark.Text;//其它收入项1备注
            budget.Income_other2 = TxtIncomeOther2.Text.GetDoubleValue();//其它收入项2
            budget.Income_other2Mark = TxtIncomeOther2Mark.Text;//其它收入项2备注
            budget.Income_other3 = TxtIncomeOther3.Text.GetDoubleValue();//其它收入项3
            budget.Income_other3Mark = TxtIncomeOther3Mark.Text;//其它收入项3备注
            budget.Income_other4 = TxtIncomeOther4.Text.GetDoubleValue();//其它收入项4
            budget.Income_other4Mark = TxtIncomeOther4Mark.Text;//其它收入项4备注
            budget.Income_other5 = TxtIncomeOther5.Text.GetDoubleValue();//其它收入项5
            budget.Income_other5Mark = TxtIncomeOther5Mark.Text;//其它收入项5备注
            budget.Income_other6 = TxtIncomeOther6.Text.GetDoubleValue();//其它收入项6
            budget.Income_other6Mark = TxtIncomeOther6Mark.Text;//其它收入项6备注
            budget.Income_other7 = TxtIncomeOther7.Text.GetDoubleValue();//其它收入项7
            budget.Income_other7Mark = TxtIncomeOther7Mark.Text;//其它收入项7备注
            budget.Income_other8 = TxtIncomeOther8.Text.GetDoubleValue();//其它收入项8
            budget.Income_other8Mark = TxtIncomeOther8Mark.Text;//其它收入项8备注
            budget.Income_other9 = TxtIncomeOther9.Text.GetDoubleValue();//其它收入项9
            budget.Income_other9Mark = TxtIncomeOther9Mark.Text;//其它收入项9备注
            budget.Income_other10 = TxtIncomeOther10.Text.GetDoubleValue();//其它收入项10
            budget.Income_other10Mark = TxtIncomeOther10Mark.Text;//其它收入项10备注
            budget.Income_premium = TxtPremium.Text.GetDoubleValue();//保费
            budget.Income_premiumMark = TxtPremiunMark.Text;//保费备注
            budget.Income_serviceCharge = TxtService.Text.GetDoubleValue();//服务费
            budget.Income_serviceChargeMark = TxtServiceMark.Text;//服务费备注

            budget.Exp_premium = TxtExpPremium.Text.GetDoubleValue();
            budget.Exp_premiumMark = TxtExpPremiumMark.Text;

            budget.PolicyId = Convert.ToInt32(Request.QueryString["policy"]);//关联保单ID

            if (!To_PolicyBudgetManager.ExitsPolicy(budget.PolicyId))
            {//保单没有对应的盈亏测算，添加
                To_PolicyBudgetManager.addBudget(budget);
            }
            else
            {//保单有对应的盈亏测算，更新                
                To_PolicyBudgetManager.UpdateByPolicy(budget);
            }

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "page", "alert('保存成功');self.location.href='../Policy/PolicyList.aspx';", true);
        }

        /// <summary>
        /// 保存按钮触发
        /// </summary>
        protected void BtnSave_Click(object sender, ImageClickEventArgs e)
        {
            SaveData();
        }
    }

}