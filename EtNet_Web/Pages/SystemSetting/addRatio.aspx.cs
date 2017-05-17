using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EtNet_Models;
using EtNet_BLL;

namespace EtNet_Web.Pages.SystemSetting
{
    public partial class addRatio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindRatio();
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void bindRatio()
        {
            IList<EtNet_Models.Ratio> ratioid = RatioManager.getRatioTop1();
            if (ratioid.Count > 0)
            {
                string[] rt1value = ratioid[0].Ratio1.ToString().Split(',');
                this.rt1.Value = rt1value[0].ToString();
                this.rt11.Value = rt1value[1].ToString();

                string[] rt2value = ratioid[0].Ratio2.ToString().Split(',');
                this.rt2.Value = rt2value[0].ToString();
                this.rt22.Value = rt2value[1].ToString();

                string[] rt3value = ratioid[0].Ratio3.ToString().Split(',');
                this.rt3.Value = rt3value[0].ToString();
                this.rt33.Value = rt3value[1].ToString();

                string[] rt4value = ratioid[0].Ratio4.ToString().Split(',');
                this.rt4.Value = rt4value[0].ToString();
                this.rt44.Value = rt4value[1].ToString();

                string[] rt5value = ratioid[0].Ratio5.ToString().Split(',');
                this.rt5.Value = rt5value[0].ToString();
                this.rt55.Value = rt5value[1].ToString();


                string[] rt6value = ratioid[0].Ratio6.ToString().Split(',');
                this.rt6.Value = rt6value[0].ToString();
                this.rt66.Value = rt6value[1].ToString();


                string[] rt7value = ratioid[0].Ratio7.ToString().Split(',');
                this.rt7.Value = rt7value[0].ToString();
                this.rt77.Value = rt7value[1].ToString();

                string[] rt8value = ratioid[0].Ratio8.ToString().Split(',');
                this.rt8.Value = rt8value[0].ToString();
                this.rt88.Value = rt8value[1].ToString();

                string[] rt9value = ratioid[0].Ratio9.ToString().Split(',');
                this.rt9.Value = rt9value[0].ToString();
                this.rt99.Value = rt9value[1].ToString();

                string[] rt10value = ratioid[0].Ratio10.ToString().Split(',');
                this.rt10.Value = rt10value[0].ToString();
                this.rt1010.Value = rt10value[1].ToString();
            }
        }


        private void ratioAdd()
        {
            EtNet_Models.Ratio ratio = new Ratio();

            ratio.Rationame = DateTime.Now.ToShortDateString() + "提成比例";
            ratio.Ratio1 = (this.rt1.Value.ToString() + "," + this.rt11.Value.ToString()).ToString();
            ratio.Ratio2 = (this.rt2.Value.ToString() + "," + this.rt22.Value.ToString()).ToString();
            ratio.Ratio3 = (this.rt3.Value.ToString() + "," + this.rt33.Value.ToString()).ToString();
            ratio.Ratio4 = (this.rt4.Value.ToString() + "," + this.rt44.Value.ToString()).ToString();
            ratio.Ratio5 = (this.rt5.Value.ToString() + "," + this.rt55.Value.ToString()).ToString();
            ratio.Ratio6 = (this.rt6.Value.ToString() + "," + this.rt66.Value.ToString()).ToString();
            ratio.Ratio7 = (this.rt7.Value.ToString() + "," + this.rt77.Value.ToString()).ToString();
            ratio.Ratio8 = (this.rt8.Value.ToString() + "," + this.rt88.Value.ToString()).ToString();
            ratio.Ratio9 = (this.rt9.Value.ToString() + "," + this.rt99.Value.ToString()).ToString();
            ratio.Ratio10 = (this.rt10.Value.ToString() + "," + this.rt1010.Value.ToString()).ToString();

            int count = RatioManager.addRatio(ratio);
            if (count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('添加成功！');location.href='../SystemSetting/parameter.aspx'", true);
            }
            else
            {

            }
        }


        private void update()
        {
            EtNet_Models.Ratio ratio = new Ratio();
            IList<EtNet_Models.Ratio> ratioid = RatioManager.getRatioTop1();
            ratio.Id = ratioid[0].Id;
            ratio.Rationame = DateTime.Now.ToShortDateString() + "提成比例";
            ratio.Ratio1 = (this.rt1.Value.ToString() + "," + this.rt11.Value.ToString()).ToString();
            ratio.Ratio2 = (this.rt2.Value.ToString() + "," + this.rt22.Value.ToString()).ToString();
            ratio.Ratio3 = (this.rt3.Value.ToString() + "," + this.rt33.Value.ToString()).ToString();
            ratio.Ratio4 = (this.rt4.Value.ToString() + "," + this.rt44.Value.ToString()).ToString();
            ratio.Ratio5 = (this.rt5.Value.ToString() + "," + this.rt55.Value.ToString()).ToString();
            ratio.Ratio6 = (this.rt6.Value.ToString() + "," + this.rt66.Value.ToString()).ToString();
            ratio.Ratio7 = (this.rt7.Value.ToString() + "," + this.rt77.Value.ToString()).ToString();
            ratio.Ratio8 = (this.rt8.Value.ToString() + "," + this.rt88.Value.ToString()).ToString();
            ratio.Ratio9 = (this.rt9.Value.ToString() + "," + this.rt99.Value.ToString()).ToString();
            ratio.Ratio10 = (this.rt10.Value.ToString() + "," + this.rt1010.Value.ToString()).ToString();

            int count = RatioManager.updateRatio(ratio);
            if (count > 0)
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('更新成功！');location.href='../SystemSetting/parameter.aspx'", true);
            }
            else
            {

            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnadd_Click(object sender, ImageClickEventArgs e)
        {
            IList<EtNet_Models.Ratio> ratio = RatioManager.getRatioAll();
            if (ratio.Count <= 0)
            {

                ratioAdd();
            }
            else
            {
                update();
            }
        }
    }
}