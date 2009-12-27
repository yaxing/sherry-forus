////��д�ߣ�������
////��  �ڣ�2009-12-03
////��  �ܣ����ﳵģ����߼�����
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml;
using Entity;
using DAL;

namespace BLL
{

    #region ���ﳵ������
    public class CartCtrl
    {
        //curCart:���ﳵʵ��
        //Info: ���ﳵ��ʵ��
        private ShopCart curCart;
        private ItemEntity Info;
        private int curID;

        #region ���캯��-��ѯ���
        public CartCtrl(int id) 
        {
            curID = id;
        }
        #endregion

        #region ���캯��-���ﳵ
        /// <summary>
        /// ���칺�ﳵ
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public CartCtrl()
        {
            String cartValue = String.Empty;
            curCart = new ShopCart();
            curCart.curDic = new Hashtable();//�����ϣ����Ϊ���ﳵ�ݴ�ռ�
            curCart.curUser = HttpContext.Current.User.Identity.Name;
            
            //ÿ�ι��칺�ﳵ�����ºϲ�COOKIE��XML��ITEMS������һ���µ�HASHTABLE

            /*���cookie���ﳵ���ڣ���ȡcookie���ﳵ����ϣ��*/
            if (HttpContext.Current.Request.Cookies["Cart"] != null&&HttpContext.Current.Request.Cookies["Cart"].Value.Length>0)
            {
                cartValue = HttpContext.Current.Request.Cookies["Cart"].Value;
                String[] temp = cartValue.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String item in temp)
                {
                    String[] temp2 = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (temp2.Length < 6) 
                    {
                        break;
                    }
                    Info = new ItemEntity(Convert.ToInt32(temp2[0]), temp2[1].ToString(), Convert.ToInt32(temp2[2]), Convert.ToInt32(temp2[3]),temp2[5]);
                    Info.Discount = Convert.ToDouble(temp2[4]);
                    curCart.curDic.Add(Info.ID, Info);
                }
            }

            /*����û��ѵ�¼������ӦXML���ﳵ��ȡ����ϣ��*/
            if (curCart.curUser != null && curCart.curUser.Length > 0)
            {
                String itemId = String.Empty;
                String itemName = String.Empty;
                String itemNumber = String.Empty;
                String itemPrice = String.Empty;
                String itemDiscount = String.Empty;
                String itemImgPath = String.Empty;

                XmlDocument xmlD = new XmlDocument();

                /*��ȡ��ǰ��¼�û��ڵ㼰������ITEM�ڵ�list*/
                XmlElement xmlEle = GetUserNode(xmlD,curCart.curUser);

                if (xmlEle == null) 
                {
                    return;
                }

                XmlNodeList xmlLst = xmlEle.ChildNodes;

                foreach (XmlNode xmlN in xmlLst)
                {
                    //��XML��ȡitem
                    XmlElement curItem = (XmlElement)xmlN;
                    itemId = curItem.GetAttribute("id").ToString();
                    itemName = curItem.GetAttribute("itemName").ToString();
                    itemNumber = curItem.GetAttribute("itemNumber").ToString();
                    itemPrice = curItem.GetAttribute("itemPrice").ToString();
                    itemDiscount = curItem.GetAttribute("itemDiscount").ToString();
                    itemImgPath = curItem.GetAttribute("itemImgPath").ToString();
                    

                    //����ȡ��ITEMд����ϣ��
                    int id = Convert.ToInt32(itemId);
                    int number = Convert.ToInt32(itemNumber);
                    double price = Convert.ToDouble(itemPrice);
                    double discount = Convert.ToDouble(itemDiscount);

                    ItemEntity Info = new ItemEntity(id,itemName,number,price,itemImgPath);
                    Info.Discount = discount;
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
                }
            }
        }
        #endregion

        #region ��ѯ���
        /// <summary>
        /// ��ѯָ����Ʒ���,ʹ��public CartCtrl(int id)���캯�����칺�ﳵ,
        /// </summary>
        /// <param name="curS">��Ʒ�����</param>
        /// <returns>boolֵ</returns>
        public bool curStorage(ref int curS)
        {
            ShopCartInfoDAL sc = new ShopCartInfoDAL();
            return sc.GetStorage(ref curS, curID);
        }
        #endregion

        #region �����Ʒ
        /// <summary>
        /// �����Ʒ��hashtable
        /// </summary>
        /// <param name="proId">��Ҫ��ӵ���ƷID</param>
        /// <returns>boolֵ</returns>
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

        #region ��ȡָ����Ʒʵ��
        /// <summary>
        /// ��hashtable�л�ȡָ����Ʒʵ��
        /// </summary>
        /// <param name="ID">��ƷID</param>
        /// <returns>��Ʒʵ�����</returns>
        public ItemEntity GetItem(int ID)
        {
            if (curCart.curDic.ContainsKey(ID))
            {
                return (ItemEntity)curCart.curDic[ID];
            }
            return null;
        }
        #endregion

        #region ��ȡ���ﳵ����Ʒ�б�(IList)
        /// <summary>
        /// ��ȡ���ﳵ��ȫ����Ʒ�б�
        /// </summary>
        /// <param name=""></param>
        /// <returns>��Ʒ�б�(IList)</returns>
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

        #region ��ȡ��Ʒ����
        /// <summary>
        /// ��ȡ���ﳵ����Ʒ����
        /// </summary>
        /// <param name=""></param>
        /// <returns>int ��Ʒ����</returns>
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

        #region ��ȡ���ﳵ����Ʒ�б�(ICollection)
        /// <summary>
        /// ��ȡ���ﳵ��ȫ����Ʒ�б�
        /// </summary>
        /// <param name=""></param>
        /// <returns>��Ʒ�б�(ICollection)</returns>
        public ICollection GetItems() 
        {
            return curCart.curDic.Values;
        }
        #endregion

        #region ��ȡ��Ʒ�ܼ۸�
        /// <summary>
        /// ��ȡ���ﳵ��ȫ����Ʒ�ܼ�
        /// </summary>
        /// <param name=""></param>
        /// <returns>double ��Ʒ�۸�</returns>
        public double GetTotalPrice() {
            double total = 0.0;
            foreach(ItemEntity e in curCart.curDic.Values){
                total += e.TotalPrice;
            }

            return total;
        }
        #endregion

        #region ��ʾ��Ʒ�ܼ۸�
        /// <summary>
        /// ������Ҹ�ʽ��ʾ�ܼ۸�
        /// </summary>
        /// <param name=""></param>
        /// <returns>String �۸�</returns>
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

        #region ��ȡ��ǰ��Ʒ��۸��ܼ�
        /// <summary>
        /// ��ǰ��Ʒ�۸�С��
        /// </summary>
        /// <param name=""></param>
        /// <returns>double �۸�С��</returns>
        public double GetItemPrice(int ID) {
            double itemPrice = 0.0;
            ItemEntity item = (ItemEntity)curCart.curDic[ID];
            itemPrice = item.Number * item.Price;
            return itemPrice;
        }
        #endregion

        #region �Ƴ���Ʒ
        /// <summary>
        /// �ӹ��ﳵ���Ƴ���ǰ��Ʒ
        /// </summary>
        /// <param name="ID">��ƷID</param>
        /// <returns>boolֵ</returns>
        public bool Remove(int ID)
        {
            if (curCart.curDic.ContainsKey(ID))
            {
                curCart.curDic.Remove(ID);
            }

            if (curCart.curUser != null && curCart.curUser.Length > 0)
            {
                return WriteToXML(curCart.curUser);
            }
            return SaveCookie();
        }
        #endregion

        #region ��չ��ﳵ
        /// <summary>
        /// ��չ��ﳵ��ȫ����Ʒ
        /// </summary>
        /// <param name=""></param>
        /// <returns>bool</returns>
        public bool RemoveCart()
        {
            String user = String.Empty;
            curCart.curDic.Clear();
            SaveCookie();
            
            if (curCart.curUser!=null&&curCart.curUser.Length>0) 
            {
                XmlDocument xmlD = new XmlDocument();
                XmlElement e = GetUserNode(xmlD,curCart.curUser);
                if (e == null) 
                {
                    return true;
                }
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

        #region �޸���Ʒ����
        /// <summary>
        /// �޸�ָ����Ʒ����
        /// </summary>
        /// <param name="ID">��ƷID</param>
        /// <param name="Number">Ŀ������</param>
        /// <returns></returns>
        public bool Edit(int ID, int Number)
        {
            if (curCart.curDic.ContainsKey(ID))
            {
                ItemEntity Info = (ItemEntity)curCart.curDic[ID];
                curCart.curDic.Remove(ID);
                Info.Number = Number;
                curCart.curDic.Add(ID, Info);

                if (curCart.curUser != null && curCart.curUser.Length > 0)
                {
                    return WriteToXML(curCart.curUser);
                }
                return SaveCookie();
            }
            return false;
        }
        #endregion

        #region ����COOKIE���ﳵ(δ��¼�û�)
        /// <summary>
        /// ��HASHTABLE������cookie
        /// </summary>
        /// <param></param>
        /// <returns>boolֵ</returns>
        public Boolean SaveCookie()
        {

            string s = string.Empty;
            ItemEntity Info;
            HttpCookie cookie;
            foreach (ItemEntity item in curCart.curDic.Values)
            {
                Info = item;
                s += Info.ID.ToString() + "|" + Info.Name + "|" + Info.Number.ToString() + "|" + Info.Price.ToString() + "|" + Info.Discount.ToString() + "|" + Info.ImgPath + "@";
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

        #region �����ﳵд��XML
        /// <summary>
        /// ��HASHTABLE���ݱ�����cookie
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <returns>boolֵ</returns>
        public Boolean WriteToXML(String userName)
        {
            string s = string.Empty;
            ItemEntity Info;
            String proId;
            String name;
            String number;
            String price;
            String imgPath;
            String discount;
            int userLv = 0;
            XmlDocument xmlD = new XmlDocument();

            UserScoreDAL getLv = new UserScoreDAL();
            Guid userId = (Guid)Membership.GetUser(userName).ProviderUserKey;
            if (!getLv.GetUserLv(userId, ref userLv))
            {
                return false;
            }
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
                //discount = Info.Discount.ToString();
                if (userLv == 0)
                {
                    discount = Info.Discount.ToString();
                }
                else
                {
                    discount = "0.9";
                }
                imgPath = Info.ImgPath;
               

                XmlElement xmlEle2 = xmlD.CreateElement("Item");

                xmlEle2.SetAttribute("id", proId);
                xmlEle2.SetAttribute("itemName", name);
                xmlEle2.SetAttribute("itemNumber", number);
                xmlEle2.SetAttribute("itemPrice", price);
                xmlEle2.SetAttribute("itemDiscount", discount);
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

        #region ��XML�ж�ȡ��Ӧ�û����
        /// <summary>
        /// �����û�����XML�ж�ȡ��Ӧ�ڵ�
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <param name="xmlD">xml�ĵ�����</param>
        /// <returns>XmlElement</returns>
        public XmlElement GetUserNode(XmlDocument xmlD, String userName) 
        {
            String FilePath = HttpContext.Current.Server.MapPath("UserCart.xml");

            try
            {
                xmlD.Load(FilePath);
            }
            catch (System.Exception e)
            {
                HttpContext.Current.Response.Write("<script>alert('��ȡ���ﳵʧ�ܣ������²�����');history.go(-1);</script>");
            }

            XmlElement xmlEle = (XmlElement)xmlD.SelectSingleNode("Users/User[@id='" + curCart.curUser + "']");
            return xmlEle;
        }

        #endregion
    }
    #endregion

}
