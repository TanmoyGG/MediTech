using System;

namespace MediTech.Model
{
    public class SalesReport
    {
        public SalesReport()
        {
        }

        public SalesReport(DateTime reportDateTime, int mId, string mName, decimal price, string pName)
        {
            ReportDateTime = reportDateTime;
            M_Id = mId;
            M_Name = mName;
            Price = price;
            P_Name = pName;
        }

        public int Report_Id { get; set; }
        public DateTime ReportDateTime { get; set; }
        public int M_Id { get; set; }
        public string M_Name { get; set; }
        public decimal Price { get; set; }
        public string P_Name { get; set; }
    }
}