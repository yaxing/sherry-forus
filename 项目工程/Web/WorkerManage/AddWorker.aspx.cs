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

public partial class WorkerManage_AddWorker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!DDLLoader())
            {
                Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');location.href='bgIndex.aspx';</script>");
            }
            DropDownList DDLShop = (DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DDLShop");
            if (!DDLManagerLoad(Convert.ToInt32(DDLShop.SelectedValue)))
            {
                Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');location.href='bgIndex.aspx';</script>");
            }
        }
        
    }

    protected Boolean DDLManagerLoad(int shopIndex)
    {
        IList<WorkerInfo> allManager = new List<WorkerInfo>();
        WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
        ShopInfo shopInfo = new ShopInfo();
        shopInfo.ShopID = shopIndex;
        if (workerInfoBLL.ShowComNetUser(ref allManager,shopInfo) == -1)
        {
            Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');</script>");
            return false;
        }

        DropDownList DDLManager = (DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("ddlManager");

        DataTable dt = new DataTable("workerList");
        DataColumn dc = new DataColumn("WorkerID", System.Type.GetType("System.Guid"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerNum", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("ShopID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerRealName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("ManagerID", System.Type.GetType("System.Guid"));
        dt.Columns.Add(dc);
        dc = new DataColumn("EmailAdd", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("PhoneNum", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerLv", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("WorkerState", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (WorkerInfo workerInfo in allManager)
        {
            Type type = workerInfo.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(workerInfo, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }

        if (dt.Rows.Count <= 0)
        {
            dr = dt.NewRow();
            dr[0] = "00000000-0000-0000-0000-000000000000";
            dr[3] = "无";
            dt.Rows.Add(dr);
        }
        DDLManager.DataSource = dt;
        DDLManager.DataValueField = dt.Columns[0].ToString();
        DDLManager.DataTextField = dt.Columns[3].ToString();
        DDLManager.DataBind();

        return true;
    }

    protected Boolean DDLLoader()
    {
        IList<ShopInfo> allShop = new List<ShopInfo>();
        ShopInfoBLL shopInfoBLL = new ShopInfoBLL();

        if (shopInfoBLL.DisplayAllShop(ref allShop) == -1)
        {
            Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');</script>");
            return false;
        }

        DropDownList DDLShop = (DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DDLShop");

        DataTable dt = new DataTable("ShopList");
        DataColumn dc = new DataColumn("ShopID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("ShopName", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (ShopInfo shopInfo in allShop)
        {
            Type type = shopInfo.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(shopInfo, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }
        DDLShop.DataSource = dt;
        DDLShop.DataValueField = dt.Columns[0].ToString();
        DDLShop.DataTextField = dt.Columns[1].ToString();
        DDLShop.DataBind();

        return true;
    }
    protected void CreateUserWizard_CreatedUser(object sender, EventArgs e)
    {
        WorkerInfo newWorker = new WorkerInfo();
        MembershipUser mWorker = Membership.FindUsersByName(CreateUserWizard.UserName)[CreateUserWizard.UserName];

        newWorker.WorkerID = (Guid)mWorker.ProviderUserKey;
        newWorker.WorkerRealName = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtRealName")).Text;
        newWorker.WorkerNum = Convert.ToInt32(((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtWorkerNum")).Text);
        newWorker.EmailAdd = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("Email")).Text;
        newWorker.PhoneNum = ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("txtPhoneNum")).Text;
        newWorker.WorkerLv = Convert.ToInt32(((DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DDLWorkerLv")).SelectedValue);
        newWorker.ShopID = Convert.ToInt32(((DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DDLShop")).SelectedValue);
        if (newWorker.WorkerLv == 1)
        {
            newWorker.ManageID = newWorker.WorkerID;
        }
        else
        {
            if (((DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("ddlManager")).SelectedValue == "00000000-0000-0000-0000-000000000000")
            {
                Membership.DeleteUser(mWorker.UserName,true);
                Response.Write("<script language='javascript'>alert('当前店铺无负责人，请先添加负责人。');location.href='AddWorker.aspx';</script>");
                return;
            }
            String manID = ((DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("ddlManager")).SelectedValue;
            newWorker.ManageID = new Guid(manID);
        }
        newWorker.WorkerState = 0;

        WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
        if(!workerInfoBLL.AddWorkerInfo(newWorker))
        {
            Response.Write("<script language='javascript'>alert('用户数据注册失败。请重试或联系管理员');location.href='../Management/bgIndex.aspx'</script>");
            return;
        }
        else
        {
            Response.Write("<script language='javascript'>alert('添加工作人员成功');location.href='AddWorker.aspx'</script>");
        }
    }
    protected void DDLShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        int shopID = Convert.ToInt32(((DropDownList)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("DDLShop")).SelectedValue);
        DDLManagerLoad(shopID);
    }
}
