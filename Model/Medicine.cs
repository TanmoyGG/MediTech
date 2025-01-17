using System;

namespace MediTech.Model
{
    public class Medicine
    {
        public Medicine(string mName, string mGroupName, string mType, decimal price, DateTime manuDate, DateTime expDate, int quantity)
        {
            M_Name = mName;
            M_GroupName = mGroupName;
            M_Type = mType;
            Price = price;
            ManuDate = manuDate;
            ExpDate = expDate;
            Quantity = quantity;
        }

        public int M_Id { get; set; }
        public string M_Name { get; set; }
        public string M_GroupName { get; set; }
        public string M_Type { get; set; }
        public decimal Price { get; set; }
        public DateTime ManuDate { get; set; }
        public DateTime ExpDate { get; set; }
        public int Quantity { get; set; }
        
        
    }
}