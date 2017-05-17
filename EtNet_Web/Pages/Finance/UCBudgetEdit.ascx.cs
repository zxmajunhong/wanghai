using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;
using System.Data;

namespace EtNet_Web.Pages.Finance
{
    public partial class UCBudgetEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TxtJjfsj.Attributes.Add("readonly", "readonly");
            TxtFwfsj.Attributes.Add("readonly", "readonly");
            TxtOther.Attributes.Add("readonly", "readonly");

        }

        /// <summary>
        /// 初始化盈亏数据
        /// </summary>
        /// <param name="policyID"></param>
        public void InitBudgetData(int policyID)
        {
            //如果不存在保单对应的盈亏数据，则加载保额和默认比率      
            if (!To_PolicyBudgetManager.ExitsPolicy(policyID))
            {
                LoadRatio();
            }
            //否则加载保单对应的盈亏数据
            else
            {
                InitData(policyID);
            }
            LoadPremium(policyID);
        }

        /// <summary>
        /// 加载保费
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

                //    TxtPremium.Text = premium.ToString("F2");
                //    TxtExpPremium.Text = premium.ToString("F2");
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
                TxtGlfRatio.Text = parameter.BrokeTaxRatio;//管理费比率
                TxtDklxRatio1.Text = parameter.Rate;//垫款利息比率1
                TxtDklxRatio2.Text = parameter.FreeDay.ToString();//垫款利息比率2
                TxtJjfsjRatio.Text = parameter.BrokeRatio;//经纪费税金比率
                TxtFwfsjRatio.Text = parameter.ServiceRatio;//服务费税金比率
                TxtOtherRatio.Text = parameter.OtherRatio;//其它税金比率
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public void SaveData(int policyID)
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

            budget.PolicyId = policyID;//关联保单ID

            if (!To_PolicyBudgetManager.ExitsPolicy(budget.PolicyId))
            {//保单没有对应的盈亏测算，添加
                To_PolicyBudgetManager.addBudget(budget);
            }
            else
            {//保单有对应的盈亏测算，更新                
                To_PolicyBudgetManager.UpdateByPolicy(budget);
            }
        }




        private void InitData(int policyID)
        {
            EtNet_Models.To_PolicyBudget budget = To_PolicyBudgetManager.GetBudgetByPolicy(policyID);

            if (budget == null)
                return;

            To_Policy policy = To_PolicyManager.getTo_PolicyById(policyID);

            if (policy.IsDaidian == 1)
            {
                TxtExpPremium.Text = budget.Exp_premium.GetStringValue(); //代垫保费
                
            }
            TxtPremium.Text = budget.Income_premium.GetStringValue();//保费
            TxtJjfsj.Text = budget.Exp_brokerageFeesTaxes.GetStringValue();//经纪费税金
            TxtJjfsjMark.Text = budget.Exp_brokerageFeesTaxesMark;//经纪费税金备注
            TxtJjfsjRatio.Text = budget.Exp_brokerageFeesTaxesRatio.GetStringValue();//经纪费税金比率
            TxtYj.Text = budget.Exp_commission.GetStringValue();//佣金
            TxtYjMark.Text = budget.Exp_commissionMark;//佣金备注
            TxtYjRatio.Text = budget.Exp_commissionRatio.GetStringValue();//佣金比率
            TxtZxf.Text = budget.Exp_consultingFees.GetStringValue();//咨询费
            TxtZxfmark.Text = budget.Exp_consultingFeesMark;//咨询费备注
            TxtZxfRatio.Text = budget.Exp_consultingFeesRatio.GetStringValue();//咨询费比率
            //TxtDklx.Text = budget.Exp_interest.GetStringValue();//垫款利息
            TxtDklxMark.Text = budget.Exp_interestMark;//垫款利息备注
            TxtDklxRatio1.Text = budget.Exp_interestRatio1.GetStringValue();//垫款利息比率1
            TxtDklxRatio2.Text = budget.Exp_interestRatio2.GetStringValue();//垫款利息比率2
            TxtGlf.Text = budget.Exp_managementFees.GetStringValue();//管理费
            TxtGlfMark.Text = budget.Exp_managementFeesMark;//管理费备注
            TxtGlfRatio.Text = budget.Exp_managementFeesRatio.GetStringValue();//管理费比率
            TxtExpOther1.Text = budget.Exp_other1.GetStringValue();//其它支出项1
            TxtExpOther1Mark.Text = budget.Exp_other1Mark;//其它支出项1备注
            TxtExpOther1Ratio.Text = budget.Exp_other1Ratio.GetStringValue();//其它支出项1比率
            TxtExpOther2.Text = budget.Exp_other2.GetStringValue();//其它支出项2
            TxtExpOther2Mark.Text = budget.Exp_other2Mark;//其它支出项2备注
            TxtExpOther2Ratio.Text = budget.Exp_other2Ratio.GetStringValue();//其它支出项2比率
            TxtExpOther3.Text = budget.Exp_other3.GetStringValue();//其它支出项3
            TxtExpOther3Mark.Text = budget.Exp_other3Mark;//其它支出项3备注
            TxtExpOther3Ratio.Text = budget.Exp_other3Ratio.GetStringValue();//其它支出项3比率
            TxtExpOther4.Text = budget.Exp_other4.GetStringValue();//其它支出项4
            TxtExpOther4Mark.Text = budget.Exp_other4Mark;//其它支出项4备注
            TxtExpOther4Ratio.Text = budget.Exp_other4Ratio.GetStringValue();//其它支出项4比率
            TxtExpOther5.Text = budget.Exp_other5.GetStringValue();//其它支出项5
            TxtExpOther5Mark.Text = budget.Exp_other5Mark;//其它支出项5备注
            TxtExpOther5Ratio.Text = budget.Exp_other5Ratio.GetStringValue();//其它支出项5比率
            TxtOther.Text = budget.Exp_otherTaxes.GetStringValue();//其它税金
            TxtOtherRatio.Text = budget.Exp_otherTaxesRatio.GetStringValue();//其它税金比率
            TxtOtherMark.Text = budget.Exp_otherTaxesRatioMark;//其它税金备注
            TxtFwf.Text = budget.Exp_serviceCharge.GetStringValue();//服务费
            TxtFwfMark.Text = budget.Exp_serviceChargeMark;//服务费备注
            TxtFwfRatio.Text = budget.Exp_serviceChargeRatio.GetStringValue();//服务费比率
            TxtFwfsj.Text = budget.Exp_serviceChargeTaxes.GetStringValue();//服务费税金
            TxtFwfsjMark.Text = budget.Exp_serviceChargeTaxesMark;//服务费税金备注
            TxtFwfsjRatio.Text = budget.Exp_serviceChargeTaxesRatio.GetStringValue();//服务费税金比率
            TxtTf.Text = budget.Exp_tiefei.GetStringValue();//贴费
            TxtTfMark.Text = budget.Exp_tiefeiMark;//贴费备注
            TxtTfRatio.Text = budget.Exp_tiefeiRatio.GetStringValue();//贴费比率

            //---------------------收入项
            TxtBrokerage.Text = budget.Income_brokerageFees.GetStringValue();//经纪费
            TxtBrokerageMark.Text = budget.Income_brokerageFeesMark;//经纪费备注
            TxtIncomeOther1.Text = budget.Income_other1.GetStringValue();//其它收入项1
            TxtIncomeOther1Mark.Text = budget.Income_other1Mark;//其它收入项1备注
            TxtIncomeOther2.Text = budget.Income_other2.GetStringValue();//其它收入项2
            TxtIncomeOther2Mark.Text = budget.Income_other2Mark;//其它收入项2备注
            TxtIncomeOther3.Text = budget.Income_other3.GetStringValue();//其它收入项3
            TxtIncomeOther3Mark.Text = budget.Income_other3Mark;//其它收入项3备注
            TxtIncomeOther4.Text = budget.Income_other4.GetStringValue();//其它收入项4
            TxtIncomeOther4Mark.Text = budget.Income_other4Mark;//其它收入项4备注
            TxtIncomeOther5.Text = budget.Income_other5.GetStringValue();//其它收入项5
            TxtIncomeOther5Mark.Text = budget.Income_other5Mark;//其它收入项5备注
            TxtIncomeOther6.Text = budget.Income_other6.GetStringValue();//其它收入项6
            TxtIncomeOther6Mark.Text = budget.Income_other6Mark;//其它收入项6备注
            TxtIncomeOther7.Text = budget.Income_other7.GetStringValue();//其它收入项7
            TxtIncomeOther7Mark.Text = budget.Income_other7Mark;//其它收入项7备注
            TxtIncomeOther8.Text = budget.Income_other8.GetStringValue();//其它收入项8
            TxtIncomeOther8Mark.Text = budget.Income_other8Mark;//其它收入项8备注
            TxtIncomeOther9.Text = budget.Income_other9.GetStringValue();//其它收入项9
            TxtIncomeOther9Mark.Text = budget.Income_other9Mark;//其它收入项9备注
            TxtIncomeOther10.Text = budget.Income_other10.GetStringValue();//其它收入项10
            TxtIncomeOther10Mark.Text = budget.Income_other10Mark;//其它收入项10备注

            TxtPremiunMark.Text = budget.Income_premiumMark;//保费备注
            TxtService.Text = budget.Income_serviceCharge.GetStringValue();//服务费
            TxtServiceMark.Text = budget.Income_serviceChargeMark;//服务费备注


            TxtExpPremiumMark.Text = budget.Exp_premiumMark;
        }

    }

    public static class Double2String
    {
        public static string GetStringValue(this double? value)
        {
            if (value == null)
            {
                return "";
            }
            return ((double)value).ToString("F2");
        }

        public static double? GetDoubleValue(this string value)
        {
            double result = 0;
            if (double.TryParse(value, out result))
            {
                return result;
            }
            return null;
        }

        public static double GetDouble(this double? value)
        {
            double dValue = value ?? 0;
            return dValue;
        }
    }
}