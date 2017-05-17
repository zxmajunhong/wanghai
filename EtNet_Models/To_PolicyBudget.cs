using System;
using System.Collections.Generic;
using System.Text;
namespace EtNet_Models
{
  [Serializable]
  public class To_PolicyBudget
  {
   //Budget���Ĭ�Ϲ��췽��
   public To_PolicyBudget ()
   {

   }
   private int id;
   /// <summary>
   ///[Budget]������
   /// </summary>
   public int Id
   {
     get{ return id; }
     set{ this.id=value;}
   }
   private int policyId;
   /// <summary>
   ///[Budget]�� [policyId]��
   /// </summary>
   public int PolicyId
   {
     get{ return policyId; }
     set{ this.policyId=value;}
   }
   private double? income_premium;
   /// <summary>
   ///[Budget]�� [income_premium]��
   /// </summary>
   public double? Income_premium
   {
     get{ return income_premium; }
     set{ this.income_premium=value;}
   }
   private double? income_brokerageFees;
   /// <summary>
   ///[Budget]�� [income_brokerageFees]��
   /// </summary>
   public double? Income_brokerageFees
   {
     get{ return income_brokerageFees; }
     set{ this.income_brokerageFees=value;}
   }
   private double? income_serviceCharge;
   /// <summary>
   ///[Budget]�� [income_serviceCharge]��
   /// </summary>
   public double? Income_serviceCharge
   {
     get{ return income_serviceCharge; }
     set{ this.income_serviceCharge=value;}
   }
   private double? income_other1;
   /// <summary>
   ///[Budget]�� [income_other1]��
   /// </summary>
   public double? Income_other1
   {
     get{ return income_other1; }
     set{ this.income_other1=value;}
   }
   private double? income_other2;
   /// <summary>
   ///[Budget]�� [income_other2]��
   /// </summary>
   public double? Income_other2
   {
     get{ return income_other2; }
     set{ this.income_other2=value;}
   }
   private double? income_other3;
   /// <summary>
   ///[Budget]�� [income_other3]��
   /// </summary>
   public double? Income_other3
   {
     get{ return income_other3; }
     set{ this.income_other3=value;}
   }
   private double? income_other4;
   /// <summary>
   ///[Budget]�� [income_other4]��
   /// </summary>
   public double? Income_other4
   {
     get{ return income_other4; }
     set{ this.income_other4=value;}
   }
   private double? income_other5;
   /// <summary>
   ///[Budget]�� [income_other5]��
   /// </summary>
   public double? Income_other5
   {
     get{ return income_other5; }
     set{ this.income_other5=value;}
   }
   private double? income_other6;
   /// <summary>
   ///[Budget]�� [income_other6]��
   /// </summary>
   public double? Income_other6
   {
     get{ return income_other6; }
     set{ this.income_other6=value;}
   }
   private double? income_other7;
   /// <summary>
   ///[Budget]�� [income_other7]��
   /// </summary>
   public double? Income_other7
   {
     get{ return income_other7; }
     set{ this.income_other7=value;}
   }
   private double? income_other8;
   /// <summary>
   ///[Budget]�� [income_other8]��
   /// </summary>
   public double? Income_other8
   {
     get{ return income_other8; }
     set{ this.income_other8=value;}
   }
   private double? income_other9;
   /// <summary>
   ///[Budget]�� [income_other9]��
   /// </summary>
   public double? Income_other9
   {
     get{ return income_other9; }
     set{ this.income_other9=value;}
   }
   private double? income_other10;
   /// <summary>
   ///[Budget]�� [income_other10]��
   /// </summary>
   public double? Income_other10
   {
     get{ return income_other10; }
     set{ this.income_other10=value;}
   }
   private double? exp_commission;
   /// <summary>
   ///[Budget]�� [exp_commission]��
   /// </summary>
   public double? Exp_commission
   {
     get{ return exp_commission; }
     set{ this.exp_commission=value;}
   }
   private double? exp_tiefei;
   /// <summary>
   ///[Budget]�� [exp_tiefei]��
   /// </summary>
   public double? Exp_tiefei
   {
     get{ return exp_tiefei; }
     set{ this.exp_tiefei=value;}
   }
   private double? exp_consultingFees;
   /// <summary>
   ///[Budget]�� [exp_consultingFees]��
   /// </summary>
   public double? Exp_consultingFees
   {
     get{ return exp_consultingFees; }
     set{ this.exp_consultingFees=value;}
   }
   private double? exp_serviceCharge;
   /// <summary>
   ///[Budget]�� [exp_serviceCharge]��
   /// </summary>
   public double? Exp_serviceCharge
   {
     get{ return exp_serviceCharge; }
     set{ this.exp_serviceCharge=value;}
   }
   private double? exp_managementFees;
   /// <summary>
   ///[Budget]�� [exp_managementFees]��
   /// </summary>
   public double? Exp_managementFees
   {
     get{ return exp_managementFees; }
     set{ this.exp_managementFees=value;}
   }
   private double? exp_interest;
   /// <summary>
   ///[Budget]�� [exp_interest]��
   /// </summary>
   public double? Exp_interest
   {
     get{ return exp_interest; }
     set{ this.exp_interest=value;}
   }
   private double? exp_brokerageFeesTaxes;
   /// <summary>
   ///[Budget]�� [exp_brokerageFeesTaxes]��
   /// </summary>
   public double? Exp_brokerageFeesTaxes
   {
     get{ return exp_brokerageFeesTaxes; }
     set{ this.exp_brokerageFeesTaxes=value;}
   }
   private double? exp_serviceChargeTaxes;
   /// <summary>
   ///[Budget]�� [exp_serviceChargeTaxes]��
   /// </summary>
   public double? Exp_serviceChargeTaxes
   {
     get{ return exp_serviceChargeTaxes; }
     set{ this.exp_serviceChargeTaxes=value;}
   }
   private double? exp_otherTaxes;
   /// <summary>
   ///[Budget]�� [exp_otherTaxes]��
   /// </summary>
   public double? Exp_otherTaxes
   {
     get{ return exp_otherTaxes; }
     set{ this.exp_otherTaxes=value;}
   }
   private double? exp_other1;
   /// <summary>
   ///[Budget]�� [exp_other1]��
   /// </summary>
   public double? Exp_other1
   {
     get{ return exp_other1; }
     set{ this.exp_other1=value;}
   }
   private double? exp_other2;
   /// <summary>
   ///[Budget]�� [exp_other2]��
   /// </summary>
   public double? Exp_other2
   {
     get{ return exp_other2; }
     set{ this.exp_other2=value;}
   }
   private double? exp_other3;
   /// <summary>
   ///[Budget]�� [exp_other3]��
   /// </summary>
   public double? Exp_other3
   {
     get{ return exp_other3; }
     set{ this.exp_other3=value;}
   }
   private double? exp_other4;
   /// <summary>
   ///[Budget]�� [exp_other4]��
   /// </summary>
   public double? Exp_other4
   {
     get{ return exp_other4; }
     set{ this.exp_other4=value;}
   }
   private double? exp_other5;
   /// <summary>
   ///[Budget]�� [exp_other5]��
   /// </summary>
   public double? Exp_other5
   {
     get{ return exp_other5; }
     set{ this.exp_other5=value;}
   }
   private double? exp_other1Ratio;
   /// <summary>
   ///[Budget]�� [exp_other1Ratio]��
   /// </summary>
   public double? Exp_other1Ratio
   {
     get{ return exp_other1Ratio; }
     set{ this.exp_other1Ratio=value;}
   }
   private double? exp_other2Ratio;
   /// <summary>
   ///[Budget]�� [exp_other2Ratio]��
   /// </summary>
   public double? Exp_other2Ratio
   {
     get{ return exp_other2Ratio; }
     set{ this.exp_other2Ratio=value;}
   }
   private double? exp_other3Ratio;
   /// <summary>
   ///[Budget]�� [exp_other3Ratio]��
   /// </summary>
   public double? Exp_other3Ratio
   {
     get{ return exp_other3Ratio; }
     set{ this.exp_other3Ratio=value;}
   }
   private double? exp_other4Ratio;
   /// <summary>
   ///[Budget]�� [exp_other4Ratio]��
   /// </summary>
   public double? Exp_other4Ratio
   {
     get{ return exp_other4Ratio; }
     set{ this.exp_other4Ratio=value;}
   }
   private double? exp_other5Ratio;
   /// <summary>
   ///[Budget]�� [exp_other5Ratio]��
   /// </summary>
   public double? Exp_other5Ratio
   {
     get{ return exp_other5Ratio; }
     set{ this.exp_other5Ratio=value;}
   }
   private double? exp_commissionRatio;
   /// <summary>
   ///[Budget]�� [exp_commissionRatio]��
   /// </summary>
   public double? Exp_commissionRatio
   {
     get{ return exp_commissionRatio; }
     set{ this.exp_commissionRatio=value;}
   }
   private double? exp_tiefeiRatio;
   /// <summary>
   ///[Budget]�� [exp_tiefeiRatio]��
   /// </summary>
   public double? Exp_tiefeiRatio
   {
     get{ return exp_tiefeiRatio; }
     set{ this.exp_tiefeiRatio=value;}
   }
   private double? exp_consultingFeesRatio;
   /// <summary>
   ///[Budget]�� [exp_consultingFeesRatio]��
   /// </summary>
   public double? Exp_consultingFeesRatio
   {
     get{ return exp_consultingFeesRatio; }
     set{ this.exp_consultingFeesRatio=value;}
   }
   private double? exp_serviceChargeRatio;
   /// <summary>
   ///[Budget]�� [exp_serviceChargeRatio]��
   /// </summary>
   public double? Exp_serviceChargeRatio
   {
     get{ return exp_serviceChargeRatio; }
     set{ this.exp_serviceChargeRatio=value;}
   }
   private double? exp_managementFeesRatio;
   /// <summary>
   ///[Budget]�� [exp_managementFeesRatio]��
   /// </summary>
   public double? Exp_managementFeesRatio
   {
     get{ return exp_managementFeesRatio; }
     set{ this.exp_managementFeesRatio=value;}
   }
   private double? exp_interestRatio1;
   /// <summary>
   ///[Budget]�� [exp_interestRatio1]��
   /// </summary>
   public double? Exp_interestRatio1
   {
     get{ return exp_interestRatio1; }
     set{ this.exp_interestRatio1=value;}
   }
   private double? exp_interestRatio2;
   /// <summary>
   ///[Budget]�� [exp_interestRatio2]��
   /// </summary>
   public double? Exp_interestRatio2
   {
     get{ return exp_interestRatio2; }
     set{ this.exp_interestRatio2=value;}
   }
   private double? exp_brokerageFeesTaxesRatio;
   /// <summary>
   ///[Budget]�� [exp_brokerageFeesTaxesRatio]��
   /// </summary>
   public double? Exp_brokerageFeesTaxesRatio
   {
     get{ return exp_brokerageFeesTaxesRatio; }
     set{ this.exp_brokerageFeesTaxesRatio=value;}
   }
   private double? exp_serviceChargeTaxesRatio;
   /// <summary>
   ///[Budget]�� [exp_serviceChargeTaxesRatio]��
   /// </summary>
   public double? Exp_serviceChargeTaxesRatio
   {
     get{ return exp_serviceChargeTaxesRatio; }
     set{ this.exp_serviceChargeTaxesRatio=value;}
   }
   private double? exp_otherTaxesRatio;
   /// <summary>
   ///[Budget]�� [exp_otherTaxesRatio]��
   /// </summary>
   public double? Exp_otherTaxesRatio
   {
     get{ return exp_otherTaxesRatio; }
     set{ this.exp_otherTaxesRatio=value;}
   }
   private string income_premiumMark;
   /// <summary>
   ///[Budget]�� [income_premiumMark]��
   /// </summary>
   public string Income_premiumMark
   {
     get{ return income_premiumMark; }
     set{ this.income_premiumMark=value;}
   }
   private string income_brokerageFeesMark;
   /// <summary>
   ///[Budget]�� [income_brokerageFeesMark]��
   /// </summary>
   public string Income_brokerageFeesMark
   {
     get{ return income_brokerageFeesMark; }
     set{ this.income_brokerageFeesMark=value;}
   }
   private string income_serviceChargeMark;
   /// <summary>
   ///[Budget]�� [income_serviceChargeMark]��
   /// </summary>
   public string Income_serviceChargeMark
   {
     get{ return income_serviceChargeMark; }
     set{ this.income_serviceChargeMark=value;}
   }
   private string income_other1Mark;
   /// <summary>
   ///[Budget]�� [income_other1Mark]��
   /// </summary>
   public string Income_other1Mark
   {
     get{ return income_other1Mark; }
     set{ this.income_other1Mark=value;}
   }
   private string income_other2Mark;
   /// <summary>
   ///[Budget]�� [income_other2Mark]��
   /// </summary>
   public string Income_other2Mark
   {
     get{ return income_other2Mark; }
     set{ this.income_other2Mark=value;}
   }
   private string income_other3Mark;
   /// <summary>
   ///[Budget]�� [income_other3Mark]��
   /// </summary>
   public string Income_other3Mark
   {
     get{ return income_other3Mark; }
     set{ this.income_other3Mark=value;}
   }
   private string income_other4Mark;
   /// <summary>
   ///[Budget]�� [income_other4Mark]��
   /// </summary>
   public string Income_other4Mark
   {
     get{ return income_other4Mark; }
     set{ this.income_other4Mark=value;}
   }
   private string income_other5Mark;
   /// <summary>
   ///[Budget]�� [income_other5Mark]��
   /// </summary>
   public string Income_other5Mark
   {
     get{ return income_other5Mark; }
     set{ this.income_other5Mark=value;}
   }
   private string income_other6Mark;
   /// <summary>
   ///[Budget]�� [income_other6Mark]��
   /// </summary>
   public string Income_other6Mark
   {
     get{ return income_other6Mark; }
     set{ this.income_other6Mark=value;}
   }
   private string income_other7Mark;
   /// <summary>
   ///[Budget]�� [income_other7Mark]��
   /// </summary>
   public string Income_other7Mark
   {
     get{ return income_other7Mark; }
     set{ this.income_other7Mark=value;}
   }
   private string income_other8Mark;
   /// <summary>
   ///[Budget]�� [income_other8Mark]��
   /// </summary>
   public string Income_other8Mark
   {
     get{ return income_other8Mark; }
     set{ this.income_other8Mark=value;}
   }
   private string income_other9Mark;
   /// <summary>
   ///[Budget]�� [income_other9Mark]��
   /// </summary>
   public string Income_other9Mark
   {
     get{ return income_other9Mark; }
     set{ this.income_other9Mark=value;}
   }
   private string income_other10Mark;
   /// <summary>
   ///[Budget]�� [income_other10Mark]��
   /// </summary>
   public string Income_other10Mark
   {
     get{ return income_other10Mark; }
     set{ this.income_other10Mark=value;}
   }
   private string exp_commissionMark;
   /// <summary>
   ///[Budget]�� [exp_commissionMark]��
   /// </summary>
   public string Exp_commissionMark
   {
     get{ return exp_commissionMark; }
     set{ this.exp_commissionMark=value;}
   }
   private string exp_tiefeiMark;
   /// <summary>
   ///[Budget]�� [exp_tiefeiMark]��
   /// </summary>
   public string Exp_tiefeiMark
   {
     get{ return exp_tiefeiMark; }
     set{ this.exp_tiefeiMark=value;}
   }
   private string exp_consultingFeesMark;
   /// <summary>
   ///[Budget]�� [exp_consultingFeesMark]��
   /// </summary>
   public string Exp_consultingFeesMark
   {
     get{ return exp_consultingFeesMark; }
     set{ this.exp_consultingFeesMark=value;}
   }
   private string exp_serviceChargeMark;
   /// <summary>
   ///[Budget]�� [exp_serviceChargeMark]��
   /// </summary>
   public string Exp_serviceChargeMark
   {
     get{ return exp_serviceChargeMark; }
     set{ this.exp_serviceChargeMark=value;}
   }
   private string exp_managementFeesMark;
   /// <summary>
   ///[Budget]�� [exp_managementFeesMark]��
   /// </summary>
   public string Exp_managementFeesMark
   {
     get{ return exp_managementFeesMark; }
     set{ this.exp_managementFeesMark=value;}
   }
   private string exp_interestMark;
   /// <summary>
   ///[Budget]�� [exp_interestMark]��
   /// </summary>
   public string Exp_interestMark
   {
     get{ return exp_interestMark; }
     set{ this.exp_interestMark=value;}
   }
   private string exp_brokerageFeesTaxesMark;
   /// <summary>
   ///[Budget]�� [exp_brokerageFeesTaxesMark]��
   /// </summary>
   public string Exp_brokerageFeesTaxesMark
   {
     get{ return exp_brokerageFeesTaxesMark; }
     set{ this.exp_brokerageFeesTaxesMark=value;}
   }
   private string exp_serviceChargeTaxesMark;
   /// <summary>
   ///[Budget]�� [exp_serviceChargeTaxesMark]��
   /// </summary>
   public string Exp_serviceChargeTaxesMark
   {
     get{ return exp_serviceChargeTaxesMark; }
     set{ this.exp_serviceChargeTaxesMark=value;}
   }
   private string exp_otherTaxesRatioMark;
   /// <summary>
   ///[Budget]�� [exp_otherTaxesRatioMark]��
   /// </summary>
   public string Exp_otherTaxesRatioMark
   {
     get{ return exp_otherTaxesRatioMark; }
     set{ this.exp_otherTaxesRatioMark=value;}
   }
   private string exp_other1Mark;
   /// <summary>
   ///[Budget]�� [exp_other1Mark]��
   /// </summary>
   public string Exp_other1Mark
   {
     get{ return exp_other1Mark; }
     set{ this.exp_other1Mark=value;}
   }
   private string exp_other2Mark;
   /// <summary>
   ///[Budget]�� [exp_other2Mark]��
   /// </summary>
   public string Exp_other2Mark
   {
     get{ return exp_other2Mark; }
     set{ this.exp_other2Mark=value;}
   }
   private string exp_other3Mark;
   /// <summary>
   ///[Budget]�� [exp_other3Mark]��
   /// </summary>
   public string Exp_other3Mark
   {
     get{ return exp_other3Mark; }
     set{ this.exp_other3Mark=value;}
   }
   private string exp_other4Mark;
   /// <summary>
   ///[Budget]�� [exp_other4Mark]��
   /// </summary>
   public string Exp_other4Mark
   {
     get{ return exp_other4Mark; }
     set{ this.exp_other4Mark=value;}
   }
   private string exp_other5Mark;
   /// <summary>
   ///[Budget]�� [exp_other5Mark]��
   /// </summary>
   public string Exp_other5Mark
   {
     get{ return exp_other5Mark; }
     set{ this.exp_other5Mark=value;}
   }

   public double? Exp_premium
   {
       get;
       set;
   }
   public string Exp_premiumMark
   {
       get;
       set;
   }
  }
}
