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
            if (User.IsInRole("����Ա"))
            {
                AdminInfo admin = new AdminInfo();
                AdminInfoBLL adminBLL = new AdminInfoBLL();

                if (!adminBLL.SrchAdminInfoByUserName(ref admin,User.Identity.Name))
                {
                    Response.Write("<script language='javascript'>alert('�޷���ȡ���ݣ������Ի���ϵ����Ա');top.location='../Index.aspx';</script>");
                    return;
                }

                if (admin.AdminLv == 0)
                {
                    //������Ʒ����Ա��ʾ
                    this.PanelAdmin.Visible = false;
                    this.PanelLogistic.Visible = false;
                    this.PanelService.Visible = false;
                    this.PanelWorker.Visible = false;
                    this.PanelCallCenter.Visible = false;
                    this.MarketDecisonPanel.Visible = false;
                }
                if (admin.AdminLv == 1)
                {
                    //�����г�����Ա��ʾ
                    this.PanelWorker.Visible = false;
                    this.PanelAdmin.Visible = false;
                }
                if (admin.AdminLv == 2)
                {
                    //�������¹���Ա��ʾ
                    this.PanelGoods.Visible = false;
                    this.PanelService.Visible = false;
                    this.PanelCallCenter.Visible = false;
                    this.MarketDecisonPanel.Visible = false;
                    this.PanelLogistic.Visible = false;
                }

                this.ltlModiSelf.Text = "<a href='AdminManage/ModiAdminSelf.aspx' target='mainFrame'>�޸ĸ�����Ϣ</a>";
            }
            else if (User.IsInRole("������Ա"))
            {
                //�������й�����Ա��ʾ
                this.PanelAdmin.Visible = false;
                this.PanelGoods.Visible = false;
                this.PanelService.Visible = false;
                this.MarketDecisonPanel.Visible = false;
                
                WorkerInfo worker = new WorkerInfo();
                worker.WorkerID = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
                WorkerInfoBLL workerBLL = new WorkerInfoBLL();
                
                if (!workerBLL.SrchWorkerInfo(ref worker))
                {
                    Response.Write("<script language='javascript'>alert('�޷���ȡ���ݣ������Ի���ϵ����Ա');top.location='../Index.aspx';</script>");
                    return;
                }
                if (worker.WorkerLv == 0)
                {
                    //������ͨ������Ա��ʾ
                    this.PanelLogistic.Visible = false;
                    this.PanelCallCenter.Visible = false;
                }
                this.ltlModiSelf.Text = "<a href='WorkerManage/ModiWorker.aspx' target='mainFrame'>�޸ĸ�����Ϣ</a>";
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
