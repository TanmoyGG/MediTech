using System.Data.SqlClient;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public class OTPDAOImpl : IOTPDAO
    {
        private readonly string _connectionString;

        public OTPDAOImpl(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OneTimePass GetOTPByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Constants.OTP.GET_OTP_BY_EMAIL, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToOneTimePass(reader);
                        }
                    }
                }
            }
            return null;
        }

        public void InsertOTP(OneTimePass otp)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Constants.OTP.INSERT_OTP, connection))
                {
                    command.Parameters.AddWithValue("@Email", otp.Email);
                    command.Parameters.AddWithValue("@OTP", otp.OTP);
                    command.Parameters.AddWithValue("@OTP_Gen_Time", otp.OTP_Gen_Time);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOTP(string email)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Constants.OTP.DELETE_OTP, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }
        }

        private OneTimePass MapToOneTimePass(SqlDataReader reader)
        {
            return new OneTimePass(
                email: reader.GetString(reader.GetOrdinal("Email")),
                otp: reader.GetInt32(reader.GetOrdinal("OTP")),
                otpGenTime: reader.GetDateTime(reader.GetOrdinal("OTP_Gen_Time")),
                otpExpTime: reader.GetDateTime(reader.GetOrdinal("OTP_Exp_Time"))
            );
        }
    }

   
}
