using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    [Serializable]
    public struct AgeGap
    {
        public Int32 sAge;
        public Int32 eAge;
    }

    public class MemberReportBLL
    {
        
        public List<MemberReportLine> GetMemberReportLines(List<AgeGap> ageGaps)
        {
            List<MemberReportLine> list = new List<MemberReportLine>();

            #region 检查参数的传递过程
            string s = "I got an ageGaps List with len of " + ageGaps.Count + "items: ";


            using (FileStream fst = new FileStream(@"g:\list.txt", FileMode.Create))
            {
                using (StreamWriter st = new StreamWriter(fst))
                {

                    foreach (AgeGap gap in ageGaps)
                    {
                        st.WriteLine(""+gap.sAge + " to "+gap.eAge);
                    }



                    


                    foreach (AgeGap gap in ageGaps)
                    {
                        MemberReportLine line;
                        line = new MemberReportLine(gap.sAge, gap.eAge, gap.eAge * gap.sAge);
                        list.Add(line);
                    }

                    int sum = 0;

                    foreach (MemberReportLine line in list)
                    {
                        sum += line.Number;
                    }

                    st.WriteLine("sum is " + sum);
                    foreach (MemberReportLine line in list)
                    {
                        line.setPercent(((double)line.Number) / (double)sum);
                    }

                    foreach (MemberReportLine line in list)
                    {
                        st.WriteLine("" + line.Title +"number: "+ line.Number +"percentage: "+ line.Percentage);
                    }
                }
            }

            #endregion

           
            return list;
        }
    }

    public class MemberReportLine
    {
        private int startingAge;
        private int endingAge;
        private int number;
        private double percentage;
        

        public void setPercent(double d)
        {
            percentage = d;
        }

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

        public string Percentage
        {
            get
            {
                return ""+percentage*100;
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
}
