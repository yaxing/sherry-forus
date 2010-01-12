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
using System.Drawing;
using BLL;
using Entity;

public partial class AddPoll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            addOptions(2);
        }
        else
        {
            addOptions(int.Parse(selectNum.SelectedValue));
        }
    }

    private void addOptions(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            Poll option = new Poll();
            option.OptionIndex = i;
            options.Controls.Add(option);
        }

    }

    public void addVote_Click(object sender, EventArgs e)
    {
        MainPoll newMainPoll = new MainPoll();
        newMainPoll.Topic = topic.Text;
        newMainPoll.SelectNum = selectNum.SelectedIndex;
        newMainPoll.SingleMode = selectPattern.Items[0].Selected.ToString();
        newMainPoll.ColMode = picStyle.Items[0].Selected.ToString();
        PollInfoBLL addMainPoll = new PollInfoBLL();
        int mainPollID = addMainPoll.AddMainPollInfo(newMainPoll);

        for (int i = 0; i < options.Controls.Count; i++)
        {
            SubPoll newSubPoll = new SubPoll();
            newSubPoll.MainPollID = mainPollID;
            newSubPoll.Description = ((Poll)options.Controls[i]).OptionName;
            newSubPoll.Color = ((Poll)options.Controls[i]).OptionColor;
            newSubPoll.Num = ((Poll)options.Controls[i]).Ballots;
            PollInfoBLL addSubPoll = new PollInfoBLL();
            addSubPoll.AddSubPollInfo(newSubPoll);
        }
    }
}
