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
using Entity;

public partial class Management_left : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (User.IsInRole("管理员"))
            {
                AdminInfo admin = new AdminInfo();
                AdminInfoBLL adminBLL = new AdminInfoBLL();

                if (!adminBLL.SrchAdminInfoByUserName(ref admin,User.Identity.Name))
                {
                    Response.Write("<script language='javascript'>alert('无法获取数据，请重试或联系管理员');top.location='../Index.aspx';</script>");
                    return;
                }

                if (admin.AdminLv == 0)
                {
                    //不对商品管理员显示
                    this.PanelAdmin.Visible = false;
                    this.PanelLogistic.Visible = false;
                    this.PanelService.Visible = false;
                    this.PanelWorker.Visible = false;
                    this.PanelCallCenter.Visible = false;
                    this.MarketDecisonPanel.Visible = false;
                }
                if (admin.AdminLv == 1)
                {
                    //不对市场管理员显示
                    this.PanelWorker.Visible = false;
                    this.PanelAdmin.Visible = false;
                }
                if (admin.AdminLv == 2)
                {
                    //不对人事管理员显示
                    this.PanelGoods.Visible = false;
                    this.PanelService.Visible = false;
                    this.PanelCallCenter.Visible = false;
                    this.MarketDecisonPanel.Visible = false;
                    this.PanelLogistic.Visible = false;
                }

                this.ltlModiSelf.Text = "<a href='AdminManage/ModiAdminSelf.aspx' target='mainFrame'>修改个人信息</a>";
            }
            else if (User.IsInRole("工作人员"))
            {
                //不对所有工作人员显示
                this.PanelAdmin.Visible = false;
                this.PanelGoods.Visible = false;
                this.PanelService.Visible = false;
                this.MarketDecisonPanel.Visible = false;
                
                WorkerInfo worker = new WorkerInfo();
                worker.WorkerID = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
                WorkerInfoBLL workerBLL = new WorkerInfoBLL();
                
                if (!workerBLL.SrchWorkerInfo(ref worker))
                {
                    Response.Write("<script language='javascript'>alert('无法获取数据，请重试或联系管理员');top.location='../Index.aspx';</script>");
                    return;
                }
                if (worker.WorkerLv == 0)
                {
                    //不对普通工作人员显示
                    this.PanelLogistic.Visible = false;
                    this.PanelCallCenter.Visible = false;
                }
                this.ltlModiSelf.Text = "<a href='WorkerManage/ModiWorker.aspx' target='mainFrame'>修改个人信息</a>";
            }
            else
            {
                Response.Write("<script language='javascript'>top.location='BgLogin.aspx';</script>");
            }
        }
    }
    protected void LBLogout_Click(object sender, EventArgs e)
    {
        Response.Write("<script language='javascript'>top.location='BgLogin.aspx';</script>");
    }
}
