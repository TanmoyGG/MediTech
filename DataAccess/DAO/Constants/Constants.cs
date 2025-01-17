using System.Security.AccessControl;

namespace MediTech.DataAccess.DAO.Constants {

    public static class AdminQueries {

        public const string GET_ADMIN_BY_ID = "SELECT * FROM Admin WHERE A_Id = @A_Id";

        public const string GET_ADMIN_BY_NAME = "SELECT * FROM Admin WHERE A_Name = @A_Name"; 

        public const string GET_ADMIN_BY_USERNAME = "SELECT * FROM Admin WHERE A_UserName = @A_UserName"; 

        public const string GET_ADMIN_BY_EMAIL = "SELECT * FROM Admin WHERE A_Email = @A_Email"; 

        public const string GET_ADMINS_BY_MOBILE_NO = "SELECT * FROM Admin WHERE A_MobileNo = @A_MobileNo"; 

        public const string INSERT_ADMIN = "INSERT INTO Admin (A_Email, A_Name, A_Dob, A_MobileNo, A_UserName, A_Password) VALUES (@A_Email, @A_Name, @A_Dob, @A_MobileNo, @A_UserName, @A_Password)";

        public const string UPDATE_ADMIN = "UPDATE Admin SET A_Email = @A_Email, A_Name = @A_Name, A_Dob = @A_Dob, A_MobileNo = @A_MobileNo, A_UserName = @A_UserName, A_Password = @A_Password WHERE A_Id = @A_Id";

        public const string DELETE_ADMIN = "DELETE FROM Admin WHERE A_Id = @A_Id";

        public const string COUNT_TOTAL_ADMINS = "SELECT COUNT(*) FROM Admin";

        public const string GET_ADMIN_BY_USERNAME_OR_ID_OR_NAME_OR_EMAIL_OR_MOBILE_NO = "SELECT * FROM Admin WHERE A_UserName = @A_UserName OR A_Id = @A_Id OR A_Name = @A_Name OR A_Email = @A_Email OR A_MobileNo = @A_MobileNo";

    }

    public static class PharmacistQueries {

        public const string GET_PHARMACIST_BY_ID = "SELECT * FROM Pharmacist WHERE P_Id = @P_Id";

        public const string GET_PHARMACIST_BY_NAME = "SELECT * FROM Pharmacist WHERE P_Name = @P_Name"; 

        public const string GET_PHARMACIST_BY_USERNAME = "SELECT * FROM Pharmacist WHERE P_UserName = @P_UserName"; 

        public const string GET_PHARMACIST_BY_EMAIL = "SELECT * FROM Pharmacist WHERE P_Email = @P_Email"; 

        public const string GET_PHARMACISTS_BY_MOBILE_NO = "SELECT * FROM Pharmacist WHERE P_MobileNo = @P_MobileNo"; 

        public const string INSERT_PHARMACIST = "INSERT INTO Pharmacist (P_Email, P_Name, P_Dob, P_MobileNo, P_UserName, P_Password) VALUES (@P_Email, @P_Name, @P_Dob, @P_MobileNo, @P_UserName, @P_Password)";

        public const string UPDATE_PHARMACIST = "UPDATE Pharmacist SET P_Email = @P_Email, P_Name = @P_Name, P_Dob = @P_Dob, P_MobileNo = @P_MobileNo, P_UserName = @P_UserName, P_Password = @P_Password WHERE P_Id = @P_Id";

        public const string DELETE_PHARMACIST = "DELETE FROM Pharmacist WHERE P_Id = @P_Id";

        public const string COUNT_TOTAL_PHARMACISTS = "SELECT COUNT(*) FROM Pharmacist";

        public const string GET_PHARMACIST_BY_USERNAME_OR_ID_OR_NAME_OR_EMAIL_OR_MOBILE_NO = "SELECT * FROM Pharmacist WHERE P_UserName = @P_UserName OR P_Id = @P_Id OR P_Name = @P_Name OR P_Email = @P_Email OR P_MobileNo = @P_MobileNo";

    }

    public static class MedicineQueries {

        public const string GET_MEDICINE_BY_ID = "SELECT * FROM Medicine WHERE M_Id = @M_Id";

        public const string GET_MEDICINE_BY_NAME = "SELECT * FROM Medicine WHERE M_Name = @M_Name"; 

        public const string GET_MEDICINES_BY_GROUP_NAME = "SELECT * FROM Medicine WHERE M_GroupName = @M_GroupName"; 

        public const string GET_ALL_MEDICINES = "SELECT * FROM Medicine";

        public const string GET_EXPIRED_MEDICINES = "SELECT * FROM Medicine WHERE ExpDate < GETDATE()";

        public const string GET_VALID_MEDICINES = "SELECT * FROM Medicine WHERE ExpDate > GETDATE()";

        public const string GET_MEDICINES_BY_DATE_RANGE = "SELECT * FROM Medicine WHERE ManuDate BETWEEN @StartDate AND @EndDate";

        public const string GET_MEDICINES_BY_PRICE_RANGE = "SELECT * FROM Medicine WHERE Price BETWEEN @MinPrice AND @MaxPrice";

        public const string GET_LOW_STOCK_MEDICINES = "SELECT * FROM Medicine WHERE Quantity <= @Threshold";

        public const string GET_MEDICINES_CLOSE_TO_EXPIRY = "SELECT * FROM Medicine WHERE ExpDate BETWEEN GETDATE() AND @ExpiryDate";

        public const string INSERT_MEDICINE = "INSERT INTO Medicine (M_Name, M_GroupName, M_Type, Price, ManuDate, ExpDate, Quantity) VALUES (@M_Name, @M_GroupName, @M_Type, @Price, @ManuDate, @ExpDate, @Quantity)";

        public const string UPDATE_MEDICINE = "UPDATE Medicine SET M_Name = @M_Name, M_GroupName = @M_GroupName, M_Type = @M_Type, Price = @Price, ManuDate = @ManuDate, ExpDate = @ExpDate, Quantity = @Quantity WHERE M_Id = @M_Id";

        public const string DELETE_MEDICINE = "DELETE FROM Medicine WHERE M_Id = @M_Id";

        public const string COUNT_TOTAL_MEDICINES = "SELECT COUNT(*) FROM Medicine";

        public const string GET_MEDICINE_BY_NAME_OR_ID_OR_GROUP_NAME = "SELECT * FROM Medicine WHERE M_Name = @M_Name OR M_Id = @M_Id OR M_GroupName = @M_GroupName";

        public const string GET_MEDICINE_BY_PARTIAL_NAME_OR_PARTIAL_ID_OR_PARTIAL_GROUP_NAME = "SELECT * FROM Medicine WHERE M_Name LIKE '%' + @M_Name + '%' OR CAST(M_Id AS VARCHAR) LIKE '%' + @M_Id + '%' OR M_GroupName LIKE '%' + @M_GroupName + '%'"; // Retained for partial matching

    }

    public static class SalesReportQueries {

        public const string GET_SALES_REPORT_BY_ID = "SELECT * FROM SalesReport WHERE Report_Id = @Report_Id";

        public const string GET_SALES_REPORT_BY_DATE = "SELECT * FROM SalesReport WHERE ReportDateTime BETWEEN @StartDate AND @EndDate";

        public const string GET_SALES_REPORT_BY_MEDICINE_ID = "SELECT * FROM SalesReport WHERE M_Id = @M_Id";

        public const string GET_SALES_REPORT_BY_MEDICINE_NAME = "SELECT * FROM SalesReport WHERE M_Name = @M_Name"; 

        public const string INSERT_SALES_REPORT = "INSERT INTO SalesReport (M_Id, M_Name, Price, P_Name) VALUES (@M_Id, @M_Name, @Price, @P_Name)";

        public const string COUNT_TOTAL_SALES_REPORTS = "SELECT COUNT(*) FROM SalesReport";

    }

    public static class OTP
    {
        public const string GET_OTP_BY_EMAIL = "SELECT * FROM OTP WHERE Email = @Email";
        public const string INSERT_OTP = "INSERT INTO OTP (Email, OTP, OTP_Gen_Time, OTP_Exp_Time) VALUES (@Email, @OTP, @OTP_Gen_Time, DATEADD(MINUTE, 5, @OTP_Gen_Time))";
        public const string DELETE_OTP = "DELETE FROM OTP WHERE Email = @Email";
        
    }
}
