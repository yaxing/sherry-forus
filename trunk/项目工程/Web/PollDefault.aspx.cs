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

public partial class PollDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PlaceHolder1.Controls.Add(new BLL.Poll());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(((BLL.Poll)PlaceHolder1.Controls[0]).OptionName);
    }
}
