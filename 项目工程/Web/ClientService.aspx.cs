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


public partial class ClientService : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            IList<Message> messageList = new List<Message>();
            ClientServiceBLL clientService = new ClientServiceBLL(); ;
            if (clientService.ShowTopN(ref messageList, 20, true))
            {

                DataTable dt = new DataTable("Message");
                DataColumn dc = new DataColumn("Topic", System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Messages", System.Type.GetType("System.String"));
                dt.Columns.Add(dc);
                dc = new DataColumn("Reply", System.Type.GetType("System.String"));
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
            }
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        Message message = new Message();
        if (Topic.Text == "")
        {
            this.RegisterStartupScript("msg", "<script>alert('标题不能为空！')</script>");
        }
        else if (Message.Text == "")
        {
            this.RegisterStartupScript("msg", "<script>alert('内容不能为空！')</script>");
        }
        else
        {
            message.Topic = Topic.Text;
            message.Messages = Message.Text;
            ClientServiceBLL clientService = new ClientServiceBLL();
            clientService.AddMessage(message);

            this.RegisterStartupScript("msg", "<script>alert('消息发布成功，请等待管理员解答')</script>");

            Topic.Text = "";
            Message.Text = "";
        }
    }
}
