////编写者：陈亚星
////日  期：2009-12-03
////功  能：购物车模块的逻辑处理
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using Entity;
using DAL;

namespace BLL
{

    #region 购物车控制类
    public class CartCtrl
    {
        //curCart:购物车实体
        //Info: 购物车项实体
        private ShopCart curCart;
        private ItemEntity Info;
        private int curID;

        #region 构造函数-查询库存
        public CartCtrl(int id) 
        {
            curID = id;
        }
        #endregion

        #region 构造函数-购物车
        /// <summary>
        /// 构造购物车
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public CartCtrl()
        {
            String cartValue = String.Empty;
            curCart = new ShopCart();
            curCart.curDic = new Hashtable();//构造哈希表，作为购物车暂存空间
            curCart.curUser = HttpContext.Current.User.Identity.Name;
            
            //每次构造购物车将重新合并COOKIE与XML中ITEMS，构造一个新的HASHTABLE

            /*如果cookie购物车存在，读取cookie购物车至哈希表*/
            if (HttpContext.Current.Request.Cookies["Cart"] != null)
            {
                cartValue = HttpContext.Current.Request.Cookies["Cart"].Value;
                String[] temp = cartValue.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String item in temp)
                {
                    String[] temp2 = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Info = new ItemEntity(Convert.ToInt32(temp2[0]), temp2[1].ToString(), Convert.ToInt32(temp2[2]), Convert.ToInt32(temp2[3]),temp2[4]);
                    curCart.curDic.Add(Info.ID, Info);
                }
            }

            /*如果用户已登录，将相应XML购物车读取至哈希表*/
            if (curCart.curUser != null && curCart.curUser.Length > 0)
            {
                String itemId = String.Empty;
                String itemName = String.Empty;
                String itemNumber = String.Empty;
                String itemPrice = String.Empty;
                String itemImgPath = String.Empty;

                XmlDocument xmlD = new XmlDocument();

                /*获取当前登录用户节点及其所有ITEM节点list*/
                XmlElement xmlEle = GetUserNode(xmlD,curCart.curUser);

                if (xmlEle == null) 
                {
                    return;
                }

                XmlNodeList xmlLst = xmlEle.ChildNodes;

                foreach (XmlNode xmlN in xmlLst)
                {
                    #region 从XML读取item
                    XmlElement curItem = (XmlElement)xmlN;
                    itemId = curItem.GetAttribute("id").ToString();
                    itemName = curItem.GetAttribute("itemName").ToString();
                    itemNumber = curItem.GetAttribute("itemNumber").ToString();
                    itemPrice = curItem.GetAttribute("itemPrice").ToString();
                    itemImgPath = curItem.GetAttribute("itemImgPath").ToString();
                    #endregion

                    #region 将读取的ITEM写进哈希表
                    int id = Convert.ToInt32(itemId);
                    int number = Convert.ToInt32(itemNumber);
                    double price = Convert.ToDouble(itemPrice);

                    ItemEntity Info = new ItemEntity(id,itemName,number,price,itemImgPath);
                    if (curCart.curDic.ContainsKey(Info.ID))
                    {
                        ItemEntity curNum = (ItemEntity)curCart.curDic[Info.ID];
                        curCart.curDic.Remove(Info.ID);
                        Info.Number = curNum.Number + 1;
                        curCart.curDic.Add(Info.ID, Info);
                    }
                    else
                    {
                        curCart.curDic.Add(Info.ID, Info);
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region 查询库存
        public bool curStorage(ref int curS)
        {
            ShopCartInfoDAL sc = new ShopCartInfoDAL();
            return sc.GetStorage(ref curS, curID);
        }
        #endregion

        #region 添加商品
        /// <summary>
        /// 添加商品至hashtable
        /// </summary>
        /// <param name="proId">需要添加的商品ID</param>
        /// <returns>bool值</returns>
        public bool Add(int proId)
        {
            ShopCartInfoDAL shopData = new ShopCartInfoDAL();
            ItemEntity Info = new ItemEntity(proId);
            shopData.SetItemEntity(ref Info);

            if (curCart.curDic.ContainsKey(Info.ID))
            {
                ItemEntity curNum = (ItemEntity)curCart.curDic[Info.ID];
                curCart.curDic.Remove(Info.ID);
                Info.Number = curNum.Number + 1;
                curCart.curDic.Add(Info.ID, Info);
            }
            else
            {
                curCart.curDic.Add(Info.ID, Info);
            }

            if (curCart.curUser != null && curCart.curUser.Length > 0)
            {
                if (WriteToXML(curCart.curUser))
                {
                    return true;
                }
                else
                    return false;
            }
            SaveCookie();
            return true;
        }
        #endregion

        #region 获取指定商品实体
        /// <summary>
        /// 从hashtable中获取指定商品实体
        /// </summary>
        /// <param name="ID">商品ID</param>
        /// <returns>商品实体对象</returns>
        public ItemEntity GetItem(int ID)
        {
            if (curCart.curDic.ContainsKey(ID))
            {
                return (ItemEntity)curCart.curDic[ID];
            }
            return null;
        }
        #endregion

        #region 获取购物车内商品列表(IList)
        public IList<ItemEntity> GetList()
        {
            IList<ItemEntity> List = new List<ItemEntity>();
            foreach (ItemEntity ie in curCart.curDic.Values)
            {
                List.Add(ie);
            }
            return List;
        }
        #endregion

        #region 获取商品总数
        public int GetItemQuantity() 
        {
            int total = 0;
            foreach (ItemEntity ie in curCart.curDic.Values) 
            {
                total += ie.Number;
            }
            return total;
        }
        #endregion

        #region 获取购物车内商品列表(ICollection)
        public ICollection GetItems() 
        {
            return curCart.curDic.Values;
        }
        #endregion

        #region 获取商品总价格
        public double GetTotalPrice() {
            double total = 0.0;
            foreach(ItemEntity e in curCart.curDic.Values){
                total += e.Number * e.Price;
            }

            return total;
        }
        #endregion

        #region 显示商品总价格
        public String ShowTotalPrice()
        {
            double total = 0.0;
            foreach (ItemEntity e in curCart.curDic.Values)
            {
                total += e.Number * e.Price;
            }

            return String.Format("{0:C}",total);
        }
        #endregion

        #region 获取当前商品项价格总计
        public double GetItemPrice(int ID) {
            double itemPrice = 0.0;
            ItemEntity item = (ItemEntity)curCart.curDic[ID];
            itemPrice = item.Number * item.Price;
            return itemPrice;
        }
        #endregion

        #region 移除商品
        public void Remove(int ID)
        {
            if (curCart.curDic.ContainsKey(ID))
            {
                curCart.curDic.Remove(ID);
            }

            if (curCart.curUser != null && curCart.curUser.Length > 0)
            {
                WriteToXML(curCart.curUser);
                return;
            }
            SaveCookie();
        }
        #endregion

        #region 清空购物车
        public bool RemoveCart()
        {
            String user = String.Empty;
            curCart.curDic.Clear();
            SaveCookie();
            
            if (curCart.curUser!=null&&curCart.curUser.Length>0) 
            {
                XmlDocument xmlD = new XmlDocument();
                XmlElement e = GetUserNode(xmlD,curCart.curUser);
                e.ParentNode.RemoveChild((XmlNode)e);
                try
                {
                    String FilePath = HttpContext.Current.Server.MapPath("UserCart.xml");
                    XmlTextWriter xmlTW = new XmlTextWriter(FilePath, Encoding.UTF8);
                    xmlD.WriteTo(xmlTW);
                    xmlTW.Close();
                }
                catch (System.Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 修改商品数量
        public void Edit(int ID, int Number)
        {
            if (curCart.curDic.ContainsKey(ID))
            {
                ItemEntity Info = (ItemEntity)curCart.curDic[ID];
                curCart.curDic.Remove(ID);
                Info.Number = Number;
                curCart.curDic.Add(ID, Info);

                if (curCart.curUser != null && curCart.curUser.Length > 0)
                {
                    WriteToXML(curCart.curUser);
                    return;
                }
                SaveCookie();
            }
        }
        #endregion

        #region 保存COOKIE购物车(未登录用户)
        /// <summary>
        /// 将HASHTABLE保存至cookie
        /// </summary>
        /// <param></param>
        /// <returns>bool值</returns>
        public Boolean SaveCookie()
        {

            string s = string.Empty;
            ItemEntity Info;
            HttpCookie cookie;
            foreach (ItemEntity item in curCart.curDic.Values)
            {
                Info = item;
                s += Info.ID.ToString() + "|" + Info.Name + "|" + Info.Number.ToString() + "|" + Info.Price.ToString() + "|" + Info.ImgPath + "@";
            }
            if (HttpContext.Current.Request.Cookies["Cart"] != null)
            {
                cookie = HttpContext.Current.Request.Cookies["Cart"];
            }
            else
            {
                cookie = new HttpCookie("Cart");
            }
            cookie.Value = s;
            if (s != null && s.Length > 0)
            {
                cookie.Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Request.Cookies.Remove("Cart");
            }
            try
            {
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception e) { return false; }
            return true;
        }
        #endregion

        #region 将购物车写入XML
        public Boolean WriteToXML(String userName)
        {
            string s = string.Empty;
            ItemEntity Info;
            String proId;
            String name;
            String number;
            String price;
            String imgPath;
            XmlDocument xmlD = new XmlDocument();
            
            XmlElement xmlEle = GetUserNode(xmlD,userName);
            if (xmlEle == null)
            {

                xmlEle = xmlD.CreateElement("User");
            }

            else 
            {
                xmlEle.RemoveAll();
            }

            xmlEle.SetAttribute("id", userName);
            xmlEle.SetAttribute("TotalPrice", this.GetTotalPrice().ToString());
            xmlEle.SetAttribute("TotalNumber", this.GetItemQuantity().ToString());

            foreach (ItemEntity item in curCart.curDic.Values)
            {
                Info = item;
                proId = Info.ID.ToString();
                name = Info.Name;
                number = Info.Number.ToString();
                price = Info.Price.ToString();
                imgPath = Info.ImgPath;

                XmlElement xmlEle2 = xmlD.CreateElement("Item");

                xmlEle2.SetAttribute("id", proId);
                xmlEle2.SetAttribute("itemName", name);
                xmlEle2.SetAttribute("itemNumber", number);
                xmlEle2.SetAttribute("itemPrice", price);
                xmlEle2.SetAttribute("itemImgPath",imgPath);
                xmlEle.AppendChild(xmlEle2);
            }


            xmlD.DocumentElement.AppendChild(xmlEle);
            xmlD.PreserveWhitespace = false;
            try
            {
                String FilePath = HttpContext.Current.Server.MapPath("UserCart.xml");
                XmlTextWriter xmlTW = new XmlTextWriter(FilePath, Encoding.UTF8);
                xmlD.WriteTo(xmlTW);
                xmlTW.Close();
            }
            catch (System.Exception e)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 从XML中读取相应用户结点

        public XmlElement GetUserNode(XmlDocument xmlD, String userName) 
        {
            String FilePath = HttpContext.Current.Server.MapPath("UserCart.xml");

            try
            {
                xmlD.Load(FilePath);
            }
            catch (System.Exception e)
            {
                HttpContext.Current.Response.Write("<script>alert('读取购物车失败！请重新操作！');history.go(-1);</script>");
            }

            XmlElement xmlEle = (XmlElement)xmlD.SelectSingleNode("Users/User[@id='" + curCart.curUser + "']");
            return xmlEle;
        }

        #endregion
    }
    #endregion

}
