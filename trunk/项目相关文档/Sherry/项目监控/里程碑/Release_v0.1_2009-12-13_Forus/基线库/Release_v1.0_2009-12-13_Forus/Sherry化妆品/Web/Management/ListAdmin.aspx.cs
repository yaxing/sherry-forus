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

public partial class Management_ListAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListBind();
        }
    }
    protected void ListBind()
    {
        IList<AdminListInfo> adminList = new List<AdminListInfo>();
        AdminInfoBLL adminInfoBLL = new AdminInfoBLL();
        adminInfoBLL.ShowAdminInfo(ref adminList);

        DataTable dt = new DataTable("AdminList");
        DataColumn dc = new DataColumn("AdminID", System.Type.GetType("System.Guid"));
        dt.Columns.Add(dc);
        dc = new DataColumn("AdminName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("AdminType", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("State", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("AddTime", System.Type.GetType("System.DateTime"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (AdminListInfo adminInfo in adminList)
        {
            Type type = adminInfo.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(adminInfo, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }

        this.AdminList.DataSource = dt;
        this.AdminList.DataBind();
    }
    protected void AdminList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        this.AdminList.EditIndex = e.NewEditIndex;
        Label lblAdminType = (Label)this.AdminList.Rows[e.NewEditIndex].Cells[1].FindControl("lblAdminType");
        if (lblAdminType.Text == "��������Ա")
        {
            Response.Write("<script language='javascript'>alert('���������������Ա����');</script>");
            return;
        }
        ListBind();
    }
    protected void AdminList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DropDownList ddlAdminType = (DropDownList)this.AdminList.Rows[e.RowIndex].Cells[1].FindControl("ddlAdminType");
        AdminInfo admin = new AdminInfo();
        admin.AdminID = (Guid)this.AdminList.DataKeys[e.RowIndex].Value;
        admin.AdminLv = Convert.ToInt32(ddlAdminType.SelectedValue);
        AdminInfoBLL adminBLL = new AdminInfoBLL();
        if (adminBLL.ModiAdminLv(admin))
        {
            Response.Write("<script language='javascript'>alert('�޸ĳɹ�������Ա" + this.AdminList.Rows[e.RowIndex].Cells[0].Text + "��ǰ����Ϊ:" + ddlAdminType.SelectedItem.Text + "');</script>");
            this.AdminList.EditIndex = -1;
            ListBind();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('����ʧ�ܣ������Ի���ϵ����Ա��');</script>");
        }
    }
    protected void AdminList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        this.AdminList.EditIndex = -1;
        ListBind();
    }
    protected void AdminList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label lblAdminType = (Label)this.AdminList.Rows[e.RowIndex].Cells[1].FindControl("lblAdminType");
        if (lblAdminType.Text == "��������Ա")
        {
            Response.Write("<script language='javascript'>alert('��ֹɾ����������Ա');</script>");
            return;
        }
        DataKey key = this.AdminList.DataKeys[e.RowIndex];
        Guid adminID = (Guid)key[0];
        AdminInfoBLL adminInfoBLL = new AdminInfoBLL();

        if (adminInfoBLL.DeleteAdmin(adminID))
        {
            Response.Write("<script language='javascript'>alert('����Ա" + this.AdminList.Rows[e.RowIndex].Cells[0].Text + "ɾ����ɡ�');</script>");
            ListBind();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('����Ϊ��ɣ������Ի���ϵ����Ա��');</script>");
        }
    }
}
