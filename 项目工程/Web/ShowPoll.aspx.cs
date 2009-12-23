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
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using BLL;
using Entity;
public partial class ShowPoll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Server.HtmlEncode(Request.QueryString["id"]);
            MainPoll mainPoll = new MainPoll();
            mainPoll.MainPollID = Int32.Parse(id);
            PollInfoBLL selectMainPoll = new PollInfoBLL();
            selectMainPoll.SelectByID(ref mainPoll);
            drawChart(mainPoll,id);
        }
    }

    private void drawChart(MainPoll mainPoll, string id)
    {
        IList<SubPoll> subPollList = new List<SubPoll>();
        PollInfoBLL selectSubPoll = new PollInfoBLL();
    
        //选项总数
        int TotalOptions = selectSubPoll.SelectSubPollByID(ref subPollList,mainPoll);;
        string[] OptionArray = new string[TotalOptions];
        string[] ColorArray = new string[TotalOptions];
        int[] BallotArray = new int[TotalOptions];
       
        int TotalBallots = 0;

        for (int i = 0; i < TotalOptions; i++)
        {
            OptionArray[i] = subPollList[i].Description.ToString();
            ColorArray[i] = subPollList[i].Color.ToString(); 
            BallotArray[i] = subPollList[i].Num; 
            TotalBallots += BallotArray[i];
        }
        
        Bitmap bm = new Bitmap(300, 100);
        Graphics g = Graphics.FromImage(bm);
        g.Clear(Color.Yellow);
        StringFormat sf = new StringFormat();
        sf.Alignment = StringAlignment.Center;
        sf.LineAlignment = StringAlignment.Center;

        int OptionLength = 0;
        for (int i = 0; i < OptionArray.Length; i++)
        {
            if (GetStringLength(OptionArray[i]) > OptionLength)
                OptionLength = GetStringLength(OptionArray[i]);
        }
        int BallotsLength = (TotalBallots.ToString().Length) * 8 + 60;
        int LegendLength = 0;
        if (OptionLength > 20)
            LegendLength = 200 + BallotsLength;
        else
            LegendLength = OptionLength * 10 + 50 + BallotsLength;
        int BarWidth = Int32.Parse(ConfigurationSettings.AppSettings["BarWidth"]);
        int BarSpace = Int32.Parse(ConfigurationSettings.AppSettings["BarSpace"]);
        int BarLeftSpace = (TotalBallots.ToString().Length) * 6 + 10;
        int PieChartWidth = Int32.Parse(ConfigurationSettings.AppSettings["PieWidth"]);
        int PieChartHeight = Int32.Parse(ConfigurationSettings.AppSettings["PieHeight"]);
        int BMWidth = (mainPoll.ColMode.Equals("True")) ? (TotalOptions * BarSpace + BarLeftSpace + 20 + LegendLength) : (PieChartWidth + 80 + LegendLength);
        int LegendHeight = TotalOptions * 22 + 90;
        int BMHeight = (mainPoll.ColMode.Equals("True")) ? LegendHeight : Math.Max(PieChartHeight + 110, LegendHeight);
        if (BMHeight < 250)
            BMHeight = 250;
        int BarChartHeight = BMHeight - 80;
        string PollSubject = ((GetStringLength(mainPoll.Topic) * 12) > BMWidth) ? GetLeftString(mainPoll.Topic, (int)(BMWidth / 25)) : mainPoll.Topic;
        bm = new Bitmap(BMWidth, BMHeight);
        g = Graphics.FromImage(bm);
        g.Clear(Color.Snow);

        Rectangle SubjectRec = new Rectangle(0, 4, BMWidth, 28);
        Rectangle BallotsRec = new Rectangle(0, 30, BMWidth, 20);
        g.DrawString(PollSubject, new Font("楷体_gb2312", 14), Brushes.Black, SubjectRec, sf);
        g.DrawString("（选票总数：" + TotalBallots.ToString() + "）", new Font("楷体_gb2312", 10), Brushes.Black, BallotsRec, sf);
        g.DrawRectangle(Pens.Black, 0, 0, BMWidth - 1, BMHeight - 1);

        PointF LegendPoint = new PointF(BMWidth - LegendLength, 90);
        PointF DescPoint = new PointF(LegendPoint.X + 30, 90);
        g.DrawString("图例", new Font("宋体", 12, FontStyle.Bold), new SolidBrush(Color.Red), new Rectangle((int)(LegendPoint.X), 60, LegendLength, 25), sf);

        if (mainPoll.ColMode.Equals("True"))  //柱形图
        {
            float LineSpace = BarChartHeight;
            float ScalePercent = 1.0f;
            int MaxBallotsValue = (TotalBallots > 90) ? (TotalBallots + (10 - TotalBallots % 10)) : (((TotalBallots <= 10) || (TotalBallots % (TotalBallots / 10 + 1) == 0) || (TotalBallots % 10 == 0)) ? TotalBallots : (TotalBallots + ((TotalBallots / 10 + 1) - (TotalBallots % (TotalBallots / 10 + 1)))));
            int BallotsStep = (TotalBallots <= 10) ? 1 : ((TotalBallots <= 90) ? ((TotalBallots % 10 == 0) ? (TotalBallots / 10) : (TotalBallots / 10 + 1)) : (MaxBallotsValue / 10));
            ScalePercent = (float)TotalBallots / (float)MaxBallotsValue;                
            for (int i = BallotsStep; i <= MaxBallotsValue; i += BallotsStep)
            {
                float LinePosition = (float)(BMHeight - LineSpace);
                g.DrawString((MaxBallotsValue + BallotsStep - i).ToString(), new Font("宋体", 10), new SolidBrush(Color.Red), 2.0f, (float)(LinePosition - 6));
                g.DrawLine(Pens.LightGray, 8.0f, LinePosition, (float)(BMWidth - LegendLength - 20.0f), LinePosition);
                LineSpace -= (float)((float)BarChartHeight / (float)(MaxBallotsValue / BallotsStep));
            }

            g.DrawLine(Pens.LightGray, (float)(BMWidth - LegendLength - 20), (float)(BMHeight - BarChartHeight), (float)(BMWidth - LegendLength - 20), (float)BMHeight);

            for (int i = 0; i < BallotArray.Length; i++)
            {
                float BarHeight = (float)(BallotArray[i] * BarChartHeight / TotalBallots * ScalePercent);
                g.FillRectangle(new SolidBrush(GetColor(ColorArray[i])), BarLeftSpace, (float)(BMHeight - BarHeight), (float)BarWidth, BarHeight);
                g.DrawRectangle(Pens.Black, BarLeftSpace, (float)(BMHeight - BarHeight), (float)BarWidth, BarHeight);
                g.DrawString(BallotArray[i].ToString(), new Font("宋体", 9), new SolidBrush(Color.Black), new RectangleF((float)(BarLeftSpace - 18.0), (float)(BMHeight - BarHeight - 16), 50.0f, 20.0f), sf);
                BarLeftSpace += BarSpace;
            }
        }
        else    //饼图
        {
            Single StartAng = 0;
            Single CurrentAng = 0;
            for (int i = 0; i < BallotArray.Length; i++)
            {
                float percent = (TotalBallots == 0) ? 0.0F : (float)((float)BallotArray[i] / (float)TotalBallots);
                CurrentAng = percent * 360;
                g.FillPie(new SolidBrush(GetColor(ColorArray[i])), 1, 80, PieChartWidth, PieChartHeight, StartAng, CurrentAng);
                g.DrawPie(Pens.Black, 1, 80, PieChartWidth, PieChartHeight, StartAng, CurrentAng);
                g.DrawEllipse(Pens.Black, 1, 80, PieChartWidth, PieChartHeight);
                StartAng += CurrentAng;
            }
            g.DrawString("大帅哥林思然制作", new Font("宋体", 9), new SolidBrush(Color.Blue), new Rectangle(0, BMHeight - 22, BMWidth, 22), sf);
        }

        for (int i = 0; i < OptionArray.Length; i++)
        {
            float percent = (TotalBallots == 0) ? 0.0F : (float)((float)BallotArray[i] / (float)TotalBallots);
            g.FillRectangle(new SolidBrush(GetColor(ColorArray[i])), LegendPoint.X, LegendPoint.Y, 20, 10);
            g.DrawRectangle(Pens.Black, LegendPoint.X, LegendPoint.Y, 20, 10);
            g.DrawString(GetLeftString(OptionArray[i], 10), new Font("宋体", 10), Brushes.Black, DescPoint);
            g.DrawString(BallotArray[i].ToString() + "（" + percent.ToString("#0.#%") + "）", new Font("宋体", 10), Brushes.Red, BMWidth - BallotsLength, DescPoint.Y);
            LegendPoint.Y += 20;
            DescPoint.Y += 20;
        }
        //bm.Save(Response.OutputStream, ImageFormat.Jpeg);
        bm.Save(Server.MapPath("./images/statistic/"+id+".jpeg"));
        map.ImageUrl = "images/statistic/"+id+".jpeg";
    }
    private Color GetColor(string colorstr)
    {
        return Color.FromArgb(Int32.Parse(colorstr));
    }

    private int GetStringLength(string str)
    {
        byte[] bytes = Encoding.Default.GetBytes(str);
        return bytes.Length;
    }

    private string GetLeftString(string str, int cnum)
    {
        if (str.Length <= cnum)
            return str;
        if (GetStringLength(str) < cnum * 2)
            return str;
        char[] cstr = str.ToCharArray();
        StringBuilder sb = new StringBuilder();
        for (int i = 0, j = 0; i < (cnum * 2); )
        {
            if (Encoding.Default.GetBytes(cstr, j, 1).Length == 1)
                i++;
            else
                i += 2;
            sb.Append(str[j]);
            j++;
        }
        sb.Append("……");
        return sb.ToString();
    }
}