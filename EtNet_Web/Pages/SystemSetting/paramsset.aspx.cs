using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_BLL;

namespace EtNet_Web.Pages.SystemSetting
{
    public partial class paramsset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getBind();
            }
        }

        private void getBind()
        {
            IList<EtNet_Models.Parameter> param = ParameterManager.getParameterAll();
            if (param.Count > 0)
            {
                this.rate.Value = param[0].Rate.ToString();//银行利率
                this.fwfbl.Value = param[0].ServiceRatio.ToString();//服务费比率
                this.freeDay.Value = param[0].FreeDay.ToString();//免息天数
                this.zxfbl.Value = param[0].ConRatio.ToString();//咨询费比率
                this.glfbl.Value = param[0].BrokeRatio.ToString();//管理费比率
                this.jjfsl.Value = param[0].BrokeTaxRatio.ToString();//经纪费税率
                this.qtsl.Value = param[0].OtherRatio.ToString();//其它税率
                fwfsl.Value = param[0].ServiceTaxRatio.ToString();//服务费税率
            }
        }


        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            addData();
        }
        /// <summary>
        ///设置方法
        /// </summary>
        private void addData()
        {
            IList<EtNet_Models.Parameter> pa = ParameterManager.getParameterAll();
            EtNet_Models.Parameter param = new EtNet_Models.Parameter();
            param.Id = pa[0].Id;
            param.Rate = this.rate.Value.ToString();
            param.ServiceRatio = this.fwfbl.Value.ToString();
            param.FreeDay = Convert.ToInt32(this.freeDay.Value);
            param.ConRatio = this.zxfbl.Value.ToString();
            param.BrokeRatio = this.glfbl.Value.ToString();
            param.BrokeTaxRatio = this.jjfsl.Value.ToString();
            param.OtherRatio = this.qtsl.Value.ToString();
            param.Commission = RatioManager.getRatioTop1()[0].Id;
            param.ServiceTaxRatio = fwfsl.Value.ToString();

            int count = ParameterManager.updateParameter(param);

            if (count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('设置成功！');location.href='../SystemSetting/paramsset.aspx'", true);
            }

        }
    }
}