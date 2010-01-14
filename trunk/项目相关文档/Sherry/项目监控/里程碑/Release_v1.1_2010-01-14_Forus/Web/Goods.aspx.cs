using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Entity;

public partial class Goods : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int category = 0;
        try
        {
            category = Convert.ToInt32(Request.QueryString["Category"]);
            if (category < 0 || category >= 11)
            {
                Response.Redirect("Goods.aspx");
            }
        }
        catch
        {
            Response.Redirect("Index.aspx");
        }

        SubTitle.Text = Category.fulName[category];
        SameCategory.DataSource = GoodsInfoBLL.FindGoods(category);
        SameCategory.DataBind();
    }
}
