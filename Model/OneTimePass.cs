using System;

namespace MediTech.Model
{
    public class OneTimePass
    {
        public OneTimePass(string email, int otp, DateTime otpGenTime, DateTime otpExpTime)
        {
            OTP_Exp_Time = otpExpTime;
            OTP_Gen_Time = otpGenTime;
            OTP = otp;
            Email = email;
        }

        public int OTP { get; set; }
        public string Email { get; set; }
        public DateTime OTP_Gen_Time { get; set; }
        public DateTime OTP_Exp_Time { get; set; }
    }
}