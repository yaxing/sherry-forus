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

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            HotGoods.DataSource = GoodsInfoBLL.LatestGoods(5, true);
            HotGoods.DataBind();
            NewGoods.DataSource = GoodsInfoBLL.LatestGoods(3);
            NewGoods.DataBind();
        }
        catch
        {
            return;
        }
    }
}
