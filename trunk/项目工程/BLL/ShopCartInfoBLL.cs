using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;

namespace BLL
{

    #region ���ﳵ��
    public class Cart
    {
        private Hashtable dic;
        bool cartExsisted;
        String cartValue;

        #region ���칺�ﳵ
        public Cart()
        {
            cartExsisted = false;
            cartValue = String.Empty;
            dic = new Hashtable();
            if (HttpContext.Current.Request.Cookies["Cart"] != null)
            {
                cartExsisted = true;
                cartValue = HttpContext.Current.Request.Cookies["Cart"].Value;
            }

            if(cartExsisted)
            {
                String val = cartValue;
                ItemEntity Info;
                String[] temp = val.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (String item in temp)
                {
                    String[] temp2 = item.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    Info = new ItemEntity(Convert.ToInt32(temp2[0]), temp2[1].ToString(), Convert.ToInt32(temp2[2]), Convert.ToInt32(temp2[3]));
                    dic.Add(Info.id, Info);
                }
            }
        }
        #endregion

        #region �����Ʒ
        public void Add(int proId)
        {
            ItemEntity Info = new ItemEntity(proId, "����ϣ�й���շ۵�Һ", 1, 300);
            if (dic.ContainsKey(Info.id))
            {
                ItemEntity curNum = (ItemEntity)dic[Info.id];
                dic.Remove(Info.id);
                Info.number = curNum.number + 1;
                dic.Add(Info.id, Info);
                SaveCookie();
            }
            else
            {
                dic.Add(Info.id, Info);
                SaveCookie();
            }
        }
        #endregion

        #region ��ȡָ����Ʒʵ��
        public ItemEntity GetItem(int ID)
        {
            if (dic.ContainsKey(ID))
            {
                return (ItemEntity)dic[ID];
            }
            return null;
        }
        #endregion

        #region ��ȡ���ﳵ����Ʒ�б�(IList)
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

        #region ��ȡ��Ʒ����
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

        #region ��ȡ���ﳵ����Ʒ�б�(ICollection)
        public ICollection GetItems() 
        {
            return dic.Values;
        }
        #endregion

        #region ��ȡ��Ʒ�ܼ۸�
        public double GetTotalPrice() {
            double total = 0.0;
            foreach(ItemEntity e in dic.Values){
                total += e.Number * e.Price;
            }

            return total;
        }
        #endregion

        #region ��ʾ��Ʒ�ܼ۸�
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

        #region ��ȡ��ǰ��Ʒ��۸��ܼ�
        public double GetItemPrice(int ID) {
            double itemPrice = 0.0;
            ItemEntity item = (ItemEntity)dic[ID];
            itemPrice = item.Number * item.Price;
            return itemPrice;
        }
        #endregion

        #region �Ƴ���Ʒ
        public void Remove(int ID)
        {
            if (dic.ContainsKey(ID))
            {
                dic.Remove(ID);
            }
            SaveCookie();
        }
        #endregion

        #region ���COOKIE���ﳵ
        public void RemoveCart()
        {
            dic.Clear();
            SaveCookie();
        }
        #endregion

        #region �޸���Ʒ����
        public void Edit(int ID, int Number)
        {
            if (dic.ContainsKey(ID))
            {
                ItemEntity Info = (ItemEntity)dic[ID];
                dic.Remove(ID);
                Info.number = Number;
                dic.Add(ID, Info);
                SaveCookie();
            }
        }
        #endregion

        #region ����COOKIE���ﳵ
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

        #region ��COOKIE���ﳵд��XML
        public Boolean WriteToXML(String FilePath,String userId)
        {
            string s = string.Empty;
            ItemEntity Info;
            HttpCookie cookie;
            String proId;
            String name;
            String number;
            String price;
            XmlDocument xmlD = new XmlDocument();
            
            try
            {
                xmlD.Load(FilePath);
            }
            catch (System.Exception e)
            {
                return false;
            }

            XmlNodeList xmlNL = xmlD.SelectNodes("//users[@id="+userId+"]");
            XmlElement xmlEle = null;

            foreach (XmlNode xmlN in xmlNL)
            {
                //if (xmlN.Name == "User"&&xmlN.Attributes["id"].Value == userId)
                //{
                //    xmlEle = (XmlElement)xmlN;
                //    xmlEle.RemoveAll();
                //    break;
                //}
                xmlEle = (XmlElement)xmlN;
                xmlEle.RemoveAll();
                break;
            }

            if (xmlEle == null)
            {
                xmlEle = xmlD.CreateElement("User");
                xmlEle.SetAttribute("id",userId);
            }

            foreach (ItemEntity item in dic.Values)
            {
                Info = item;
                proId = Info.id.ToString();
                name = Info.name;
                number = Info.number.ToString();
                price = String.Format("{0:C}",Info.price);

                XmlElement xmlEle2 = xmlD.CreateElement("Item");
                xmlEle2.InnerXml = "<ItemId></ItemId><ItemName></ItemName><ItemNumber></ItemNumber><ItemPrice></ItemPrice>";

                xmlEle2["ItemId"].InnerText = proId;
                xmlEle2["ItemName"].InnerText = name;
                xmlEle2["ItemNumber"].InnerText = number;
                xmlEle2["ItemPrice"].InnerText = String.Format("{0:C}", price);
                xmlEle.AppendChild(xmlEle2);
            }

            xmlD.DocumentElement.AppendChild(xmlEle);
            xmlD.PreserveWhitespace = false;
            try
            {
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
    }
    #endregion

    #region ��Ʒ��Ϣ��
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
