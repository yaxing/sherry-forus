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

public partial class Management_EditPoll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindVote();
        }
        if (gvVote.EditIndex >= 0)
        {
            addControlsToPlaceHolder();
        }
    }

    private void addControlsToPlaceHolder()
    {
        DropDownList ddl = gvVote.Rows[gvVote.EditIndex].Cells[1].FindControl("ddlOpCount") as DropDownList;
        PlaceHolder ph = gvVote.Rows[gvVote.EditIndex].Cells[1].FindControl("phOptions") as PlaceHolder;

        for (int i = 0; i < int.Parse(ddl.SelectedValue); i++)
        {
            Poll poll = new Poll();
            poll.OptionIndex = i + 1;
            ph.Controls.Add(poll);
        }
    }

    private void BindVote()
    {
        IList<MainPoll> ds = new List<MainPoll>();
        PollInfoBLL mainPoll = new PollInfoBLL();
        mainPoll.ShowMainPoll(ref ds);

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

        gvVote.DataSource = dt;
        gvVote.DataBind();
    }

    protected void gvVote_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvVote.EditIndex = e.NewEditIndex;
        BindVote();
    }
    protected void gvVote_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvVote.EditIndex = -1;
        BindVote();
    }

    protected void gvVote_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int mainPollID = Int32.Parse(gvVote.Rows[e.RowIndex].Cells[0].Text);

        PollInfoBLL pollInfo = new PollInfoBLL();

        pollInfo.DeletePoll(mainPollID);

        BindVote();

    }

    protected void gvVote_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowState == DataControlRowState.Edit || (e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit)))
            {
                try
                {
                    DropDownList ddl = e.Row.Cells[1].FindControl("ddlOpCount") as DropDownList;

                    IList<SubPoll> subPollList = new List<SubPoll>();
                    PollInfoBLL pollInfo = new PollInfoBLL();
                    MainPoll mainPoll = new MainPoll();
                    mainPoll.MainPollID = Int32.Parse(e.Row.Cells[0].Text);
                    pollInfo.SelectSubPollByID(ref subPollList, mainPoll);

                    PlaceHolder ph = e.Row.Cells[1].FindControl("phOptions") as PlaceHolder;
                    for (int i = 0; i < subPollList.Count; i++)
                    {
                        Poll option = new Poll();
                        option.OptionIndex = i;
                        option.OptionID = subPollList[i].SubPollID;
                        option.OptionName = subPollList[i].Description;
                        option.Ballots = subPollList[i].Num;
                        option.OptionColor = subPollList[i].Color;
                        ph.Controls.Add(option);
                    }

                    pollInfo.SelectByID(ref mainPoll);
                    RadioButtonList selectMode = e.Row.Cells[1].FindControl("rblSelectPattern") as RadioButtonList;
                    RadioButtonList chartMode = e.Row.Cells[1].FindControl("rblPicStyle") as RadioButtonList;
                    selectMode.SelectedIndex = mainPoll.SingleMode.Equals("True") ? 0 : 1;
                    chartMode.SelectedIndex = mainPoll.ColMode.Equals("True") ? 0 : 1;

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }

            }
        }
    }

    protected void gvVote_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        PollInfoBLL pollInfo = new PollInfoBLL();

        PlaceHolder ph = gvVote.Rows[e.RowIndex].Cells[1].FindControl("phOptions") as PlaceHolder;

        MainPoll mainPoll = new MainPoll();
        mainPoll.MainPollID = Int32.Parse(gvVote.Rows[e.RowIndex].Cells[0].Text);
        mainPoll.Topic = ((TextBox)gvVote.Rows[e.RowIndex].Cells[1].FindControl("tbTitle")).Text;
        mainPoll.SelectNum = ph.Controls.Count;
        mainPoll.SingleMode = ((RadioButtonList)gvVote.Rows[e.RowIndex].Cells[1].FindControl("rblSelectPattern")).Items[0].Selected.ToString();
        mainPoll.ColMode = ((RadioButtonList)gvVote.Rows[e.RowIndex].Cells[1].FindControl("rblPicStyle")).Items[0].Selected.ToString();

        pollInfo.UpdateMainPoll(mainPoll);

        //更新在 PlaceHolder 中的选项
        for (int i = 0; i < ph.Controls.Count; i++)
        {

            Poll poll = (Poll)ph.Controls[i];

            SubPoll subPoll = new SubPoll();
            subPoll.SubPollID = poll.OptionID;
            subPoll.Description = poll.OptionName;
            subPoll.Color = poll.OptionColor;
            subPoll.Num = poll.Ballots;

            pollInfo.UpdateSubPoll(subPoll);

        }

        gvVote.EditIndex = -1;
        BindVote();
    }
}
