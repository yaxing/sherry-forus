////��д�ߣ�������
////��  �ڣ�2009-11-25
////��  �ܣ��г�����ģ�������ҵ���߼�����Ҫ��װ��web��Ҫ�õ����ݱ�

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
        /// ����ǿ���͵�DataTable
        /// </summary>
        /// <param name="ageList"></param>
        /// <returns>����ǿ���͵�DataTable</returns>
        public Report.MemberReportDataTable MembersAgeGroupDT(List<AgeGap> ageList)
        {
            Report.MemberReportDataTable dt = new Report.MemberReportDataTable();


            //���ݻ�������Щlist��
            List<int> amountList = new List<int>();
            List<int> percentList = new List<int>();

            float sum = 0.0F;
            int num;
            //���������ܺ�
            using (MarketDecisionDAL mdd = new MarketDecisionDAL())
            {
                foreach (AgeGap gap in ageList)
                {
                    num = mdd.CountMembersAgeGroup(gap.SAge, gap.EAge);
                    amountList.Add(num);
                    sum += num;
                }
            }

            //����ٷֱ�
            foreach (int i in amountList)
            {
                if (sum == 0)
                    percentList.Add(0);
                else
                    percentList.Add(Convert.ToInt32((i/sum)*100));
            }
            //������ݱ�Datatable
            for (int i = 0; i < amountList.Count; i++)
            {
                Report.MemberReportRow r = dt.NewMemberReportRow();

                r.AgeGap = ageList[i].SAge + "�굽" + ageList[i].EAge + "��";
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
                    "�沿����",
                    "�ֲ�����",
                    "���廤��",
                    "�㷢����",
                    "�۲�����",
                    "��������",
                    "����",
                    "��ˮ",
                    "��ױ",
                    "�㾫/����/��ˮ",
                    "��������"
                };

        /// <summary>
        /// ����ǿ���͵�DataTable
        /// </summary>
        /// <param name="ageList"></param>
        /// <returns>����ǿ���͵�DataTable</returns>
        public Report.GoodsSalesReportDataTable GoodsSalesReportDT(List<int> timeList)
        {
            Report.GoodsSalesReportDataTable dt = new Report.GoodsSalesReportDataTable();


            //�����л���
            List<string> categoryList = new List<string>(categoryArray);
            List<int> phoneSalesList = new List<int>();
            List<int> shopSalesList = new List<int>();
            List<int> onlineSalesList = new List<int>();
            List<int> overallSalesList = new List<int>();
            List<int> overallPercentList = new List<int>();

            DateTime sDate = new DateTime(timeList[0], timeList[1], 1);
            DateTime eDate = new DateTime(timeList[2], timeList[3], 1);

            //����ÿһ�е�����
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


            //�����ܵİٷֱ�
            foreach (int i in onlineSalesList)
            {
                int num = sum==0 ? 0 : Convert.ToInt32(100*i/sum);
                overallPercentList.Add(num);
            }

            //װ��DataTable
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
        /// ����ǿ���͵�DataTable
        /// </summary>
        /// <param name="ageList"></param>
        /// <returns>����ǿ���͵�DataTable</returns>
        public Report.MemberSalesReportDataTable MemberSalesReportDT(List<AgeGap> ageList, List<int> timeList)
        {
            Report.MemberSalesReportDataTable dt = new Report.MemberSalesReportDataTable();


            DateTime startingDate = new DateTime(timeList[0], timeList[1], 1);
            DateTime endingDate = new DateTime(timeList[2], timeList[3], 1);

            //���ݻ�������Щlist��
            List<int> phoneSalesList = new List<int>();
            List<int> shopSalesList = new List<int>();
            List<int> onlineSalesList = new List<int>();
            List<int> overallSalesList = new List<int>();
            List<int> overallPercentList = new List<int>();

            //���ÿһ��
            using (MarketDecisionDAL mdd = new MarketDecisionDAL())

            {
                foreach (AgeGap gap in ageList)
                {
                    phoneSalesList.Add(mdd.MemberPhoneSalesAmount(gap.SAge, gap.EAge, startingDate, endingDate));
                    onlineSalesList.Add(mdd.MemberOnlineSalesAmount(gap.SAge, gap.EAge, startingDate, endingDate));
                    shopSalesList.Add(mdd.MemberShopSalesAmount(gap.SAge, gap.EAge, startingDate, endingDate));
                }
            }

            //���������۶�
            double sum = 0.0;
            for (int i = 0; i < ageList.Count; i++)
            {
                int num = phoneSalesList[i] + shopSalesList[i] + onlineSalesList[i];
                overallSalesList.Add(num);
                sum += num;
            }
            //����ٷֱ�
            for (int i = 0; i < ageList.Count; i++)
            {
                int num = sum == 0 ? 0 : Convert.ToInt32(overallSalesList[i]*100 / sum);
                overallPercentList.Add(num);
            }

            //������ݱ�Datatable,����ÿһ��
            for (int i = 0; i < ageList.Count; i++)
            {
                Report.MemberSalesReportRow r = dt.NewMemberSalesReportRow();
                r.AgeGap = ageList[i].SAge + "�굽" + ageList[i].EAge + "��";
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
                return startingAge + "�굽" + endingAge + "��";
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

        #region public �������� ������ʾ�����ÿһ��

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
        

        #region public �������� ������ʾ�����ÿһ��
        public string Title
        {
            get
            {
                return startingAge + "�굽" + endingAge + "��";
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

            #region �������Ĵ��ݹ���

            MarketDecisionDAL mdd = new MarketDecisionDAL();
            foreach (AgeGap gap in ageGaps)
            {
                MemberReportLine line;
                //line = new MemberReportLine(gap.SAge, gap.EAge, gap.EAge * gap.SAge);
                line = new MemberReportLine();
                line.startingAge = gap.SAge;
                line.endingAge = gap.EAge;
                //TODO ���ݿ�����ʧ�ܣ���ν������
                line.number = mdd.CountMembersAgeGroup(gap.SAge, gap.EAge);

                
                list.Add(line); 
            }

            mdd = null;
            

            //����ÿһ�аٷֱȵľ��������˲������÷ŵ����
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