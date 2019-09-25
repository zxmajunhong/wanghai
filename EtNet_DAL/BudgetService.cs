using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EtNet_Models;
namespace EtNet_DAL
{

    /// <summary>
    ///[Budget]表的数据访问类
    /// </summary>
    public class BudgetService
    {
        /// <summary>
        /// 判断是否存在与保单关联的盈亏测算数据
        /// </summary>
        /// <param name="policyID">保单ID</param>
        /// <returns></returns>
        public static bool ExitsPolicy(int policyID)
        {
            string sql = "select count(*) from Budget where policyId=@policyId";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@policyId",policyID)
            };
            return DBHelper.ExecuteScalar(sql, sp) > 0 ? true : false;
        }

        /// <summary>
        /// 根据保单ID获取Budget
        /// </summary>
        /// <param name="policyID"></param>
        /// <returns></returns>
        public static Budget GetBudgetByPolicy(int policyID)
        {
            Budget budget = null;

            string sql = "select * from Budget where policyId=@policyId";
            SqlParameter[] sp = new SqlParameter[]
             {
               new SqlParameter("@policyId",policyID)
             };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                budget = new Budget();
                foreach (DataRow dr in dt.Rows)
                {
                    budget.Id = Convert.ToInt32(dr["id"]);
                    budget.PolicyId = Convert.ToInt32(dr["policyId"]);
                    budget.Income_premium = dr["income_premium"].DbNullToDouble();
                    budget.Income_brokerageFees = dr["income_brokerageFees"].DbNullToDouble();
                    budget.Income_serviceCharge = dr["income_serviceCharge"].DbNullToDouble();
                    budget.Income_other1 = dr["income_other1"].DbNullToDouble();
                    budget.Income_other2 = dr["income_other2"].DbNullToDouble();
                    budget.Income_other3 = dr["income_other3"].DbNullToDouble();
                    budget.Income_other4 = dr["income_other4"].DbNullToDouble();
                    budget.Income_other5 = dr["income_other5"].DbNullToDouble();
                    budget.Income_other6 = dr["income_other6"].DbNullToDouble();
                    budget.Income_other7 = dr["income_other7"].DbNullToDouble();
                    budget.Income_other8 = dr["income_other8"].DbNullToDouble();
                    budget.Income_other9 = dr["income_other9"].DbNullToDouble();
                    budget.Income_other10 = dr["income_other10"].DbNullToDouble();
                    budget.Exp_commission = dr["exp_commission"].DbNullToDouble();
                    budget.Exp_tiefei = dr["exp_tiefei"].DbNullToDouble();
                    budget.Exp_consultingFees = dr["exp_consultingFees"].DbNullToDouble();
                    budget.Exp_serviceCharge = dr["exp_serviceCharge"].DbNullToDouble();
                    budget.Exp_managementFees = dr["exp_managementFees"].DbNullToDouble();
                    budget.Exp_interest = dr["exp_interest"].DbNullToDouble();
                    budget.Exp_brokerageFeesTaxes = dr["exp_brokerageFeesTaxes"].DbNullToDouble();
                    budget.Exp_serviceChargeTaxes = dr["exp_serviceChargeTaxes"].DbNullToDouble();
                    budget.Exp_otherTaxes = dr["exp_otherTaxes"].DbNullToDouble();
                    budget.Exp_other1 = dr["exp_other1"].DbNullToDouble();
                    budget.Exp_other2 = dr["exp_other2"].DbNullToDouble();
                    budget.Exp_other3 = dr["exp_other3"].DbNullToDouble();
                    budget.Exp_other4 = dr["exp_other4"].DbNullToDouble();
                    budget.Exp_other5 = dr["exp_other5"].DbNullToDouble();
                    budget.Exp_other1Ratio = dr["exp_other1Ratio"].DbNullToDouble();
                    budget.Exp_other2Ratio = dr["exp_other2Ratio"].DbNullToDouble();
                    budget.Exp_other3Ratio = dr["exp_other3Ratio"].DbNullToDouble();
                    budget.Exp_other4Ratio = dr["exp_other4Ratio"].DbNullToDouble();
                    budget.Exp_other5Ratio = dr["exp_other5Ratio"].DbNullToDouble();
                    budget.Exp_commissionRatio = dr["exp_commissionRatio"].DbNullToDouble();
                    budget.Exp_tiefeiRatio = dr["exp_tiefeiRatio"].DbNullToDouble();
                    budget.Exp_consultingFeesRatio = dr["exp_consultingFeesRatio"].DbNullToDouble();
                    budget.Exp_serviceChargeRatio = dr["exp_serviceChargeRatio"].DbNullToDouble();
                    budget.Exp_managementFeesRatio = dr["exp_managementFeesRatio"].DbNullToDouble();
                    budget.Exp_interestRatio1 = dr["exp_interestRatio1"].DbNullToDouble();
                    budget.Exp_interestRatio2 = dr["exp_interestRatio2"].DbNullToDouble();
                    budget.Exp_brokerageFeesTaxesRatio = dr["exp_brokerageFeesTaxesRatio"].DbNullToDouble();
                    budget.Exp_serviceChargeTaxesRatio = dr["exp_serviceChargeTaxesRatio"].DbNullToDouble();
                    budget.Exp_otherTaxesRatio = dr["exp_otherTaxesRatio"].DbNullToDouble();
                    budget.Income_premiumMark = Convert.ToString(dr["income_premiumMark"]);
                    budget.Income_brokerageFeesMark = Convert.ToString(dr["income_brokerageFeesMark"]);
                    budget.Income_serviceChargeMark = Convert.ToString(dr["income_serviceChargeMark"]);
                    budget.Income_other1Mark = Convert.ToString(dr["income_other1Mark"]);
                    budget.Income_other2Mark = Convert.ToString(dr["income_other2Mark"]);
                    budget.Income_other3Mark = Convert.ToString(dr["income_other3Mark"]);
                    budget.Income_other4Mark = Convert.ToString(dr["income_other4Mark"]);
                    budget.Income_other5Mark = Convert.ToString(dr["income_other5Mark"]);
                    budget.Income_other6Mark = Convert.ToString(dr["income_other6Mark"]);
                    budget.Income_other7Mark = Convert.ToString(dr["income_other7Mark"]);
                    budget.Income_other8Mark = Convert.ToString(dr["income_other8Mark"]);
                    budget.Income_other9Mark = Convert.ToString(dr["income_other9Mark"]);
                    budget.Income_other10Mark = Convert.ToString(dr["income_other10Mark"]);
                    budget.Exp_commissionMark = Convert.ToString(dr["exp_commissionMark"]);
                    budget.Exp_tiefeiMark = Convert.ToString(dr["exp_tiefeiMark"]);
                    budget.Exp_consultingFeesMark = Convert.ToString(dr["exp_consultingFeesMark"]);
                    budget.Exp_serviceChargeMark = Convert.ToString(dr["exp_serviceChargeMark"]);
                    budget.Exp_managementFeesMark = Convert.ToString(dr["exp_managementFeesMark"]);
                    budget.Exp_interestMark = Convert.ToString(dr["exp_interestMark"]);
                    budget.Exp_brokerageFeesTaxesMark = Convert.ToString(dr["exp_brokerageFeesTaxesMark"]);
                    budget.Exp_serviceChargeTaxesMark = Convert.ToString(dr["exp_serviceChargeTaxesMark"]);
                    budget.Exp_otherTaxesRatioMark = Convert.ToString(dr["exp_otherTaxesRatioMark"]);
                    budget.Exp_other1Mark = Convert.ToString(dr["exp_other1Mark"]);
                    budget.Exp_other2Mark = Convert.ToString(dr["exp_other2Mark"]);
                    budget.Exp_other3Mark = Convert.ToString(dr["exp_other3Mark"]);
                    budget.Exp_other4Mark = Convert.ToString(dr["exp_other4Mark"]);
                    budget.Exp_other5Mark = Convert.ToString(dr["exp_other5Mark"]);
                }
            }

            return budget;
        }

        public static int UpdateByPolicy(Budget budget)
        {
            string sql = "update Budget set income_premium=@income_premium,income_brokerageFees=@income_brokerageFees,income_serviceCharge=@income_serviceCharge,income_other1=@income_other1,income_other2=@income_other2,income_other3=@income_other3,income_other4=@income_other4,income_other5=@income_other5,income_other6=@income_other6,income_other7=@income_other7,income_other8=@income_other8,income_other9=@income_other9,income_other10=@income_other10,exp_commission=@exp_commission,exp_tiefei=@exp_tiefei,exp_consultingFees=@exp_consultingFees,exp_serviceCharge=@exp_serviceCharge,exp_managementFees=@exp_managementFees,exp_interest=@exp_interest,exp_brokerageFeesTaxes=@exp_brokerageFeesTaxes,exp_serviceChargeTaxes=@exp_serviceChargeTaxes,exp_otherTaxes=@exp_otherTaxes,exp_other1=@exp_other1,exp_other2=@exp_other2,exp_other3=@exp_other3,exp_other4=@exp_other4,exp_other5=@exp_other5,exp_other1Ratio=@exp_other1Ratio,exp_other2Ratio=@exp_other2Ratio,exp_other3Ratio=@exp_other3Ratio,exp_other4Ratio=@exp_other4Ratio,exp_other5Ratio=@exp_other5Ratio,exp_commissionRatio=@exp_commissionRatio,exp_tiefeiRatio=@exp_tiefeiRatio,exp_consultingFeesRatio=@exp_consultingFeesRatio,exp_serviceChargeRatio=@exp_serviceChargeRatio,exp_managementFeesRatio=@exp_managementFeesRatio,exp_interestRatio1=@exp_interestRatio1,exp_interestRatio2=@exp_interestRatio2,exp_brokerageFeesTaxesRatio=@exp_brokerageFeesTaxesRatio,exp_serviceChargeTaxesRatio=@exp_serviceChargeTaxesRatio,exp_otherTaxesRatio=@exp_otherTaxesRatio,income_premiumMark=@income_premiumMark,income_brokerageFeesMark=@income_brokerageFeesMark,income_serviceChargeMark=@income_serviceChargeMark,income_other1Mark=@income_other1Mark,income_other2Mark=@income_other2Mark,income_other3Mark=@income_other3Mark,income_other4Mark=@income_other4Mark,income_other5Mark=@income_other5Mark,income_other6Mark=@income_other6Mark,income_other7Mark=@income_other7Mark,income_other8Mark=@income_other8Mark,income_other9Mark=@income_other9Mark,income_other10Mark=@income_other10Mark,exp_commissionMark=@exp_commissionMark,exp_tiefeiMark=@exp_tiefeiMark,exp_consultingFeesMark=@exp_consultingFeesMark,exp_serviceChargeMark=@exp_serviceChargeMark,exp_managementFeesMark=@exp_managementFeesMark,exp_interestMark=@exp_interestMark,exp_brokerageFeesTaxesMark=@exp_brokerageFeesTaxesMark,exp_serviceChargeTaxesMark=@exp_serviceChargeTaxesMark,exp_otherTaxesRatioMark=@exp_otherTaxesRatioMark,exp_other1Mark=@exp_other1Mark,exp_other2Mark=@exp_other2Mark,exp_other3Mark=@exp_other3Mark,exp_other4Mark=@exp_other4Mark,exp_other5Mark=@exp_other5Mark where policyId=@policyId";
            SqlParameter[] sp = new SqlParameter[]
             {
                new SqlParameter("@policyId",budget.PolicyId),
                new SqlParameter("@income_premium",budget.Income_premium),
                new SqlParameter("@income_brokerageFees",budget.Income_brokerageFees),
                new SqlParameter("@income_serviceCharge",budget.Income_serviceCharge),
                new SqlParameter("@income_other1",budget.Income_other1),
                new SqlParameter("@income_other2",budget.Income_other2),
                new SqlParameter("@income_other3",budget.Income_other3),
                new SqlParameter("@income_other4",budget.Income_other4),
                new SqlParameter("@income_other5",budget.Income_other5),
                new SqlParameter("@income_other6",budget.Income_other6),
                new SqlParameter("@income_other7",budget.Income_other7),
                new SqlParameter("@income_other8",budget.Income_other8),
                new SqlParameter("@income_other9",budget.Income_other9),
                new SqlParameter("@income_other10",budget.Income_other10),
                new SqlParameter("@exp_commission",budget.Exp_commission),
                new SqlParameter("@exp_tiefei",budget.Exp_tiefei),
                new SqlParameter("@exp_consultingFees",budget.Exp_consultingFees),
                new SqlParameter("@exp_serviceCharge",budget.Exp_serviceCharge),
                new SqlParameter("@exp_managementFees",budget.Exp_managementFees),
                new SqlParameter("@exp_interest",budget.Exp_interest),
                new SqlParameter("@exp_brokerageFeesTaxes",budget.Exp_brokerageFeesTaxes),
                new SqlParameter("@exp_serviceChargeTaxes",budget.Exp_serviceChargeTaxes),
                new SqlParameter("@exp_otherTaxes",budget.Exp_otherTaxes),
                new SqlParameter("@exp_other1",budget.Exp_other1),
                new SqlParameter("@exp_other2",budget.Exp_other2),
                new SqlParameter("@exp_other3",budget.Exp_other3),
                new SqlParameter("@exp_other4",budget.Exp_other4),
                new SqlParameter("@exp_other5",budget.Exp_other5),
                new SqlParameter("@exp_other1Ratio",budget.Exp_other1Ratio),
                new SqlParameter("@exp_other2Ratio",budget.Exp_other2Ratio),
                new SqlParameter("@exp_other3Ratio",budget.Exp_other3Ratio),
                new SqlParameter("@exp_other4Ratio",budget.Exp_other4Ratio),
                new SqlParameter("@exp_other5Ratio",budget.Exp_other5Ratio),
                new SqlParameter("@exp_commissionRatio",budget.Exp_commissionRatio),
                new SqlParameter("@exp_tiefeiRatio",budget.Exp_tiefeiRatio),
                new SqlParameter("@exp_consultingFeesRatio",budget.Exp_consultingFeesRatio),
                new SqlParameter("@exp_serviceChargeRatio",budget.Exp_serviceChargeRatio),
                new SqlParameter("@exp_managementFeesRatio",budget.Exp_managementFeesRatio),
                new SqlParameter("@exp_interestRatio1",budget.Exp_interestRatio1),
                new SqlParameter("@exp_interestRatio2",budget.Exp_interestRatio2),
                new SqlParameter("@exp_brokerageFeesTaxesRatio",budget.Exp_brokerageFeesTaxesRatio),
                new SqlParameter("@exp_serviceChargeTaxesRatio",budget.Exp_serviceChargeTaxesRatio),
                new SqlParameter("@exp_otherTaxesRatio",budget.Exp_otherTaxesRatio),
                new SqlParameter("@income_premiumMark",budget.Income_premiumMark),
                new SqlParameter("@income_brokerageFeesMark",budget.Income_brokerageFeesMark),
                new SqlParameter("@income_serviceChargeMark",budget.Income_serviceChargeMark),
                new SqlParameter("@income_other1Mark",budget.Income_other1Mark),
                new SqlParameter("@income_other2Mark",budget.Income_other2Mark),
                new SqlParameter("@income_other3Mark",budget.Income_other3Mark),
                new SqlParameter("@income_other4Mark",budget.Income_other4Mark),
                new SqlParameter("@income_other5Mark",budget.Income_other5Mark),
                new SqlParameter("@income_other6Mark",budget.Income_other6Mark),
                new SqlParameter("@income_other7Mark",budget.Income_other7Mark),
                new SqlParameter("@income_other8Mark",budget.Income_other8Mark),
                new SqlParameter("@income_other9Mark",budget.Income_other9Mark),
                new SqlParameter("@income_other10Mark",budget.Income_other10Mark),
                new SqlParameter("@exp_commissionMark",budget.Exp_commissionMark),
                new SqlParameter("@exp_tiefeiMark",budget.Exp_tiefeiMark),
                new SqlParameter("@exp_consultingFeesMark",budget.Exp_consultingFeesMark),
                new SqlParameter("@exp_serviceChargeMark",budget.Exp_serviceChargeMark),
                new SqlParameter("@exp_managementFeesMark",budget.Exp_managementFeesMark),
                new SqlParameter("@exp_interestMark",budget.Exp_interestMark),
                new SqlParameter("@exp_brokerageFeesTaxesMark",budget.Exp_brokerageFeesTaxesMark),
                new SqlParameter("@exp_serviceChargeTaxesMark",budget.Exp_serviceChargeTaxesMark),
                new SqlParameter("@exp_otherTaxesRatioMark",budget.Exp_otherTaxesRatioMark),
                new SqlParameter("@exp_other1Mark",budget.Exp_other1Mark),
                new SqlParameter("@exp_other2Mark",budget.Exp_other2Mark),
                new SqlParameter("@exp_other3Mark",budget.Exp_other3Mark),
                new SqlParameter("@exp_other4Mark",budget.Exp_other4Mark),
                new SqlParameter("@exp_other5Mark",budget.Exp_other5Mark)
             };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Budget]表添加的方法
        /// </summary>
        public static int addBudget(Budget budget)
        {
            string sql = "insert into Budget([policyId],[income_premium],[income_brokerageFees],[income_serviceCharge],[income_other1],[income_other2],[income_other3],[income_other4],[income_other5],[income_other6],[income_other7],[income_other8],[income_other9],[income_other10],[exp_commission],[exp_tiefei],[exp_consultingFees],[exp_serviceCharge],[exp_managementFees],[exp_interest],[exp_brokerageFeesTaxes],[exp_serviceChargeTaxes],[exp_otherTaxes],[exp_other1],[exp_other2],[exp_other3],[exp_other4],[exp_other5],[exp_other1Ratio],[exp_other2Ratio],[exp_other3Ratio],[exp_other4Ratio],[exp_other5Ratio],[exp_commissionRatio],[exp_tiefeiRatio],[exp_consultingFeesRatio],[exp_serviceChargeRatio],[exp_managementFeesRatio],[exp_interestRatio1],[exp_interestRatio2],[exp_brokerageFeesTaxesRatio],[exp_serviceChargeTaxesRatio],[exp_otherTaxesRatio],[income_premiumMark],[income_brokerageFeesMark],[income_serviceChargeMark],[income_other1Mark],[income_other2Mark],[income_other3Mark],[income_other4Mark],[income_other5Mark],[income_other6Mark],[income_other7Mark],[income_other8Mark],[income_other9Mark],[income_other10Mark],[exp_commissionMark],[exp_tiefeiMark],[exp_consultingFeesMark],[exp_serviceChargeMark],[exp_managementFeesMark],[exp_interestMark],[exp_brokerageFeesTaxesMark],[exp_serviceChargeTaxesMark],[exp_otherTaxesRatioMark],[exp_other1Mark],[exp_other2Mark],[exp_other3Mark],[exp_other4Mark],[exp_other5Mark]) values (@policyId,@income_premium,@income_brokerageFees,@income_serviceCharge,@income_other1,@income_other2,@income_other3,@income_other4,@income_other5,@income_other6,@income_other7,@income_other8,@income_other9,@income_other10,@exp_commission,@exp_tiefei,@exp_consultingFees,@exp_serviceCharge,@exp_managementFees,@exp_interest,@exp_brokerageFeesTaxes,@exp_serviceChargeTaxes,@exp_otherTaxes,@exp_other1,@exp_other2,@exp_other3,@exp_other4,@exp_other5,@exp_other1Ratio,@exp_other2Ratio,@exp_other3Ratio,@exp_other4Ratio,@exp_other5Ratio,@exp_commissionRatio,@exp_tiefeiRatio,@exp_consultingFeesRatio,@exp_serviceChargeRatio,@exp_managementFeesRatio,@exp_interestRatio1,@exp_interestRatio2,@exp_brokerageFeesTaxesRatio,@exp_serviceChargeTaxesRatio,@exp_otherTaxesRatio,@income_premiumMark,@income_brokerageFeesMark,@income_serviceChargeMark,@income_other1Mark,@income_other2Mark,@income_other3Mark,@income_other4Mark,@income_other5Mark,@income_other6Mark,@income_other7Mark,@income_other8Mark,@income_other9Mark,@income_other10Mark,@exp_commissionMark,@exp_tiefeiMark,@exp_consultingFeesMark,@exp_serviceChargeMark,@exp_managementFeesMark,@exp_interestMark,@exp_brokerageFeesTaxesMark,@exp_serviceChargeTaxesMark,@exp_otherTaxesRatioMark,@exp_other1Mark,@exp_other2Mark,@exp_other3Mark,@exp_other4Mark,@exp_other5Mark)";
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@policyId",budget.PolicyId),
                budget.Income_premium ==null?new SqlParameter("@income_premium",DBNull.Value): new SqlParameter("@income_premium",budget.Income_premium),
                budget.Income_brokerageFees ==null?new SqlParameter("@income_brokerageFees",DBNull.Value): new SqlParameter("@income_brokerageFees",budget.Income_brokerageFees),
                budget.Income_serviceCharge==null?new SqlParameter("@income_serviceCharge",DBNull.Value): new SqlParameter("@income_serviceCharge",budget.Income_serviceCharge),
                budget.Income_other1 ==null?new SqlParameter("@income_other1",DBNull.Value): new SqlParameter("@income_other1",budget.Income_other1),
                budget.Income_other2 ==null?new SqlParameter("@income_other2",DBNull.Value): new SqlParameter("@income_other2",budget.Income_other2),
                budget.Income_other3==null?new SqlParameter("@income_other3",DBNull.Value):  new SqlParameter("@income_other3",budget.Income_other3),
                budget.Income_other4 ==null?new SqlParameter("@income_other4",DBNull.Value): new SqlParameter("@income_other4",budget.Income_other4),
                budget.Income_other5 ==null?new SqlParameter("@income_other5",DBNull.Value): new SqlParameter("@income_other5",budget.Income_other5),
                budget.Income_other6==null?new SqlParameter("@income_other6",DBNull.Value):  new SqlParameter("@income_other6",budget.Income_other6),
                budget.Income_other7 ==null?new SqlParameter("@income_other7",DBNull.Value):  new SqlParameter("@income_other7",budget.Income_other7),
                budget.Income_other8==null?new SqlParameter("@income_other8",DBNull.Value):  new SqlParameter("@income_other8",budget.Income_other8),
                budget.Income_other9 ==null?new SqlParameter("@income_other9",DBNull.Value):  new SqlParameter("@income_other9",budget.Income_other9),
                budget.Income_other10 ==null?new SqlParameter("@income_other10",DBNull.Value): new SqlParameter("@income_other10",budget.Income_other10),
                budget.Exp_commission ==null?new SqlParameter("@exp_commission",DBNull.Value):  new SqlParameter("@exp_commission",budget.Exp_commission),
                budget.Exp_tiefei  ==null?new SqlParameter("@exp_tiefei",DBNull.Value): new SqlParameter("@exp_tiefei",budget.Exp_tiefei),
                budget.Exp_consultingFees ==null?new SqlParameter("@exp_consultingFees",DBNull.Value):  new SqlParameter("@exp_consultingFees",budget.Exp_consultingFees),
                budget.Exp_serviceCharge ==null?new SqlParameter("@exp_serviceCharge",DBNull.Value): new SqlParameter("@exp_serviceCharge",budget.Exp_serviceCharge),
                budget.Exp_managementFees ==null?new SqlParameter("@exp_managementFees",DBNull.Value):  new SqlParameter("@exp_managementFees",budget.Exp_managementFees),
                budget.Exp_interest ==null?new SqlParameter("@exp_interest",DBNull.Value):  new SqlParameter("@exp_interest",budget.Exp_interest),
                budget.Exp_brokerageFeesTaxes ==null?new SqlParameter("@exp_brokerageFeesTaxes",DBNull.Value): new SqlParameter("@exp_brokerageFeesTaxes",budget.Exp_brokerageFeesTaxes),
                budget.Exp_serviceChargeTaxes ==null?new SqlParameter("@exp_serviceChargeTaxes",DBNull.Value):  new SqlParameter("@exp_serviceChargeTaxes",budget.Exp_serviceChargeTaxes),
                budget.Exp_otherTaxes ==null?new SqlParameter("@exp_otherTaxes",DBNull.Value):  new SqlParameter("@exp_otherTaxes",budget.Exp_otherTaxes),
                budget.Exp_other1  ==null?new SqlParameter("@exp_other1",DBNull.Value):  new SqlParameter("@exp_other1",budget.Exp_other1),
                budget.Exp_other2  ==null?new SqlParameter("@exp_other2",DBNull.Value): new SqlParameter("@exp_other2",budget.Exp_other2),
                budget.Exp_other3 ==null?new SqlParameter("@exp_other3",DBNull.Value):  new SqlParameter("@exp_other3",budget.Exp_other3),
                budget.Exp_other4 ==null?new SqlParameter("@exp_other4",DBNull.Value):  new SqlParameter("@exp_other4",budget.Exp_other4),
                budget.Exp_other5 ==null?new SqlParameter("@exp_other5",DBNull.Value): new SqlParameter("@exp_other5",budget.Exp_other5),
                budget.Exp_other1Ratio ==null?new SqlParameter("@exp_other1Ratio",DBNull.Value):   new SqlParameter("@exp_other1Ratio",budget.Exp_other1Ratio),
                budget.Exp_other2Ratio ==null?new SqlParameter("@exp_other2Ratio",DBNull.Value):  new SqlParameter("@exp_other2Ratio",budget.Exp_other2Ratio),
                budget.Exp_other3Ratio ==null?new SqlParameter("@exp_other3Ratio",DBNull.Value):  new SqlParameter("@exp_other3Ratio",budget.Exp_other3Ratio),
                budget.Exp_other4Ratio ==null?new SqlParameter("@exp_other4Ratio",DBNull.Value): new SqlParameter("@exp_other4Ratio",budget.Exp_other4Ratio),
                budget.Exp_other5Ratio ==null?new SqlParameter("@exp_other5Ratio",DBNull.Value): new SqlParameter("@exp_other5Ratio",budget.Exp_other5Ratio),
                budget.Exp_commissionRatio ==null?new SqlParameter("@exp_commissionRatio",DBNull.Value): new SqlParameter("@exp_commissionRatio",budget.Exp_commissionRatio),
                budget.Exp_tiefeiRatio==null?new SqlParameter("@exp_tiefeiRatio",DBNull.Value):  new SqlParameter("@exp_tiefeiRatio",budget.Exp_tiefeiRatio),
                budget.Exp_consultingFeesRatio ==null?new SqlParameter("@exp_consultingFeesRatio",DBNull.Value): new SqlParameter("@exp_consultingFeesRatio",budget.Exp_consultingFeesRatio),
                budget.Exp_serviceChargeRatio  ==null?new SqlParameter("@exp_serviceChargeRatio",DBNull.Value): new SqlParameter("@exp_serviceChargeRatio",budget.Exp_serviceChargeRatio),
                budget.Exp_managementFeesRatio ==null?new SqlParameter("@exp_managementFeesRatio",DBNull.Value): new SqlParameter("@exp_managementFeesRatio",budget.Exp_managementFeesRatio),
                budget.Exp_interestRatio1 ==null?new SqlParameter("@exp_interestRatio1",DBNull.Value): new SqlParameter("@exp_interestRatio1",budget.Exp_interestRatio1),
                budget.Exp_interestRatio2 ==null?new SqlParameter("@exp_interestRatio2",DBNull.Value):  new SqlParameter("@",budget.Exp_interestRatio2),
                budget.Exp_brokerageFeesTaxesRatio ==null?new SqlParameter("@exp_brokerageFeesTaxesRatio",DBNull.Value): new SqlParameter("@exp_brokerageFeesTaxesRatio",budget.Exp_brokerageFeesTaxesRatio),
                budget.Exp_serviceChargeTaxesRatio==null?new SqlParameter("@exp_serviceChargeTaxesRatio",DBNull.Value):  new SqlParameter("@exp_serviceChargeTaxesRatio",budget.Exp_serviceChargeTaxesRatio),
                budget.Exp_otherTaxesRatio ==null?new SqlParameter("@exp_otherTaxesRatio",DBNull.Value): new SqlParameter("@exp_otherTaxesRatio",budget.Exp_otherTaxesRatio),
                new SqlParameter("@income_premiumMark",budget.Income_premiumMark),
                new SqlParameter("@income_brokerageFeesMark",budget.Income_brokerageFeesMark),
                new SqlParameter("@income_serviceChargeMark",budget.Income_serviceChargeMark),
                new SqlParameter("@income_other1Mark",budget.Income_other1Mark),
                new SqlParameter("@income_other2Mark",budget.Income_other2Mark),
                new SqlParameter("@income_other3Mark",budget.Income_other3Mark),
                new SqlParameter("@income_other4Mark",budget.Income_other4Mark),
                new SqlParameter("@income_other5Mark",budget.Income_other5Mark),
                new SqlParameter("@income_other6Mark",budget.Income_other6Mark),
                new SqlParameter("@income_other7Mark",budget.Income_other7Mark),
                new SqlParameter("@income_other8Mark",budget.Income_other8Mark),
                new SqlParameter("@income_other9Mark",budget.Income_other9Mark),
                new SqlParameter("@income_other10Mark",budget.Income_other10Mark),
                new SqlParameter("@exp_commissionMark",budget.Exp_commissionMark),
                new SqlParameter("@exp_tiefeiMark",budget.Exp_tiefeiMark),
                new SqlParameter("@exp_consultingFeesMark",budget.Exp_consultingFeesMark),
                new SqlParameter("@exp_serviceChargeMark",budget.Exp_serviceChargeMark),
                new SqlParameter("@exp_managementFeesMark",budget.Exp_managementFeesMark),
                new SqlParameter("@exp_interestMark",budget.Exp_interestMark),
                new SqlParameter("@exp_brokerageFeesTaxesMark",budget.Exp_brokerageFeesTaxesMark),
                new SqlParameter("@exp_serviceChargeTaxesMark",budget.Exp_serviceChargeTaxesMark),
                new SqlParameter("@exp_otherTaxesRatioMark",budget.Exp_otherTaxesRatioMark),
                new SqlParameter("@exp_other1Mark",budget.Exp_other1Mark),
                new SqlParameter("@exp_other2Mark",budget.Exp_other2Mark),
                new SqlParameter("@exp_other3Mark",budget.Exp_other3Mark),
                new SqlParameter("@exp_other4Mark",budget.Exp_other4Mark),
                new SqlParameter("@exp_other5Mark",budget.Exp_other5Mark)
            };
            return DBHelper.ExecuteCommand(sql, sp);
        }

        /// <summary>
        ///[Budget]表修改的方法
        /// </summary>
        public static int updateBudgetById(Budget budget)
        {

            string sql = "update Budget set policyId=@policyId,income_premium=@income_premium,income_brokerageFees=@income_brokerageFees,income_serviceCharge=@income_serviceCharge,income_other1=@income_other1,income_other2=@income_other2,income_other3=@income_other3,income_other4=@income_other4,income_other5=@income_other5,income_other6=@income_other6,income_other7=@income_other7,income_other8=@income_other8,income_other9=@income_other9,income_other10=@income_other10,exp_commission=@exp_commission,exp_tiefei=@exp_tiefei,exp_consultingFees=@exp_consultingFees,exp_serviceCharge=@exp_serviceCharge,exp_managementFees=@exp_managementFees,exp_interest=@exp_interest,exp_brokerageFeesTaxes=@exp_brokerageFeesTaxes,exp_serviceChargeTaxes=@exp_serviceChargeTaxes,exp_otherTaxes=@exp_otherTaxes,exp_other1=@exp_other1,exp_other2=@exp_other2,exp_other3=@exp_other3,exp_other4=@exp_other4,exp_other5=@exp_other5,exp_other1Ratio=@exp_other1Ratio,exp_other2Ratio=@exp_other2Ratio,exp_other3Ratio=@exp_other3Ratio,exp_other4Ratio=@exp_other4Ratio,exp_other5Ratio=@exp_other5Ratio,exp_commissionRatio=@exp_commissionRatio,exp_tiefeiRatio=@exp_tiefeiRatio,exp_consultingFeesRatio=@exp_consultingFeesRatio,exp_serviceChargeRatio=@exp_serviceChargeRatio,exp_managementFeesRatio=@exp_managementFeesRatio,exp_interestRatio1=@exp_interestRatio1,exp_interestRatio2=@exp_interestRatio2,exp_brokerageFeesTaxesRatio=@exp_brokerageFeesTaxesRatio,exp_serviceChargeTaxesRatio=@exp_serviceChargeTaxesRatio,exp_otherTaxesRatio=@exp_otherTaxesRatio,income_premiumMark=@income_premiumMark,income_brokerageFeesMark=@income_brokerageFeesMark,income_serviceChargeMark=@income_serviceChargeMark,income_other1Mark=@income_other1Mark,income_other2Mark=@income_other2Mark,income_other3Mark=@income_other3Mark,income_other4Mark=@income_other4Mark,income_other5Mark=@income_other5Mark,income_other6Mark=@income_other6Mark,income_other7Mark=@income_other7Mark,income_other8Mark=@income_other8Mark,income_other9Mark=@income_other9Mark,income_other10Mark=@income_other10Mark,exp_commissionMark=@exp_commissionMark,exp_tiefeiMark=@exp_tiefeiMark,exp_consultingFeesMark=@exp_consultingFeesMark,exp_serviceChargeMark=@exp_serviceChargeMark,exp_managementFeesMark=@exp_managementFeesMark,exp_interestMark=@exp_interestMark,exp_brokerageFeesTaxesMark=@exp_brokerageFeesTaxesMark,exp_serviceChargeTaxesMark=@exp_serviceChargeTaxesMark,exp_otherTaxesRatioMark=@exp_otherTaxesRatioMark,exp_other1Mark=@exp_other1Mark,exp_other2Mark=@exp_other2Mark,exp_other3Mark=@exp_other3Mark,exp_other4Mark=@exp_other4Mark,exp_other5Mark=@exp_other5Mark where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
        new SqlParameter("@id",budget.Id),
        new SqlParameter("@policyId",budget.PolicyId),
        new SqlParameter("@income_premium",budget.Income_premium),
        new SqlParameter("@income_brokerageFees",budget.Income_brokerageFees),
        new SqlParameter("@income_serviceCharge",budget.Income_serviceCharge),
        new SqlParameter("@income_other1",budget.Income_other1),
        new SqlParameter("@income_other2",budget.Income_other2),
        new SqlParameter("@income_other3",budget.Income_other3),
        new SqlParameter("@income_other4",budget.Income_other4),
        new SqlParameter("@income_other5",budget.Income_other5),
        new SqlParameter("@income_other6",budget.Income_other6),
        new SqlParameter("@income_other7",budget.Income_other7),
        new SqlParameter("@income_other8",budget.Income_other8),
        new SqlParameter("@income_other9",budget.Income_other9),
        new SqlParameter("@income_other10",budget.Income_other10),
        new SqlParameter("@exp_commission",budget.Exp_commission),
        new SqlParameter("@exp_tiefei",budget.Exp_tiefei),
        new SqlParameter("@exp_consultingFees",budget.Exp_consultingFees),
        new SqlParameter("@exp_serviceCharge",budget.Exp_serviceCharge),
        new SqlParameter("@exp_managementFees",budget.Exp_managementFees),
        new SqlParameter("@exp_interest",budget.Exp_interest),
        new SqlParameter("@exp_brokerageFeesTaxes",budget.Exp_brokerageFeesTaxes),
        new SqlParameter("@exp_serviceChargeTaxes",budget.Exp_serviceChargeTaxes),
        new SqlParameter("@exp_otherTaxes",budget.Exp_otherTaxes),
        new SqlParameter("@exp_other1",budget.Exp_other1),
        new SqlParameter("@exp_other2",budget.Exp_other2),
        new SqlParameter("@exp_other3",budget.Exp_other3),
        new SqlParameter("@exp_other4",budget.Exp_other4),
        new SqlParameter("@exp_other5",budget.Exp_other5),
        new SqlParameter("@exp_other1Ratio",budget.Exp_other1Ratio),
        new SqlParameter("@exp_other2Ratio",budget.Exp_other2Ratio),
        new SqlParameter("@exp_other3Ratio",budget.Exp_other3Ratio),
        new SqlParameter("@exp_other4Ratio",budget.Exp_other4Ratio),
        new SqlParameter("@exp_other5Ratio",budget.Exp_other5Ratio),
        new SqlParameter("@exp_commissionRatio",budget.Exp_commissionRatio),
        new SqlParameter("@exp_tiefeiRatio",budget.Exp_tiefeiRatio),
        new SqlParameter("@exp_consultingFeesRatio",budget.Exp_consultingFeesRatio),
        new SqlParameter("@exp_serviceChargeRatio",budget.Exp_serviceChargeRatio),
        new SqlParameter("@exp_managementFeesRatio",budget.Exp_managementFeesRatio),
        new SqlParameter("@exp_interestRatio1",budget.Exp_interestRatio1),
        new SqlParameter("@exp_interestRatio2",budget.Exp_interestRatio2),
        new SqlParameter("@exp_brokerageFeesTaxesRatio",budget.Exp_brokerageFeesTaxesRatio),
        new SqlParameter("@exp_serviceChargeTaxesRatio",budget.Exp_serviceChargeTaxesRatio),
        new SqlParameter("@exp_otherTaxesRatio",budget.Exp_otherTaxesRatio),
        new SqlParameter("@income_premiumMark",budget.Income_premiumMark),
        new SqlParameter("@income_brokerageFeesMark",budget.Income_brokerageFeesMark),
        new SqlParameter("@income_serviceChargeMark",budget.Income_serviceChargeMark),
        new SqlParameter("@income_other1Mark",budget.Income_other1Mark),
        new SqlParameter("@income_other2Mark",budget.Income_other2Mark),
        new SqlParameter("@income_other3Mark",budget.Income_other3Mark),
        new SqlParameter("@income_other4Mark",budget.Income_other4Mark),
        new SqlParameter("@income_other5Mark",budget.Income_other5Mark),
        new SqlParameter("@income_other6Mark",budget.Income_other6Mark),
        new SqlParameter("@income_other7Mark",budget.Income_other7Mark),
        new SqlParameter("@income_other8Mark",budget.Income_other8Mark),
        new SqlParameter("@income_other9Mark",budget.Income_other9Mark),
        new SqlParameter("@income_other10Mark",budget.Income_other10Mark),
        new SqlParameter("@exp_commissionMark",budget.Exp_commissionMark),
        new SqlParameter("@exp_tiefeiMark",budget.Exp_tiefeiMark),
        new SqlParameter("@exp_consultingFeesMark",budget.Exp_consultingFeesMark),
        new SqlParameter("@exp_serviceChargeMark",budget.Exp_serviceChargeMark),
        new SqlParameter("@exp_managementFeesMark",budget.Exp_managementFeesMark),
        new SqlParameter("@exp_interestMark",budget.Exp_interestMark),
        new SqlParameter("@exp_brokerageFeesTaxesMark",budget.Exp_brokerageFeesTaxesMark),
        new SqlParameter("@exp_serviceChargeTaxesMark",budget.Exp_serviceChargeTaxesMark),
        new SqlParameter("@exp_otherTaxesRatioMark",budget.Exp_otherTaxesRatioMark),
        new SqlParameter("@exp_other1Mark",budget.Exp_other1Mark),
        new SqlParameter("@exp_other2Mark",budget.Exp_other2Mark),
        new SqlParameter("@exp_other3Mark",budget.Exp_other3Mark),
        new SqlParameter("@exp_other4Mark",budget.Exp_other4Mark),
        new SqlParameter("@exp_other5Mark",budget.Exp_other5Mark)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Budget]表删除的方法
        /// </summary>
        public static int deleteBudgetById(int id)
        {

            string sql = "delete from Budget where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            return DBHelper.ExecuteCommand(sql, sp);

        }

        /// <summary>
        ///[Budget]表查询实体的方法
        /// </summary>
        public static Budget getBudgetById(int id)
        {
            Budget budget = null;

            string sql = "select * from Budget where id=@id";
            SqlParameter[] sp = new SqlParameter[]
     {
       new SqlParameter("@id",id)
     };
            DataTable dt = DBHelper.GetDataSet(sql, sp);
            if (dt.Rows.Count > 0)
            {
                budget = new Budget();
                foreach (DataRow dr in dt.Rows)
                {
                    budget.Id = Convert.ToInt32(dr["id"]);
                    budget.PolicyId = Convert.ToInt32(dr["policyId"]);
                    budget.Income_premium = Convert.ToDouble(dr["income_premium"]);
                    budget.Income_brokerageFees = Convert.ToDouble(dr["income_brokerageFees"]);
                    budget.Income_serviceCharge = Convert.ToDouble(dr["income_serviceCharge"]);
                    budget.Income_other1 = Convert.ToDouble(dr["income_other1"]);
                    budget.Income_other2 = Convert.ToDouble(dr["income_other2"]);
                    budget.Income_other3 = Convert.ToDouble(dr["income_other3"]);
                    budget.Income_other4 = Convert.ToDouble(dr["income_other4"]);
                    budget.Income_other5 = Convert.ToDouble(dr["income_other5"]);
                    budget.Income_other6 = Convert.ToDouble(dr["income_other6"]);
                    budget.Income_other7 = Convert.ToDouble(dr["income_other7"]);
                    budget.Income_other8 = Convert.ToDouble(dr["income_other8"]);
                    budget.Income_other9 = Convert.ToDouble(dr["income_other9"]);
                    budget.Income_other10 = Convert.ToDouble(dr["income_other10"]);
                    budget.Exp_commission = Convert.ToDouble(dr["exp_commission"]);
                    budget.Exp_tiefei = Convert.ToDouble(dr["exp_tiefei"]);
                    budget.Exp_consultingFees = Convert.ToDouble(dr["exp_consultingFees"]);
                    budget.Exp_serviceCharge = Convert.ToDouble(dr["exp_serviceCharge"]);
                    budget.Exp_managementFees = Convert.ToDouble(dr["exp_managementFees"]);
                    budget.Exp_interest = Convert.ToDouble(dr["exp_interest"]);
                    budget.Exp_brokerageFeesTaxes = Convert.ToDouble(dr["exp_brokerageFeesTaxes"]);
                    budget.Exp_serviceChargeTaxes = Convert.ToDouble(dr["exp_serviceChargeTaxes"]);
                    budget.Exp_otherTaxes = Convert.ToDouble(dr["exp_otherTaxes"]);
                    budget.Exp_other1 = Convert.ToDouble(dr["exp_other1"]);
                    budget.Exp_other2 = Convert.ToDouble(dr["exp_other2"]);
                    budget.Exp_other3 = Convert.ToDouble(dr["exp_other3"]);
                    budget.Exp_other4 = Convert.ToDouble(dr["exp_other4"]);
                    budget.Exp_other5 = Convert.ToDouble(dr["exp_other5"]);
                    budget.Exp_other1Ratio = Convert.ToDouble(dr["exp_other1Ratio"]);
                    budget.Exp_other2Ratio = Convert.ToDouble(dr["exp_other2Ratio"]);
                    budget.Exp_other3Ratio = Convert.ToDouble(dr["exp_other3Ratio"]);
                    budget.Exp_other4Ratio = Convert.ToDouble(dr["exp_other4Ratio"]);
                    budget.Exp_other5Ratio = Convert.ToDouble(dr["exp_other5Ratio"]);
                    budget.Exp_commissionRatio = Convert.ToDouble(dr["exp_commissionRatio"]);
                    budget.Exp_tiefeiRatio = Convert.ToDouble(dr["exp_tiefeiRatio"]);
                    budget.Exp_consultingFeesRatio = Convert.ToDouble(dr["exp_consultingFeesRatio"]);
                    budget.Exp_serviceChargeRatio = Convert.ToDouble(dr["exp_serviceChargeRatio"]);
                    budget.Exp_managementFeesRatio = Convert.ToDouble(dr["exp_managementFeesRatio"]);
                    budget.Exp_interestRatio1 = Convert.ToDouble(dr["exp_interestRatio1"]);
                    budget.Exp_interestRatio2 = Convert.ToDouble(dr["exp_interestRatio2"]);
                    budget.Exp_brokerageFeesTaxesRatio = Convert.ToDouble(dr["exp_brokerageFeesTaxesRatio"]);
                    budget.Exp_serviceChargeTaxesRatio = Convert.ToDouble(dr["exp_serviceChargeTaxesRatio"]);
                    budget.Exp_otherTaxesRatio = Convert.ToDouble(dr["exp_otherTaxesRatio"]);
                    budget.Income_premiumMark = Convert.ToString(dr["income_premiumMark"]);
                    budget.Income_brokerageFeesMark = Convert.ToString(dr["income_brokerageFeesMark"]);
                    budget.Income_serviceChargeMark = Convert.ToString(dr["income_serviceChargeMark"]);
                    budget.Income_other1Mark = Convert.ToString(dr["income_other1Mark"]);
                    budget.Income_other2Mark = Convert.ToString(dr["income_other2Mark"]);
                    budget.Income_other3Mark = Convert.ToString(dr["income_other3Mark"]);
                    budget.Income_other4Mark = Convert.ToString(dr["income_other4Mark"]);
                    budget.Income_other5Mark = Convert.ToString(dr["income_other5Mark"]);
                    budget.Income_other6Mark = Convert.ToString(dr["income_other6Mark"]);
                    budget.Income_other7Mark = Convert.ToString(dr["income_other7Mark"]);
                    budget.Income_other8Mark = Convert.ToString(dr["income_other8Mark"]);
                    budget.Income_other9Mark = Convert.ToString(dr["income_other9Mark"]);
                    budget.Income_other10Mark = Convert.ToString(dr["income_other10Mark"]);
                    budget.Exp_commissionMark = Convert.ToString(dr["exp_commissionMark"]);
                    budget.Exp_tiefeiMark = Convert.ToString(dr["exp_tiefeiMark"]);
                    budget.Exp_consultingFeesMark = Convert.ToString(dr["exp_consultingFeesMark"]);
                    budget.Exp_serviceChargeMark = Convert.ToString(dr["exp_serviceChargeMark"]);
                    budget.Exp_managementFeesMark = Convert.ToString(dr["exp_managementFeesMark"]);
                    budget.Exp_interestMark = Convert.ToString(dr["exp_interestMark"]);
                    budget.Exp_brokerageFeesTaxesMark = Convert.ToString(dr["exp_brokerageFeesTaxesMark"]);
                    budget.Exp_serviceChargeTaxesMark = Convert.ToString(dr["exp_serviceChargeTaxesMark"]);
                    budget.Exp_otherTaxesRatioMark = Convert.ToString(dr["exp_otherTaxesRatioMark"]);
                    budget.Exp_other1Mark = Convert.ToString(dr["exp_other1Mark"]);
                    budget.Exp_other2Mark = Convert.ToString(dr["exp_other2Mark"]);
                    budget.Exp_other3Mark = Convert.ToString(dr["exp_other3Mark"]);
                    budget.Exp_other4Mark = Convert.ToString(dr["exp_other4Mark"]);
                    budget.Exp_other5Mark = Convert.ToString(dr["exp_other5Mark"]);
                }
            }

            return budget;
        }

        /// <summary>
        ///[Budget]表查询所有的方法
        /// </summary>
        public static IList<Budget> getBudgetAll()
        {
            string sql = "select * from Budget";
            return getBudgetsBySql(sql);
        }
        /// <summary>
        ///根据SQL语句获取集合
        /// </summary>
        public static IList<Budget> getBudgetsBySql(string sql)
        {
            IList<Budget> list = new List<Budget>();
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Budget budget = new Budget();
                    budget.Id = Convert.ToInt32(dr["id"]);
                    budget.PolicyId = Convert.ToInt32(dr["policyId"]);
                    budget.Income_premium = Convert.ToDouble(dr["income_premium"]);
                    budget.Income_brokerageFees = Convert.ToDouble(dr["income_brokerageFees"]);
                    budget.Income_serviceCharge = Convert.ToDouble(dr["income_serviceCharge"]);
                    budget.Income_other1 = Convert.ToDouble(dr["income_other1"]);
                    budget.Income_other2 = Convert.ToDouble(dr["income_other2"]);
                    budget.Income_other3 = Convert.ToDouble(dr["income_other3"]);
                    budget.Income_other4 = Convert.ToDouble(dr["income_other4"]);
                    budget.Income_other5 = Convert.ToDouble(dr["income_other5"]);
                    budget.Income_other6 = Convert.ToDouble(dr["income_other6"]);
                    budget.Income_other7 = Convert.ToDouble(dr["income_other7"]);
                    budget.Income_other8 = Convert.ToDouble(dr["income_other8"]);
                    budget.Income_other9 = Convert.ToDouble(dr["income_other9"]);
                    budget.Income_other10 = Convert.ToDouble(dr["income_other10"]);
                    budget.Exp_commission = Convert.ToDouble(dr["exp_commission"]);
                    budget.Exp_tiefei = Convert.ToDouble(dr["exp_tiefei"]);
                    budget.Exp_consultingFees = Convert.ToDouble(dr["exp_consultingFees"]);
                    budget.Exp_serviceCharge = Convert.ToDouble(dr["exp_serviceCharge"]);
                    budget.Exp_managementFees = Convert.ToDouble(dr["exp_managementFees"]);
                    budget.Exp_interest = Convert.ToDouble(dr["exp_interest"]);
                    budget.Exp_brokerageFeesTaxes = Convert.ToDouble(dr["exp_brokerageFeesTaxes"]);
                    budget.Exp_serviceChargeTaxes = Convert.ToDouble(dr["exp_serviceChargeTaxes"]);
                    budget.Exp_otherTaxes = Convert.ToDouble(dr["exp_otherTaxes"]);
                    budget.Exp_other1 = Convert.ToDouble(dr["exp_other1"]);
                    budget.Exp_other2 = Convert.ToDouble(dr["exp_other2"]);
                    budget.Exp_other3 = Convert.ToDouble(dr["exp_other3"]);
                    budget.Exp_other4 = Convert.ToDouble(dr["exp_other4"]);
                    budget.Exp_other5 = Convert.ToDouble(dr["exp_other5"]);
                    budget.Exp_other1Ratio = Convert.ToDouble(dr["exp_other1Ratio"]);
                    budget.Exp_other2Ratio = Convert.ToDouble(dr["exp_other2Ratio"]);
                    budget.Exp_other3Ratio = Convert.ToDouble(dr["exp_other3Ratio"]);
                    budget.Exp_other4Ratio = Convert.ToDouble(dr["exp_other4Ratio"]);
                    budget.Exp_other5Ratio = Convert.ToDouble(dr["exp_other5Ratio"]);
                    budget.Exp_commissionRatio = Convert.ToDouble(dr["exp_commissionRatio"]);
                    budget.Exp_tiefeiRatio = Convert.ToDouble(dr["exp_tiefeiRatio"]);
                    budget.Exp_consultingFeesRatio = Convert.ToDouble(dr["exp_consultingFeesRatio"]);
                    budget.Exp_serviceChargeRatio = Convert.ToDouble(dr["exp_serviceChargeRatio"]);
                    budget.Exp_managementFeesRatio = Convert.ToDouble(dr["exp_managementFeesRatio"]);
                    budget.Exp_interestRatio1 = Convert.ToDouble(dr["exp_interestRatio1"]);
                    budget.Exp_interestRatio2 = Convert.ToDouble(dr["exp_interestRatio2"]);
                    budget.Exp_brokerageFeesTaxesRatio = Convert.ToDouble(dr["exp_brokerageFeesTaxesRatio"]);
                    budget.Exp_serviceChargeTaxesRatio = Convert.ToDouble(dr["exp_serviceChargeTaxesRatio"]);
                    budget.Exp_otherTaxesRatio = Convert.ToDouble(dr["exp_otherTaxesRatio"]);
                    budget.Income_premiumMark = Convert.ToString(dr["income_premiumMark"]);
                    budget.Income_brokerageFeesMark = Convert.ToString(dr["income_brokerageFeesMark"]);
                    budget.Income_serviceChargeMark = Convert.ToString(dr["income_serviceChargeMark"]);
                    budget.Income_other1Mark = Convert.ToString(dr["income_other1Mark"]);
                    budget.Income_other2Mark = Convert.ToString(dr["income_other2Mark"]);
                    budget.Income_other3Mark = Convert.ToString(dr["income_other3Mark"]);
                    budget.Income_other4Mark = Convert.ToString(dr["income_other4Mark"]);
                    budget.Income_other5Mark = Convert.ToString(dr["income_other5Mark"]);
                    budget.Income_other6Mark = Convert.ToString(dr["income_other6Mark"]);
                    budget.Income_other7Mark = Convert.ToString(dr["income_other7Mark"]);
                    budget.Income_other8Mark = Convert.ToString(dr["income_other8Mark"]);
                    budget.Income_other9Mark = Convert.ToString(dr["income_other9Mark"]);
                    budget.Income_other10Mark = Convert.ToString(dr["income_other10Mark"]);
                    budget.Exp_commissionMark = Convert.ToString(dr["exp_commissionMark"]);
                    budget.Exp_tiefeiMark = Convert.ToString(dr["exp_tiefeiMark"]);
                    budget.Exp_consultingFeesMark = Convert.ToString(dr["exp_consultingFeesMark"]);
                    budget.Exp_serviceChargeMark = Convert.ToString(dr["exp_serviceChargeMark"]);
                    budget.Exp_managementFeesMark = Convert.ToString(dr["exp_managementFeesMark"]);
                    budget.Exp_interestMark = Convert.ToString(dr["exp_interestMark"]);
                    budget.Exp_brokerageFeesTaxesMark = Convert.ToString(dr["exp_brokerageFeesTaxesMark"]);
                    budget.Exp_serviceChargeTaxesMark = Convert.ToString(dr["exp_serviceChargeTaxesMark"]);
                    budget.Exp_otherTaxesRatioMark = Convert.ToString(dr["exp_otherTaxesRatioMark"]);
                    budget.Exp_other1Mark = Convert.ToString(dr["exp_other1Mark"]);
                    budget.Exp_other2Mark = Convert.ToString(dr["exp_other2Mark"]);
                    budget.Exp_other3Mark = Convert.ToString(dr["exp_other3Mark"]);
                    budget.Exp_other4Mark = Convert.ToString(dr["exp_other4Mark"]);
                    budget.Exp_other5Mark = Convert.ToString(dr["exp_other5Mark"]);
                    list.Add(budget);
                }
            }
            return list;
        }
        /// <summary>
        ///根据SQL语句获取实体
        /// </summary>
        public static Budget getBudgetBySql(string sql)
        {
            Budget budget = null;
            DataTable dt = DBHelper.GetDataSet(sql);
            if (dt.Rows.Count > 0)
            {
                budget = new Budget();
                foreach (DataRow dr in dt.Rows)
                {
                    budget.Id = Convert.ToInt32(dr["id"]);
                    budget.PolicyId = Convert.ToInt32(dr["policyId"]);
                    budget.Income_premium = Convert.ToDouble(dr["income_premium"]);
                    budget.Income_brokerageFees = Convert.ToDouble(dr["income_brokerageFees"]);
                    budget.Income_serviceCharge = Convert.ToDouble(dr["income_serviceCharge"]);
                    budget.Income_other1 = Convert.ToDouble(dr["income_other1"]);
                    budget.Income_other2 = Convert.ToDouble(dr["income_other2"]);
                    budget.Income_other3 = Convert.ToDouble(dr["income_other3"]);
                    budget.Income_other4 = Convert.ToDouble(dr["income_other4"]);
                    budget.Income_other5 = Convert.ToDouble(dr["income_other5"]);
                    budget.Income_other6 = Convert.ToDouble(dr["income_other6"]);
                    budget.Income_other7 = Convert.ToDouble(dr["income_other7"]);
                    budget.Income_other8 = Convert.ToDouble(dr["income_other8"]);
                    budget.Income_other9 = Convert.ToDouble(dr["income_other9"]);
                    budget.Income_other10 = Convert.ToDouble(dr["income_other10"]);
                    budget.Exp_commission = Convert.ToDouble(dr["exp_commission"]);
                    budget.Exp_tiefei = Convert.ToDouble(dr["exp_tiefei"]);
                    budget.Exp_consultingFees = Convert.ToDouble(dr["exp_consultingFees"]);
                    budget.Exp_serviceCharge = Convert.ToDouble(dr["exp_serviceCharge"]);
                    budget.Exp_managementFees = Convert.ToDouble(dr["exp_managementFees"]);
                    budget.Exp_interest = Convert.ToDouble(dr["exp_interest"]);
                    budget.Exp_brokerageFeesTaxes = Convert.ToDouble(dr["exp_brokerageFeesTaxes"]);
                    budget.Exp_serviceChargeTaxes = Convert.ToDouble(dr["exp_serviceChargeTaxes"]);
                    budget.Exp_otherTaxes = Convert.ToDouble(dr["exp_otherTaxes"]);
                    budget.Exp_other1 = Convert.ToDouble(dr["exp_other1"]);
                    budget.Exp_other2 = Convert.ToDouble(dr["exp_other2"]);
                    budget.Exp_other3 = Convert.ToDouble(dr["exp_other3"]);
                    budget.Exp_other4 = Convert.ToDouble(dr["exp_other4"]);
                    budget.Exp_other5 = Convert.ToDouble(dr["exp_other5"]);
                    budget.Exp_other1Ratio = Convert.ToDouble(dr["exp_other1Ratio"]);
                    budget.Exp_other2Ratio = Convert.ToDouble(dr["exp_other2Ratio"]);
                    budget.Exp_other3Ratio = Convert.ToDouble(dr["exp_other3Ratio"]);
                    budget.Exp_other4Ratio = Convert.ToDouble(dr["exp_other4Ratio"]);
                    budget.Exp_other5Ratio = Convert.ToDouble(dr["exp_other5Ratio"]);
                    budget.Exp_commissionRatio = Convert.ToDouble(dr["exp_commissionRatio"]);
                    budget.Exp_tiefeiRatio = Convert.ToDouble(dr["exp_tiefeiRatio"]);
                    budget.Exp_consultingFeesRatio = Convert.ToDouble(dr["exp_consultingFeesRatio"]);
                    budget.Exp_serviceChargeRatio = Convert.ToDouble(dr["exp_serviceChargeRatio"]);
                    budget.Exp_managementFeesRatio = Convert.ToDouble(dr["exp_managementFeesRatio"]);
                    budget.Exp_interestRatio1 = Convert.ToDouble(dr["exp_interestRatio1"]);
                    budget.Exp_interestRatio2 = Convert.ToDouble(dr["exp_interestRatio2"]);
                    budget.Exp_brokerageFeesTaxesRatio = Convert.ToDouble(dr["exp_brokerageFeesTaxesRatio"]);
                    budget.Exp_serviceChargeTaxesRatio = Convert.ToDouble(dr["exp_serviceChargeTaxesRatio"]);
                    budget.Exp_otherTaxesRatio = Convert.ToDouble(dr["exp_otherTaxesRatio"]);
                    budget.Income_premiumMark = Convert.ToString(dr["income_premiumMark"]);
                    budget.Income_brokerageFeesMark = Convert.ToString(dr["income_brokerageFeesMark"]);
                    budget.Income_serviceChargeMark = Convert.ToString(dr["income_serviceChargeMark"]);
                    budget.Income_other1Mark = Convert.ToString(dr["income_other1Mark"]);
                    budget.Income_other2Mark = Convert.ToString(dr["income_other2Mark"]);
                    budget.Income_other3Mark = Convert.ToString(dr["income_other3Mark"]);
                    budget.Income_other4Mark = Convert.ToString(dr["income_other4Mark"]);
                    budget.Income_other5Mark = Convert.ToString(dr["income_other5Mark"]);
                    budget.Income_other6Mark = Convert.ToString(dr["income_other6Mark"]);
                    budget.Income_other7Mark = Convert.ToString(dr["income_other7Mark"]);
                    budget.Income_other8Mark = Convert.ToString(dr["income_other8Mark"]);
                    budget.Income_other9Mark = Convert.ToString(dr["income_other9Mark"]);
                    budget.Income_other10Mark = Convert.ToString(dr["income_other10Mark"]);
                    budget.Exp_commissionMark = Convert.ToString(dr["exp_commissionMark"]);
                    budget.Exp_tiefeiMark = Convert.ToString(dr["exp_tiefeiMark"]);
                    budget.Exp_consultingFeesMark = Convert.ToString(dr["exp_consultingFeesMark"]);
                    budget.Exp_serviceChargeMark = Convert.ToString(dr["exp_serviceChargeMark"]);
                    budget.Exp_managementFeesMark = Convert.ToString(dr["exp_managementFeesMark"]);
                    budget.Exp_interestMark = Convert.ToString(dr["exp_interestMark"]);
                    budget.Exp_brokerageFeesTaxesMark = Convert.ToString(dr["exp_brokerageFeesTaxesMark"]);
                    budget.Exp_serviceChargeTaxesMark = Convert.ToString(dr["exp_serviceChargeTaxesMark"]);
                    budget.Exp_otherTaxesRatioMark = Convert.ToString(dr["exp_otherTaxesRatioMark"]);
                    budget.Exp_other1Mark = Convert.ToString(dr["exp_other1Mark"]);
                    budget.Exp_other2Mark = Convert.ToString(dr["exp_other2Mark"]);
                    budget.Exp_other3Mark = Convert.ToString(dr["exp_other3Mark"]);
                    budget.Exp_other4Mark = Convert.ToString(dr["exp_other4Mark"]);
                    budget.Exp_other5Mark = Convert.ToString(dr["exp_other5Mark"]);
                }
            }
            return budget;
        }
    }

    public static class DbNull2Double
    {
        public static double? DbNullToDouble(this object value)
        {
            if (value == DBNull.Value)
                return null;
            double result=0;
            if(double.TryParse(value.ToString(),out result))
            {
                return result;
            }
            return null;
        }
    }
}
