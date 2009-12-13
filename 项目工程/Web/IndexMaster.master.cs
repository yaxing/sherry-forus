////编写者：陈亚星，张翼鹏
////日  期：2009-11-28
////功  能：母版页
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

public partial class IndexMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Sherry化妆品有限公司";
    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        
    }
    protected void imgbCart_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
    protected void lbtCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("CartView.aspx");
    }
}
