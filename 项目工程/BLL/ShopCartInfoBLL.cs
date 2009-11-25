using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BLL
{

    #region cookie购物车

    #region 购物车类
    public class Cart
    {
        private Hashtable dic;

        #region 构造购物车
        public Cart(bool cartExsisted, String cartValue)
        {
            //if (System.Web.HttpContext.Current.Request.Cookies["Cart"] != null)
            if(cartExsisted)
            {
                dic = new Hashtable();
                //string val = System.Web.HttpContext.Current.Request.Cookies["Cart"].Value;
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
            else
            {
                dic = new Hashtable();
            }
        }
        #endregion

        #region 添加商品
        public Hashtable Add(ItemEntity Info)
        {
            if (dic.ContainsKey(Info.id))
            {
                ItemEntity curNum = (ItemEntity)dic[Info.id];
                dic.Remove(Info.id);
                Info.number = curNum.number + 1;
                dic.Add(Info.id, Info);
                //SaveCookie();
            }
            else
            {
                dic.Add(Info.id, Info);
                //SaveCookie();
            }
            return dic;

        }
        #endregion

        #region 获取具体商品信息
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

        #region 获取购物车内商品列表(ICollection)
        public ICollection GetItems() 
        {
            return dic.Values;
        }
        #endregion

        #region 移除商品
        public Hashtable Remove(int ID)
        {
            if (dic.ContainsKey(ID))
            {
                dic.Remove(ID);
            }
            //SaveCookie();
            return dic;
        }
        #endregion

        #region 修改商品
        public Hashtable Edit(int ID, int Number)
        {
            if (dic.ContainsKey(ID))
            {
                ItemEntity Info = (ItemEntity)dic[ID];
                dic.Remove(ID);
                Info.number = Number;
                dic.Add(ID, Info);
                //SaveCookie();
                return dic;
            }
            return null;
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

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
    #endregion
    #endregion
}
