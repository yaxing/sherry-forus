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

public partial class WorkerManage_ListWorker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!ListBind())
        {
            Response.Write("<script language='javascript'>alert('��������ʧ�ܣ������Ի���ϵ����Ա��');location.href='../Management/bgIndex.aspx'</script>");
        }
    }

    protected Boolean ListBind()
    {
        IList<WorkerInfo> workerList = new List<WorkerInfo>();
        WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
        if (User.IsInRole("����Ա"))
        {
            if(workerInfoBLL.ShowAllWorker(ref workerList,User.Identity.Name,"����Ա") == -1)
            {
                return false;
            }
        }
        else
        {
            if (workerInfoBLL.ShowAllWorker(ref workerList, User.Identity.Name,"������Ա") == -1)
            {
                return false;
            }
        }
        

        DataTable dt = new DataTable("WorkerList");
        DataColumn dc = new DataColumn("WorkerID", System.Type.GetType("System.Guid"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerNum", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("ShopID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerRealName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("ManageID", System.Type.GetType("System.Guid"));
        dt.Columns.Add(dc);
        dc = new DataColumn("EmailAdd", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("PhoneNum", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerLv", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerState", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("ShopName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("AddTime", System.Type.GetType("System.DateTime"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerType", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerWorkStat", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("AccountState", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;

        foreach (WorkerInfo oneWorker in workerList)
        {
            Type type = oneWorker.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(oneWorker, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }

        this.WorkerList.DataSource = dt;
        this.WorkerList.DataBind();
        return true;
    }
    protected void WorkerList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataKey key = this.WorkerList.DataKeys[e.RowIndex];
        Guid myID = (Guid)key[0];
        
        if (key[1].ToString() == "1" && User.IsInRole("������Ա"))
        {
            Response.Write("<script language='javascript'>alert('�����ܶ��Ḻ����');location.href='ListWorker.aspx'</script>");
            return;
        }

        if (this.WorkerList.Rows[e.RowIndex].Cells[4].Text != "����" )
        {
            Response.Write("<script language='javascript'>alert('������Ա�ж�����δ���');location.href='ListWorker.aspx'</script>");
            return;
        }

        UserInfoBLL workerModi = new UserInfoBLL();
        if (workerModi.ModiUserLv(myID))
        {
            Response.Write("<script language='javascript'>alert('�û�" + this.WorkerList.Rows[e.RowIndex].Cells[0].Text + "�ʺ�״̬�����ɹ���');location.href='ListWorker.aspx'</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('�ʺ�״̬���ʧ�ܡ�');location.href='ListWorker.aspx'</script>");
        }
    }
    protected void WorkerList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataKey key = this.WorkerList.DataKeys[e.NewEditIndex];
        string workID = key[0].ToString();

        Response.Redirect("ModiWorker.aspx?workID="+workID);
    }
    protected void WorkerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.WorkerList.PageIndex = e.NewPageIndex;
        ListBind();
    }
}
