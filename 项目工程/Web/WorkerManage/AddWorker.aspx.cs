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

public partial class WorkerManage_AddWorker : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!DDLLoader())
        {
            Response.Write("<script language='javascript'>alert('数据载入失败，请重试或联系管理员。');</script>");
            return;
        }
    }
    Boolean DDLLoader()
    {
        DataTable dt = new DataTable("WorkerManager");
        DataColumn dc = new DataColumn("workerID", System.Type.GetType("System.Guid"));
        dt.Columns.Add(dc);
        dc = new DataColumn("workerNS", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        
        //foreach (AdminListInfo adminInfo in adminList)
        //{
        //    Type type = adminInfo.GetType();
        //    dr = dt.NewRow();
        //    for (int i = 0; i < dcc.Count; i++)
        //    {
        //        string colName = dcc[i].ColumnName;

        //        PropertyInfo pInfo = type.GetProperty(colName);
        //        if (pInfo != null)
        //        {
        //            object objInfo = pInfo.GetValue(adminInfo, null);
        //            if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
        //                dr[colName] = objInfo;
        //        }

        //    }
        //    dt.Rows.Add(dr);
        //}
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
        newWorker.ShopID = 1;
        newWorker.ManageID = newWorker.WorkerID;
        newWorker.WorkerState = 0;

        WorkerInfoBLL workerInfoBLL = new WorkerInfoBLL();
        workerInfoBLL.AddWorkerInfo(newWorker);
    }
}
