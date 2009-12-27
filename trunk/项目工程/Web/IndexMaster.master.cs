////编写者：陈亚星
////日  期：2009-12-18
////功  能：母版页
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BLL;
using Entity;
using InterFace;

public partial class IndexMaster : System.Web.UI.MasterPage
{
    CartCtrl curCart;
    protected void Page_Load(object sender, EventArgs e)
    {
        int ShopCartError = 0;
        try
        {
            #region 更新购物车
            curCart = new CartCtrl();
            /*获取用户登录名*/
            String userName = HttpContext.Current.User.Identity.Name;
            /*如果用户为登录状态并且COOKIE存在则将COOKIE购物车写入XML*/
            if (userName != null && userName.Length > 0)
            {
                if (HttpContext.Current.Request.Cookies["Cart"] != null)
                {
                    if (!curCart.WriteToXML(userName))
                    {
                        Response.Write("<script>alert('购物车存储失败，请重新操作！');history.go(-1);</script>");
                    }
                    /*购物车转存完毕后清除COOKIE购物车*/
                    Response.Cookies["Cart"].Expires = DateTime.Now.AddDays(-1);
                }
            }
            #endregion
            
        }catch(Exception ex)
        {
            pShopCartError.Visible = true;
            pShopCart.Visible = false;
            ShopCartError = 1;
        }
        if(ShopCartError==0)
        {
            pShopCart.Visible = true;
            pShopCartError.Visible = false;
        }
        lbTotalPrice.Text = String.Format("{0:C}",curCart.GetTotalPrice());
        lbTotalQuantity.Text = curCart.GetItemQuantity().ToString();
        this.Page.Title = "Sherry化妆品有限公司";

        
        if (HttpContext.Current.User.Identity.Name == null||HttpContext.Current.User.Identity.Name.Length<=0)
        {
            lsLogOut.Visible = false;
            lShowOrder.Visible = false;
        }
        else 
        {
            lsLogOut.Visible = true;
            lShowOrder.Visible = true;
        }
        if (!SpecialGoodsDatabind())
        {
            SOfferError.Visible = true;
        }
        else 
        {
            SOfferError.Visible = false;
        }

        if (!CategoryListDatabind())
        {
            CategoryError.Visible = true;
        }
        else
        {
            CategoryError.Visible = false;
        }
    }

    #region 特价商品数据绑定
    public bool SpecialGoodsDatabind() 
    {
        MasterPageBLL mpCtrl = new MasterPageBLL();
        IList<ItemEntity> itemList = new List<ItemEntity>();
        if (!mpCtrl.GetSpecialOffers(ref itemList)) 
        {
            return false;
        }
        RpSpecailOffer.DataSource = itemList;
        RpSpecailOffer.DataBind();        
        return true;
    }
    #endregion

    #region 商品分类数据绑定
    public bool CategoryListDatabind()
    {
        MasterPageBLL mpCtrl = new MasterPageBLL();
        IList<ItemEntity> categoryList = new List<ItemEntity>();
        if (!mpCtrl.GetCategoryList(ref categoryList))
        {
            return false;
        }
        dlCatagoryList.DataSource = categoryList;
        dlCatagoryList.DataBind();
        return true;
    }
    #endregion
}
