using System;

namespace MediTech.Model
{
    public class Admin
    {
        public Admin(string aEmail, string aPassword, string aName, DateTime aDob, string aMobileNo, string aUserName)
        {
            A_Email = aEmail;
            A_Password = aPassword;
            A_Name = aName;
            A_Dob = aDob;
            A_MobileNo = aMobileNo;
            A_UserName = aUserName;
        }

        public Admin()
        {
            
        }

        public int A_Id { get; set; }
        public string A_Email { get; set; }
        public string A_Password { get; set; }
        public string A_Name { get; set; }
        public DateTime A_Dob { get; set; }
        public string A_MobileNo { get; set; }
        public string A_UserName { get; set; }
    }
}