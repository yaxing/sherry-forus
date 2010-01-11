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

public partial class ModiWorker : System.Web.UI.Page
{
    WorkerInfo worker = new WorkerInfo();
    WorkerInfoBLL workerBLL = new WorkerInfoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!User.IsInRole("工作人员"))
        {
            Response.Write("<script language='javascript'>alert('您不属于此用户组。');location.href='../Management/bgIndex.aspx';</script>");
        }
        if (!this.IsPostBack)
        {
            int flag = 0;
            String workerID = Request["workID"];
            if (workerID == null || workerID == "")
            {
                MembershipUser tmpUser = Membership.GetUser(User.Identity.Name);
                workerID = tmpUser.ProviderUserKey.ToString();
                flag = 1;
            }
            this.worker.WorkerID = new Guid(workerID);
            if (!workerBLL.SrchWorkerInfo(ref worker))
            {
                Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');location.href='../Management/bgIndex.aspx';</script>");
                return;
            }
            else
            {
                MembershipUser tempUser = Membership.GetUser(this.worker.WorkerID);
                this.lblWorkerName.Text = tempUser.UserName;
                this.lblRealName.Text = worker.WorkerRealName;
                this.lblWorkerNum.Text = worker.WorkerNum.ToString();
                this.DDLWorkerLv.SelectedValue = worker.WorkerLv.ToString();
                this.txtEmail.Text = worker.EmailAdd;
                this.txtPhone.Text = worker.PhoneNum;
                switch (worker.WorkerState)
                {
                    case 0:
                        this.lblWorkerState.Text = "空闲";
                	    break;
                    default:
                        this.lblWorkerState.Text = worker.WorkerState.ToString() + "份订单处理中";
                        break;
                }
                
                switch (tempUser.IsApproved)
                {
                    case true:
                        this.lblAccountState.Text = "启用";
                        break;
                    case false:
                        this.lblAccountState.Text = "冻结";
                        break;
                }
            }
            if (!DDLLoader())
            {
                Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');location.href='../Management/bgIndex.aspx';</script>");
                return;
            }
            if (!DDLManagerLoad(Convert.ToInt32(this.DDLShop.SelectedValue)))
            {
                Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');location.href='../Management/bgIndex.aspx';</script>");
                return;
            }
            if (flag == 0)
            {
                this.PanelPwd.Visible = false;
                this.PanelButton.Visible = false;
            }
        }
        
    }

    protected Boolean DDLLoader()
    {
        IList<ShopInfo> allShop = new List<ShopInfo>();
        ShopInfoBLL shopInfoBLL = new ShopInfoBLL();

        if (shopInfoBLL.DisplayAllShop(ref allShop) == -1)
        {
            Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');location.href='bgIndex.aspx';</script>");
            return false;
        }

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
        this.DDLShop.DataSource = dt;
        this.DDLShop.DataValueField = dt.Columns[0].ToString();
        this.DDLShop.DataTextField = dt.Columns[1].ToString();
        this.DDLShop.DataBind();
        this.DDLShop.SelectedValue = worker.ShopID.ToString();

        return true;
    }

    protected Boolean DDLManagerLoad(int shopIndex)
    {
        IList<WorkerInfo> allManager = new List<WorkerInfo>();
        WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
        ShopInfo shopInfo = new ShopInfo();
        shopInfo.ShopID = shopIndex;
        if (workerInfoBLL.ShowComNetUser(ref allManager, shopInfo) == -1)
        {
            Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');</script>");
            return false;
        }

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
        this.DDLManager.DataSource = dt;
        this.DDLManager.DataValueField = dt.Columns[0].ToString();
        this.DDLManager.DataTextField = dt.Columns[3].ToString();
        this.DDLManager.DataBind();
        if (shopIndex == worker.ShopID)
            this.DDLManager.SelectedValue = worker.ManageID.ToString();

        return true;
    }
    protected void DDLShop_SelectedIndexChanged(object sender, EventArgs e)
    {
        int shopID = Convert.ToInt32(this.DDLShop.SelectedValue);
        DDLManagerLoad(shopID);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListWorker.aspx");
    }
    protected void btnCommit_Click(object sender, EventArgs e)
    {
        String workerID = Request["workID"];
        if (workerID == null || workerID == "")
        {
            MembershipUser tmpUser = Membership.GetUser(User.Identity.Name);
            workerID = tmpUser.ProviderUserKey.ToString();
            this.worker.WorkerID = new Guid(workerID);
        }
        else
            this.worker.WorkerID = new Guid(workerID);
        this.worker.ShopID = Convert.ToInt32(this.DDLShop.SelectedValue);
        this.worker.WorkerLv = Convert.ToInt32(this.DDLWorkerLv.SelectedValue);
        if (worker.WorkerLv == 0)
        {
            this.worker.ManageID = new Guid(this.DDLManager.SelectedValue);
        }
        else
        {
            this.worker.ManageID = this.worker.WorkerID;
        }
        this.worker.EmailAdd = this.txtEmail.Text;
        this.worker.PhoneNum = this.txtPhone.Text;

        if (workerBLL.ModiWorkerInfo(this.worker))
        {
            Response.Write("<script language='javascript'>alert('用户" + worker.WorkerName + "修改成功。');location.href='ListWorker.aspx';</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('信息修改失败,请确认信息正确（邮箱可能已被使用）后重试或联系管理员。');location.href='ListWorker.aspx';</script>");
        }
    }
    protected void btnPassword_Click(object sender, EventArgs e)
    {
        MembershipUser oldUser = Membership.GetUser(User.Identity.Name);
        if (!oldUser.ChangePassword(this.txtPassword.Text, this.txtNewPwd.Text))
        {
            Response.Write("<script language='javascript'>alert('您的密码输入错误。');location.href='ModiWorker.aspx';</script>");
        }
        else
        {
            Response.Write("<script language='javascript'>alert('密码修改成功。');location.href='ModiWorker.aspx';</script>");
        }
    }
}
