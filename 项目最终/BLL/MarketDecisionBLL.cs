////编写者：金哲宇
////日  期：2009-11-25
////功  能：市场决策模块所需的业务逻辑，主要是装配web蹭要用的数据表

using System;
using System.Collections.Generic;
using DAL;

namespace BLL
{
    [Serializable]
    public struct AgeGap
    {
        public Int32 EAge;
        public Int32 SAge;
    }

    #region MemberReportClasses

    public class MemberReportBLL
    {
        /// <summary>
        /// 返回强类型的DataTable
        /// </summary>
        /// <param name="ageList"></param>
        /// <returns>返回强类型的DataTable</returns>
        public Report.MemberReportDataTable MembersAgeGroupDT(List<AgeGap> ageList)
        {
            Report.MemberReportDataTable dt = new Report.MemberReportDataTable();


            //数据缓存在这些list中
            List<int> amountList = new List<int>();
            List<int> percentList = new List<int>();

            float sum = 0.0F;
            int num;
            //计算人数总和
            using (MarketDecisionDAL mdd = new MarketDecisionDAL())
            {
                foreach (AgeGap gap in ageList)
                {
                    num = mdd.CountMembersAgeGroup(gap.SAge, gap.EAge);
                    amountList.Add(num);
                    sum += num;
                }
            }

            //计算百分比
            foreach (int i in amountList)
            {
                if (sum == 0)
                    percentList.Add(0);
                else
                    percentList.Add(Convert.ToInt32((i/sum)*100));
            }
            //填充数据表Datatable
            for (int i = 0; i < amountList.Count; i++)
            {
                Report.MemberReportRow r = dt.NewMemberReportRow();

                r.AgeGap = ageList[i].SAge + "岁到" + ageList[i].EAge + "岁";
                r.Percent = percentList[i];
                r.Amount = amountList[i];
                dt.Rows.Add(r);
            }

            return dt;
        }

    }

    #endregion

    #region GoodsSalesReportClasses

    public class GoodsSalesReportBLL
    {
        public static string[] categoryArray =
            new string[]
                {
                    "面部护理",
                    "手部护理",
                    "身体护理",
                    "秀发护理",
                    "眼部护理",
                    "颈部护理",
                    "唇部",
                    "香水",
                    "彩妆",
                    "香精/精油/花水",
                    "瘦身美体"
                };

        /// <summary>
        /// 返回强类型的DataTable
        /// </summary>
        /// <param name="ageList"></param>
        /// <returns>返回强类型的DataTable</returns>
        public Report.GoodsSalesReportDataTable GoodsSalesReportDT(List<int> timeList)
        {
            Report.GoodsSalesReportDataTable dt = new Report.GoodsSalesReportDataTable();


            //数据列缓存
            List<string> categoryList = new List<string>(categoryArray);
            List<int> phoneSalesList = new List<int>();
            List<int> shopSalesList = new List<int>();
            List<int> onlineSalesList = new List<int>();
            List<int> overallSalesList = new List<int>();
            List<int> overallPercentList = new List<int>();

            DateTime sDate = new DateTime(timeList[0], timeList[1], 1);
            DateTime eDate = new DateTime(timeList[2], timeList[3], 1);

            //载入每一列的数据
            int shop, phone, online;
            double sum = 0.0;
            using (MarketDecisionDAL mdd = new MarketDecisionDAL())
            {
                foreach (string cate in categoryList)
                {
                    online = mdd.GoodsOnlineSalesAmount(sDate, eDate, cate);
                    phone = mdd.GoodsPhoneSalesAmount(sDate, eDate, cate);
                    shop = mdd.GoodsShopSalesAmount(sDate, eDate, cate);

                    phoneSalesList.Add(phone);
                    onlineSalesList.Add(online);
                    shopSalesList.Add(shop);
                    overallSalesList.Add(online + shop + phone);

                    sum += online + shop + phone;
                }
            }


            //计算总的百分比
            foreach (int i in onlineSalesList)
            {
                int num = sum==0 ? 0 : Convert.ToInt32(100*i/sum);
                overallPercentList.Add(num);
            }

            //装配DataTable
            for (int i = 0; i < categoryList.Count; i++)
            {
                Report.GoodsSalesReportRow r = dt.NewGoodsSalesReportRow();
                r.GoodsCategory = categoryList[i];
                r.ShopSalesAmount = shopSalesList[i];
                r.OnlineSalesAmount = onlineSalesList[i];
                r.PhoneSalesAmount = phoneSalesList[i];
                r.OverallSalesAmount = overallSalesList[i];
                r.OverallPercent = overallSalesList[i];

                dt.Rows.Add(r);
            }


            return dt;
        }
    }

    #endregion

    #region MemberSalesReportClasses

    public class MemberSalesReportBLL
    {

        /// <summary>
        /// 返回强类型的DataTable
        /// </summary>
        /// <param name="ageList"></param>
        /// <returns>返回强类型的DataTable</returns>
        public Report.MemberSalesReportDataTable MemberSalesReportDT(List<AgeGap> ageList, List<int> timeList)
        {
            Report.MemberSalesReportDataTable dt = new Report.MemberSalesReportDataTable();


            DateTime startingDate = new DateTime(timeList[0], timeList[1], 1);
            DateTime endingDate = new DateTime(timeList[2], timeList[3], 1);

            //数据缓存在这些list中
            List<int> phoneSalesList = new List<int>();
            List<int> shopSalesList = new List<int>();
            List<int> onlineSalesList = new List<int>();
            List<int> overallSalesList = new List<int>();
            List<int> overallPercentList = new List<int>();

            //填充每一列
            using (MarketDecisionDAL mdd = new MarketDecisionDAL())

            {
                foreach (AgeGap gap in ageList)
                {
                    phoneSalesList.Add(mdd.MemberPhoneSalesAmount(gap.SAge, gap.EAge, startingDate, endingDate));
                    onlineSalesList.Add(mdd.MemberOnlineSalesAmount(gap.SAge, gap.EAge, startingDate, endingDate));
                    shopSalesList.Add(mdd.MemberShopSalesAmount(gap.SAge, gap.EAge, startingDate, endingDate));
                }
            }

            //计算总销售额
            double sum = 0.0;
            for (int i = 0; i < ageList.Count; i++)
            {
                int num = phoneSalesList[i] + shopSalesList[i] + onlineSalesList[i];
                overallSalesList.Add(num);
                sum += num;
            }
            //计算百分比
            for (int i = 0; i < ageList.Count; i++)
            {
                int num = sum == 0 ? 0 : Convert.ToInt32(overallSalesList[i]*100 / sum);
                overallPercentList.Add(num);
            }

            //填充数据表Datatable,遍历每一列
            for (int i = 0; i < ageList.Count; i++)
            {
                Report.MemberSalesReportRow r = dt.NewMemberSalesReportRow();
                r.AgeGap = ageList[i].SAge + "岁到" + ageList[i].EAge + "岁";
                r.OverallSalesAmount = overallSalesList[i];
                r.OverallPercent = overallPercentList[i];
                r.OnlineSalesAmount = onlineSalesList[i];
                r.PhoneSalesAmount = phoneSalesList[i];
                r.ShopSalesAmount = shopSalesList[i];

                dt.Rows.Add(r);
            }

            return dt;
        }
    }

    #endregion

    /*
    public class MemberReportLine
    {
        public int startingAge;
        public int endingAge;
        public int number;
        public double percentage;
        

    

        public string Title
        {
            get
            {
                return startingAge + "岁到" + endingAge + "岁";
            }
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public int Percentage
        {
            get
            {                
                return Convert.ToInt32(percentage*100);
            }
        }

        public MemberReportLine(int startingAge, int endingAge, int number)
        {
            this.startingAge = startingAge;
            this.endingAge = endingAge;
            this.number = number;
        }

        public MemberReportLine()
        {
        }
    }
    */

    /*
    public class GoodsSalesReportLine
    {
        public string goodsCategory;
        public int overallSalesAmount;
        public double overallSalesPercentage;
        public double phoneSalesAmount;
        public double shopSalesAmount;
        public double onlineSalesAmount;

        #region public 各种属性 用于显示报表的每一行

        public string GoodsCategory
        {
            get
            {
                return goodsCategory;
            }
        }

        public int OverallSalesAmount
        {
            get
            {
                return overallSalesAmount;
            }
        }
        public double OverallSalesPercentage
        {
            get
            {
                return Convert.ToDouble(string.Format("{0:0.0}", overallSalesPercentage));
            }

        }
        public int PhoneSalesAmount
        {
            get
            {
                return Convert.ToInt32(phoneSalesAmount);
            }
        }

        public int ShopSalesAmount
        {
            get
            {
                return Convert.ToInt32(shopSalesAmount);
            }

        }

        public int OnlineSalesAmount
        {
            get
            {
                return Convert.ToInt32(onlineSalesAmount);
            }
        }

        #endregion
    }
    */

    /*
    public class MemberSalesReportLine
    {
        public int startingAge;
        public int endingAge;
        public double overallSalesAmount;
        public double overallSalesPercentage;
        public double phoneSalesAmount;
        public double shopSalesAmount;
        public double onlineSalesAmount;
        

        #region public 各种属性 用于显示报表的每一行
        public string Title
        {
            get
            {
                return startingAge + "岁到" + endingAge + "岁";
            }
        }

        public int OverallSalesAmount
        {
            get
            {
                return Convert.ToInt32(overallSalesAmount);
            }
        }

        public double OverallSalesPercentage
        {
            get
            {                
                return Convert.ToDouble(string.Format("{0:0.0}", overallSalesPercentage));
            }

        }
        public int PhoneSalesAmount
        {
            get
            {
                return Convert.ToInt32(phoneSalesAmount);
            }
        }

        public int ShopSalesAmount
        {
            get
            {
                return Convert.ToInt32(shopSalesAmount);
            }
            
        }

        public int OnlineSalesAmount
        {
            get
            {
                return Convert.ToInt32(onlineSalesAmount);
            }
        }

        #endregion

        public MemberSalesReportLine(){

        }


    }
    */

    /**
        public List<MemberReportLine> GetMemberReportLines(List<AgeGap> ageGaps)
        {
            List<MemberReportLine> list = new List<MemberReportLine>();

            #region 检查参数的传递过程

            MarketDecisionDAL mdd = new MarketDecisionDAL();
            foreach (AgeGap gap in ageGaps)
            {
                MemberReportLine line;
                //line = new MemberReportLine(gap.SAge, gap.EAge, gap.EAge * gap.SAge);
                line = new MemberReportLine();
                line.startingAge = gap.SAge;
                line.endingAge = gap.EAge;
                //TODO 数据库连接失败，如何解决？？
                line.number = mdd.CountMembersAgeGroup(gap.SAge, gap.EAge);

                
                list.Add(line); 
            }

            mdd = null;
            

            //计算每一列百分比的具体数，此步骤必须得放到最后
            int sum = 0;
            foreach (MemberReportLine line in list)
            {
                sum += line.Number;
            }
            foreach (MemberReportLine line in list)
            {
                line.percentage=((double)line.Number) / (double)sum;
            }
     
            #endregion

           
            return list;
        }

        */
}