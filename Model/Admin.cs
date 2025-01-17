using System;
using System.Collections.Generic;

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

        public static IEqualityComparer<Admin> AIdAEmailAUserNameComparer { get; } =
            new AIdAEmailAUserNameEqualityComparer();

        public int A_Id { get; set; }
        public string A_Email { get; set; }
        public string A_Password { get; set; }
        public string A_Name { get; set; }
        public DateTime A_Dob { get; set; }
        public string A_MobileNo { get; set; }
        public string A_UserName { get; set; }

        protected bool Equals(Admin other)
        {
            return A_Id == other.A_Id && A_Email == other.A_Email && A_UserName == other.A_UserName;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Admin)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = A_Id;
                hashCode = (hashCode * 397) ^ (A_Email != null ? A_Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (A_UserName != null ? A_UserName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private sealed class AIdAEmailAUserNameEqualityComparer : IEqualityComparer<Admin>
        {
            public bool Equals(Admin x, Admin y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.A_Id == y.A_Id && x.A_Email == y.A_Email && x.A_UserName == y.A_UserName;
            }

            public int GetHashCode(Admin obj)
            {
                unchecked
                {
                    var hashCode = obj.A_Id;
                    hashCode = (hashCode * 397) ^ (obj.A_Email != null ? obj.A_Email.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.A_UserName != null ? obj.A_UserName.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
    }
}