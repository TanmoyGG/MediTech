using System;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.DataAccess.Controller
{
    public class OneTimePassController
    {
        public class OTPController
        {
            private readonly IOTPDAO _otpDAO;

            public OTPController(IOTPDAO otpDAO)
            {
                _otpDAO = otpDAO;
            }

            public OneTimePass GetOTP(string email)
            {
                return _otpDAO.GetOTPByEmail(email);
            }

            public void GenerateOTP(string email, int otp)
            {
                DateTime now = DateTime.Now;
                OneTimePass oneTimePass = new OneTimePass(email, otp, now, now.AddMinutes(5));
                _otpDAO.InsertOTP(oneTimePass);
            }

            public void RemoveOTP(string email)
            {
                _otpDAO.DeleteOTP(email);
            }
        }
    }
}