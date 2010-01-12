////��д�ߣ�������
////��  �ڣ�2010-01-12
////��  �ܣ���̨�绰���۶�������
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
using BLL;
using DAL;
using Entity;

public partial class Management_AddOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            DataTable category = new DataTable();
            GoodsInfoBLL.GetCategory(ref category);
            ddlGoodsCategory.DataSource = category;
            ddlGoodsCategory.DataValueField = "ID";
            ddlGoodsCategory.DataTextField = "name";
            ddlGoodsCategory.DataBind();
        }
    }
    #region ���������б�
    protected void ddlUserProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList<ShopInfo> shopInfoList = new List<ShopInfo>();
        string province = ddlUserProvince.SelectedItem.Text.ToString();
        ShopInfoBLL updateArea = new ShopInfoBLL();
        if (updateArea.SrchShopByProvince(ref shopInfoList, province) == -1)
        {
            Response.Write("<script>alert('�������ݸ���ʧ�ܣ�������ѡ��');history.go(-1);</script>");
            return;
        }
        int i = 0;
        ddlUserArea.Items.Clear();
        for (; i < shopInfoList.Count; i++)
        {
            ListItem it = new ListItem(shopInfoList[i].Area.ToString(), shopInfoList[i].ShopID.ToString());
            ddlUserArea.Items.Add(it);
        }
    }
    #endregion

    #region ������Ʒ�б�
    protected void ddlGoodsCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable goods = new DataTable();
        goods = GoodsInfoBLL.FindGoods(Convert.ToInt32(ddlGoodsCategory.SelectedItem.Value));
        ddlGoods.Items.Clear();
        ddlGoods.DataSource = goods;
        ddlGoods.DataTextField = "goodsName";
        ddlGoods.DataValueField = "goodsID";
        ddlGoods.DataBind();
    }
    #endregion
}
