using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI.HtmlControls;

namespace BLL
{
    [ToolboxData("<{0}:Poll runat=server></{0}:Poll>")]
    public class Poll : Control,INamingContainer
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("1")]
        [Localizable(true)]

        public int OptionIndex
        {
            get
            {
                int? i = (int?)ViewState["OptionIndex"];
                return ((i == null) ? 1 : i.Value);
            }

            set
            {
                int i = value;
                ViewState["OptionIndex"] = i;
                this.EnsureChildControls();
                ((HtmlSelect)Controls[5]).SelectedIndex = i - 1;
            }
        }

        public int OptionID
        {
            get
            {
                this.EnsureChildControls();
                return Int32.Parse(((HiddenField)Controls[7]).Value.ToString());
            }
            set
            {
                this.EnsureChildControls();
                ((HiddenField)Controls[7]).Value = value.ToString();
            }
        }

        public string OptionName
        {
            get 
            {
                this.EnsureChildControls();
                return HttpContext.Current.Server.HtmlEncode(((TextBox)Controls[1]).Text.Trim());
            }
            set
            {
                this.EnsureChildControls();
                ((TextBox)Controls[1]).Text = value;
            }
        }

        public int Ballots
        {
            get
            {
                this.EnsureChildControls();
                return int.Parse(((TextBox)Controls[3]).Text.Trim());
            }
            set
            {
                this.EnsureChildControls();
                ((TextBox)Controls[3]).Text = value.ToString();
            }
        }

        public string OptionColor
        {
            get
            {
                this.EnsureChildControls();
                return Color.FromName(((HtmlSelect)Controls[5]).Value).ToArgb().ToString().Trim();
            }
            set
            {
                HtmlSelect hs = (HtmlSelect)Controls[5];
                for (int i = 0; i < hs.Items.Count; i++)
                {
                    Color c = Color.FromName(hs.Items[i].Value);
                    if (c.ToArgb().ToString() == value)
                        hs.SelectedIndex = i;
                }
            }
        }

        protected override void CreateChildControls()
        {
            //--------0---------
            this.Controls.Add(new LiteralControl("选项" + OptionIndex.ToString() + "："));
            //--------1---------
            TextBox tbOp = new TextBox();
            tbOp.Text = "";
            tbOp.MaxLength = 70;
            tbOp.Columns = 14;
            tbOp.ID = "OptionName_" + OptionIndex.ToString();
            tbOp.EnableViewState = false;
            this.Controls.Add(tbOp);
            //--------2---------
            this.Controls.Add(new LiteralControl("  &nbsp;&nbsp;票数："));
            //-----------3---------
            TextBox balbox = new TextBox();
            balbox.Text = "0";
            balbox.MaxLength = 8;
            balbox.Width = 30;
            balbox.ID = "ballots_" + OptionIndex.ToString();
            balbox.EnableViewState = false;
            this.Controls.Add(balbox);
            //----------4----------
            this.Controls.Add(new LiteralControl("   &nbsp;&nbsp;表示颜色："));
            //----------5---------------颜色：选择
            HtmlSelect colors = new HtmlSelect();
            colors.Items.Add(new ListItem("—红色—", "red"));
            colors.Items.Add(new ListItem("—蓝色—", "blue"));
            colors.Items.Add(new ListItem("—黄色—", "yellow"));
            colors.Items.Add(new ListItem("—黑色—", "black"));
            colors.Items.Add(new ListItem("—灰色—", "gray"));
            colors.Items.Add(new ListItem("—粉色—", "pink"));
            colors.Items.Add(new ListItem("—绿色—", "green"));
            colors.Items.Add(new ListItem("—金色—", "gold"));
            colors.Items.Add(new ListItem("—银色—", "silver"));
            colors.Items.Add(new ListItem("—棕色—", "brown"));
            colors.Items.Add(new ListItem("—紫色—", "purple"));
            colors.Items.Add(new ListItem("—青色—", "cyan"));
            colors.Items.Add(new ListItem("—橙色—", "orange"));
            colors.ID = "colors_" + OptionIndex.ToString();
            colors.EnableViewState = false;
            for (int j = 0; j < colors.Items.Count; j++)
            {
                colors.Items[j].Attributes.Add("style", "background-color:" + colors.Items[j].Value + ";color:" + colors.Items[j].Value);
            }
            this.Controls.Add(colors);
            //----------------6------------------
            this.Controls.Add(new LiteralControl("<br />"));
            //----------------7------------------
            HiddenField optionID = new HiddenField();
            this.Controls.Add(optionID);
        }
    }
}
