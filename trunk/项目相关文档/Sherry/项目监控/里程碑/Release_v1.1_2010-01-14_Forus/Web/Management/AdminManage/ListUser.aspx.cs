////编写者：李开林、张翼鹏
////日  期：2009-12-4
////功  能：用户列表显示

using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using BLL;
using Entity;

public partial class ListUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindSource();
    }

    private void BindSource()
    {
        IList <UserListInfo> userList = new List<UserListInfo>();
        UserInfoBLL userInfoBLL = new UserInfoBLL();
        userInfoBLL.ShowUserInfo(ref userList);

        DataTable dt = new DataTable("UserList");
        DataColumn dc = new DataColumn("UserID", System.Type.GetType("System.Guid"));
        dt.Columns.Add(dc);
        dc = new DataColumn("UserName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Score", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Level", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("State", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("RegTime", System.Type.GetType("System.DateTime"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (UserListInfo userInfo in userList)
        {
            Type type = userInfo.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(userInfo, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }

        UserList.DataSource = dt;
        UserList.DataBind();
    }
    protected void UserList_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        DataKey key = this.UserList.DataKeys[e.RowIndex];
        Guid userID = (Guid)key[0];
        UserInfoBLL userInfoBLL = new UserInfoBLL();

        if (userInfoBLL.DeleteUserInfo(userID))
        {
            Response.Write("<script language='javascript'>alert('用户" + this.UserList.Rows[e.RowIndex].Cells[0].Text + "帐号状态调整成功。');</script>");
            BindSource();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('帐号状态变更失败。');</script>");
        }
    }
    protected void UserList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DataKey key = this.UserList.DataKeys[e.NewEditIndex];
        Guid userID = (Guid)key[0];
        UserInfoBLL userLvChange = new UserInfoBLL();

        if (userLvChange.ModiUserLv(userID))
        {
            Response.Write("<script language='javascript'>alert('用户" + this.UserList.Rows[e.NewEditIndex].Cells[0].Text + "帐号状态调整成功。');</script>");
            BindSource();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('帐号状态变更失败。');</script>");
        }
    }
    protected void UserList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.UserList.PageIndex = e.NewPageIndex;
        BindSource();
    }
}
