using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using BLL;
using Entity;

public partial class CSManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataListBind();
        }
    }

    private bool DataListBind()
    {
        IList<Message> messageList = new List<Message>();
        ClientServiceBLL clientService = new ClientServiceBLL(); ;
        clientService.ShowTopN(ref messageList, 10, false);

        DataTable dt = new DataTable("Message");
        DataColumn dc = new DataColumn("MessageID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Topic", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Messages", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (Message newMessage in messageList)
        {
            Type type = newMessage.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(newMessage, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }
        dataList.DataSource = dt;
        dataList.DataBind();
        return true;
    }

    public void EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {
        
        int messageID = Int32.Parse(((Label)e.Item.FindControl("MessageID")).Text);
        string newReply = ((TextBox)e.Item.FindControl("Reply")).Text;

        ClientServiceBLL clientService = new ClientServiceBLL();
        clientService.AddReply(messageID, newReply);

        ((TextBox)e.Item.FindControl("Reply")).Text = "";
        
    }
    public void DeleteCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
    {

        int messageID = Int32.Parse(((Label)e.Item.FindControl("MessageID")).Text);

        ClientServiceBLL clientService = new ClientServiceBLL();
        if (clientService.DeleteMessage(messageID))
        {
            DataListBind();
            this.RegisterStartupScript("msg", "<script>alert('ÐÅÏ¢ÒÑÉ¾³ý£¡')</script>");
        }

    }
}
