using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;

namespace EtNet_Web.Pages.Finance
{
    public partial class BudgetPre : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void InitData(int policyID)
        {
            EtNet_Models.To_PolicyBudget budget = To_PolicyBudgetManager.GetBudgetByPolicy(policyID);

            if (budget == null)
                return;

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
            TxtPremium.Text = budget.Income_premium.GetStringValue();//保费
            TxtPremiunMark.Text = budget.Income_premiumMark;//保费备注
            TxtService.Text = budget.Income_serviceCharge.GetStringValue();//服务费
            TxtServiceMark.Text = budget.Income_serviceChargeMark;//服务费备注

            TxtExpPremium.Text = budget.Exp_premium.GetStringValue();
            TxtExpPremiumMark.Text = budget.Exp_premiumMark;

            double income = 0, exp = 0, total = 0;

            income += budget.Exp_brokerageFeesTaxes.GetDouble();
            income += budget.Exp_commission.GetDouble();
            income += budget.Exp_consultingFees.GetDouble();
            income += budget.Exp_interest.GetDouble();
            income += budget.Exp_managementFees.GetDouble();
            income += budget.Exp_other1.GetDouble();
            income += budget.Exp_other2.GetDouble();
            income += budget.Exp_other3.GetDouble();
            income += budget.Exp_other4.GetDouble();
            income += budget.Exp_other5.GetDouble();
            income += budget.Exp_otherTaxes.GetDouble();
            income += budget.Exp_serviceCharge.GetDouble();
            income += budget.Exp_serviceChargeTaxes.GetDouble();
            income += budget.Exp_tiefei.GetDouble();
            income += budget.Exp_premium.GetDouble();

            exp += budget.Income_brokerageFees.GetDouble();
            exp += budget.Income_other1.GetDouble();
            exp += budget.Income_other10.GetDouble();
            exp += budget.Income_other2.GetDouble();
            exp += budget.Income_other3.GetDouble();
            exp += budget.Income_other4.GetDouble();
            exp += budget.Income_other5.GetDouble();
            exp += budget.Income_other6.GetDouble();
            exp += budget.Income_other7.GetDouble();
            exp += budget.Income_other8.GetDouble();
            exp += budget.Income_other9.GetDouble();
            exp += budget.Income_premium.GetDouble();
            exp += budget.Income_serviceCharge.GetDouble();

            total = exp - income;

            LtrExp.Text = income.ToString("F2");
            LtrIncome.Text = exp.ToString("F2");
            LtrTotal.Text = total < 0 ? "<font color='red'>" + total.ToString("F2") + "</font>" : total.ToString("F2");
        }

    }

}