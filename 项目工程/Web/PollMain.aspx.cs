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

public partial class PollMain : System.Web.UI.Page
{
    const int PAGE_SIZE = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["currentPage"] = "0";
            PollInfoBLL mainPollNum = new PollInfoBLL();
            int items = mainPollNum.NumOfMainPoll();
            int pageLength = items % PAGE_SIZE == 0 ? items / PAGE_SIZE : (items / PAGE_SIZE + 1);
            ViewState["PageLength"] = pageLength.ToString();
        }

        int currentPage = Convert.ToInt32(ViewState["currentPage"]);
        
        bindRepeater(currentPage);

        
    }

    private void bindRepeater(int currentPage)
    {
        IList<MainPoll> ds = new List<MainPoll>();
        PollInfoBLL mainPoll = new PollInfoBLL();
        mainPoll.GetPageShow(ref ds, currentPage);

        DataTable dt = new DataTable("MainPoll");
        DataColumn dc = new DataColumn("MainPollID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Topic", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("SelectNum", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("SingleMode", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("ColMode", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (MainPoll newMainPoll in ds)
        {
            Type type = newMainPoll.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(newMainPoll, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }

        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }

    ///// <summary>
    ///// 获取sql语句，因为第一页和其余页的sql语句是不同的
    ///// </summary>
    ///// <param name="currentPage">当前页</param>
    ///// <returns></returns>
    //private string getSql(int currentPage)
    //{
    //    if (currentPage == 0)
    //    {
    //        return "select top " + PAGE_SIZE + " * from [voteTitle]";
    //    }
    //    else
    //    {
    //        return "select top " + PAGE_SIZE + " * from [voteTitle] where [id] not in (select top " +
    //            PAGE_SIZE * currentPage + " [id] from [voteTitle])";
    //    }
    //}

    #region repeater的一些事件
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        PlaceHolder ph = e.Item.FindControl("phOptions") as PlaceHolder;
        if (ph == null)
        {
            return;
        }

        string parentId = ((Label)e.Item.FindControl("lbId")).Text;
        //OleDbDataReader reader = AccessDBUtil.ExecuteReader("select * from [voteOption] where [parentId] = " + parentId);

        IList<SubPoll> subPollList = new List<SubPoll>();
        PollInfoBLL subPoll = new PollInfoBLL();
        MainPoll mainPoll = new MainPoll();
        mainPoll.MainPollID = Int32.Parse(parentId);
        subPoll.SelectSubPollByID(ref subPollList, mainPoll);

        DataTable dt = new DataTable("SubPoll");
        DataColumn dc = new DataColumn("SubPollID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("MainPollID", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Description", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Num", System.Type.GetType("System.Int32"));
        dt.Columns.Add(dc);
        dc = new DataColumn("Color", System.Type.GetType("System.String"));
        dt.Columns.Add(dc);

        DataRow dr = null;
        DataColumnCollection dcc = dt.Columns;
        foreach (SubPoll newSubPoll in subPollList)
        {
            Type type = newSubPoll.GetType();
            dr = dt.NewRow();
            for (int i = 0; i < dcc.Count; i++)
            {
                string colName = dcc[i].ColumnName;

                PropertyInfo pInfo = type.GetProperty(colName);
                if (pInfo != null)
                {
                    object objInfo = pInfo.GetValue(newSubPoll, null);
                    if (objInfo != null && (!Convert.IsDBNull(objInfo)) && objInfo.ToString() != null)
                        dr[colName] = objInfo;
                }

            }
            dt.Rows.Add(dr);
        }

        if (bool.Parse(((Label)e.Item.FindControl("selMode")).Text))
        {
            RadioButtonList rbl = new RadioButtonList();
            rbl.DataTextField = "description";
            rbl.DataValueField = "subPollID";
            rbl.DataSource = dt;
            rbl.DataBind();
            ph.Controls.Add(rbl);
        }
        else
        {
            CheckBoxList cbl = new CheckBoxList();
            cbl.DataTextField = "description";
            cbl.DataValueField = "subPollID";
            cbl.DataSource = dt;
            cbl.DataBind();
            ph.Controls.Add(cbl);
        }

    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "poll")
        {
            PlaceHolder ph = e.Item.FindControl("phOptions") as PlaceHolder;
            Control option = ph.Controls[0];
            if (option is CheckBoxList)
            {
                CheckBoxList cbl = (CheckBoxList)option;
                foreach (ListItem li in cbl.Items)
                {
                    if (li.Selected)
                    {
                        SubPoll subPoll = new SubPoll();
                        PollInfoBLL update = new PollInfoBLL();
                        if (li.Selected)
                        {
                            subPoll.SubPollID = Int32.Parse(li.Value.ToString());
                            update.UpdatePollNum(subPoll);
                        }
                        //AccessDBUtil.ExecuteNonQuery("update [voteOption] set [ballots] = [ballots] + 1 where [id] = " + li.Value);
                    }
                }

            }
            else if (option is RadioButtonList)
            {
                RadioButtonList rbl = option as RadioButtonList;
                SubPoll subPoll = new SubPoll();
                PollInfoBLL update = new PollInfoBLL();
                if (rbl.SelectedValue.Length > 0)
                {
                    subPoll.SubPollID = Int32.Parse(rbl.SelectedValue.ToString());
                    update.UpdatePollNum(subPoll);
                }
                //AccessDBUtil.ExecuteNonQuery("update [voteOption] set [ballots] = [ballots] + 1 where [id] = " + rbl.SelectedValue);
            }
            Response.Redirect("ShowPoll.aspx?id=" + e.CommandArgument.ToString());
        }
        else if (e.CommandName == "next")
        {
            int pageLength = Convert.ToInt32(ViewState["PageLength"]);
            int currentPage = Convert.ToInt32(ViewState["currentPage"]);
            if (currentPage == pageLength - 1)
            {
                this.RegisterStartupScript("msg", "<script>alert('已经是最后一页了！')</script>");
                return;
            }
            currentPage++;
            ViewState["currentPage"] = currentPage.ToString();

            bindRepeater(currentPage);
        }
        else if (e.CommandName == "prev")
        {
            int currentPage = Convert.ToInt32(ViewState["currentPage"]);
            if (currentPage == 0)
            {
                this.RegisterStartupScript("msg", "<script>alert('这是第一页了！')</script>");
                return;
            }
            currentPage--;
            ViewState["currentPage"] = currentPage.ToString();

            bindRepeater(currentPage);
        }

    }
    #endregion
}
