using System;

namespace MediTech.Model
{
    public class Chemist
    {
        public Chemist(string pEmail, string pName, DateTime pDob, string pMobileNo, string pUserName, string pPassword)
        {
            P_Email = pEmail;
            P_Name = pName;
            P_Dob = pDob;
            P_MobileNo = pMobileNo;
            P_UserName = pUserName;
            P_Password = pPassword;
        }

        public int P_Id { get; set; }
        public string P_Email { get; set; }
        public string P_Name { get; set; }
        public DateTime P_Dob { get; set; }
        public string P_MobileNo { get; set; }
        public string P_UserName { get; set; }
        public string P_Password { get; set; }
        
    }
}