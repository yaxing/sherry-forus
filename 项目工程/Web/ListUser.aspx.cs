////编写者：李开林
////日  期：2009-12-4
////功  能：用户列表显示

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using DAL;
using Entity;

public partial class ListUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindSource();
    }

    private void BindSource()
    {
        IList <UserInfo> userList = new List<UserInfo>();
        UserInfoDAL userInfoDAL = new UserInfoDAL();
        userInfoDAL.ShowUserInfo(ref userList);

        DataTable dt = new DataTable("UserList");
        DataColumn dc = new DataColumn("userID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("UserRealName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        //dc = new DataColumn("userName", System.Type.GetType("System.String"));
        //dt.Columns.Add(dc);
        //dc = new DataColumn("userName", System.Type.GetType("System.String"));
        //dt.Columns.Add(dc);
        //dc = new DataColumn("userName", System.Type.GetType("System.String"));
        //dt.Columns.Add(dc);
        //dc = new DataColumn("userName", System.Type.GetType("System.String"));
        //dt.Columns.Add(dc);
        //dc = new DataColumn("userName", System.Type.GetType("System.String"));
        //dt.Columns.Add(dc);
        //dc = new DataColumn("userName", System.Type.GetType("System.String"));
        //dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (UserInfo userInfo in userList)
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
}
