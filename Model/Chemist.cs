using System;
using System.Collections.Generic;

namespace MediTech.Model
{
    public class Chemist
    {
        public Chemist()
        {
        }

        public Chemist(string pEmail, string pName, DateTime pDob, string pMobileNo, string pUserName, string pPassword)
        {
            P_Email = pEmail;
            P_Name = pName;
            P_Dob = pDob;
            P_MobileNo = pMobileNo;
            P_UserName = pUserName;
            P_Password = pPassword;
        }

        public static IEqualityComparer<Chemist> PIdPEmailPUserNameComparer { get; } =
            new PIdPEmailPUserNameEqualityComparer();

        public int P_Id { get; set; }
        public string P_Email { get; set; }
        public string P_Name { get; set; }
        public DateTime P_Dob { get; set; }
        public string P_MobileNo { get; set; }
        public string P_UserName { get; set; }
        public string P_Password { get; set; }

        protected bool Equals(Chemist other)
        {
            return P_Id == other.P_Id && P_Email == other.P_Email && P_UserName == other.P_UserName;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Chemist)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = P_Id;
                hashCode = (hashCode * 397) ^ (P_Email != null ? P_Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (P_UserName != null ? P_UserName.GetHashCode() : 0);
                return hashCode;
            }
        }

        private sealed class PIdPEmailPUserNameEqualityComparer : IEqualityComparer<Chemist>
        {
            public bool Equals(Chemist x, Chemist y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (x is null) return false;
                if (y is null) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.P_Id == y.P_Id && x.P_Email == y.P_Email && x.P_UserName == y.P_UserName;
            }

            public int GetHashCode(Chemist obj)
            {
                unchecked
                {
                    var hashCode = obj.P_Id;
                    hashCode = (hashCode * 397) ^ (obj.P_Email != null ? obj.P_Email.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.P_UserName != null ? obj.P_UserName.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }
    }
}