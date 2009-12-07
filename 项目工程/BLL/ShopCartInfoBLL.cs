////编写者：陈亚星
////日  期：2009-12-03
////功  能：购物车模块的逻辑处理
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;

namespace BLL
{

    #region 购物车类
    public class Cart
    {
        private Hashtable dic;
        private String userName;
        
        #region 构造购物车
        public Cart()
        {
            String cartValue = String.Empty;
            dic = new Hashtable();//构造哈希表，作为购物车暂存空间
            userName = HttpContext.Current.User.Identity.Name;
            
            /*如果cookie购物车存在，读取cookie购物车至哈希表*/
            if (HttpContext.Current.Request.Cookies["Cart"] != null)
            {
                //cartExsisted = true;
                cartValue = HttpContext.Current.Request.Cookies["Cart"].Value;
                ItemEntity Info;
                String[] temp = cartValue.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String item in temp)
                {
                    String[] temp2 = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Info = new ItemEntity(Convert.ToInt32(temp2[0]), temp2[1].ToString(), Convert.ToInt32(temp2[2]), Convert.ToInt32(temp2[3]));
                    dic.Add(Info.id, Info);
                }
            }

            /*如果用户已登录，将相应XML购物车读取至哈希表*/
            if (userName != null && userName.Length > 0)
            {
                String itemId = String.Empty;
                String itemName = String.Empty;
                String itemNumber = String.Empty;
                String itemPrice = String.Empty;

                XmlDocument xmlD = new XmlDocument();

                /*获取当前登录用户节点及其所有ITEM节点list*/
                XmlElement xmlEle = GetUserNode(xmlD,userName);

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
                    #endregion

                    #region 将读取的ITEM至哈希表
                    int id = Convert.ToInt32(itemId);
                    int number = Convert.ToInt32(itemNumber);
                    double price = Convert.ToDouble(itemPrice);

                    ItemEntity Info = new ItemEntity(id,itemName,number,price);
                    if (dic.ContainsKey(Info.id))
                    {
                        ItemEntity curNum = (ItemEntity)dic[Info.id];
                        dic.Remove(Info.id);
                        Info.number = curNum.number + 1;
                        dic.Add(Info.id, Info);
                    }
                    else
                    {
                        dic.Add(Info.id, Info);
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region 添加商品
        public void Add(int proId)
        {
            ItemEntity Info = new ItemEntity(proId, "纪梵希感光皙颜粉底液", 1, 300);
            if (dic.ContainsKey(Info.id))
            {
                ItemEntity curNum = (ItemEntity)dic[Info.id];
                dic.Remove(Info.id);
                Info.number = curNum.number + 1;
                dic.Add(Info.id, Info);
            }
            else
            {
                dic.Add(Info.id, Info);
            }

            if (userName != null && userName.Length > 0) 
            {
                WriteToXML(userName);
                return;
            }
            SaveCookie();
        }
        #endregion

        #region 获取指定商品实体
        public ItemEntity GetItem(int ID)
        {
            if (dic.ContainsKey(ID))
            {
                return (ItemEntity)dic[ID];
            }
            return null;
        }
        #endregion

        #region 获取购物车内商品列表(IList)
        public IList<ItemEntity> GetList()
        {
            IList<ItemEntity> List = new List<ItemEntity>();
            foreach (ItemEntity ie in dic.Values)
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
            foreach (ItemEntity ie in dic.Values) 
            {
                total += ie.number;
            }
            return total;
        }
        #endregion

        #region 获取购物车内商品列表(ICollection)
        public ICollection GetItems() 
        {
            return dic.Values;
        }
        #endregion

        #region 获取商品总价格
        public double GetTotalPrice() {
            double total = 0.0;
            foreach(ItemEntity e in dic.Values){
                total += e.Number * e.Price;
            }

            return total;
        }
        #endregion

        #region 显示商品总价格
        public String ShowTotalPrice()
        {
            double total = 0.0;
            foreach (ItemEntity e in dic.Values)
            {
                total += e.Number * e.Price;
            }

            return String.Format("{0:C}",total);
        }
        #endregion

        #region 获取当前商品项价格总计
        public double GetItemPrice(int ID) {
            double itemPrice = 0.0;
            ItemEntity item = (ItemEntity)dic[ID];
            itemPrice = item.Number * item.Price;
            return itemPrice;
        }
        #endregion

        #region 移除商品
        public void Remove(int ID)
        {
            if (dic.ContainsKey(ID))
            {
                dic.Remove(ID);
            }

            if (userName != null && userName.Length > 0)
            {
                WriteToXML(userName);
                return;
            }
            SaveCookie();
        }
        #endregion

        #region 清空购物车
        public void RemoveCart()
        {
            String user = String.Empty;
            dic.Clear();
            SaveCookie();
            
            if (userName!=null&&userName.Length>0) 
            {
                XmlDocument xmlD = new XmlDocument();
                XmlElement e = GetUserNode(xmlD,userName);
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
                    HttpContext.Current.Response.Write("<script>alert('存储购物车失败！请重新操作！');history.go(-1);</script>");
                }
            }
        }
        #endregion

        #region 修改商品数量
        public void Edit(int ID, int Number)
        {
            if (dic.ContainsKey(ID))
            {
                ItemEntity Info = (ItemEntity)dic[ID];
                dic.Remove(ID);
                Info.number = Number;
                dic.Add(ID, Info);

                if (userName != null && userName.Length > 0)
                {
                    WriteToXML(userName);
                    return;
                }
                SaveCookie();
            }
        }
        #endregion

        #region 保存COOKIE购物车(未登录用户)
        public void SaveCookie()
        {

            string s = string.Empty;
            ItemEntity Info;
            HttpCookie cookie;
            foreach (ItemEntity item in dic.Values)
            {
                Info = item;
                s += Info.id.ToString() + "|" + Info.name + "|" + Info.number.ToString() + "|" + Info.price.ToString() + "@";
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
            HttpContext.Current.Response.Cookies.Add(cookie);
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

            foreach (ItemEntity item in dic.Values)
            {
                Info = item;
                proId = Info.id.ToString();
                name = Info.name;
                number = Info.number.ToString();
                price = Info.price.ToString();

                XmlElement xmlEle2 = xmlD.CreateElement("Item");

                xmlEle2.SetAttribute("id", proId);
                xmlEle2.SetAttribute("itemName", name);
                xmlEle2.SetAttribute("itemNumber", number);
                xmlEle2.SetAttribute("itemPrice", price);
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
                HttpContext.Current.Response.Write("<script>alert('存储购物车失败！请重新操作！');history.go(-1);</script>");
            }

            /*购物车转存完毕后清除COOKIE购物车*/
            dic.Clear();
            SaveCookie();

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

            XmlElement xmlEle = (XmlElement)xmlD.SelectSingleNode("Users/User[@id='" + userName + "']");
            return xmlEle;
        }

        #endregion
    }
    #endregion

    #region 商品信息类
    public class ItemEntity
    {
        public int id;
        public String name;
        public int number;
        public double price;

        public ItemEntity(int id, String name, int number, double price) 
        {
            this.id = id;
            this.name = name;
            this.number = number;
            this.price = price;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public String ShowPrice
        {
            get { return String.Format("{0:C}",price); }
        }

        public double Price 
        {
            get { return price; }
            set { price = value; }
        }

        public String CurItemTotalPrice 
        {
            get { return String.Format("{0:C}", price * number); }
        }
    }
    #endregion

}
