using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MediTech.DataAccess.DAO.Constants;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public class AdminDaoImpl : IAdminDAO
    {
        public Admin GetAdminById(int id)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.GET_ADMIN_BY_ID, connection))
                {
                    command.Parameters.AddWithValue("@A_Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToAdmin(reader) : null;
                    }
                }
            });
        }

        public Admin GetAdminByName(string name)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.GET_ADMIN_BY_NAME, connection))
                {
                    command.Parameters.AddWithValue("@A_Name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToAdmin(reader) : null;
                    }
                }
            });
        }

        public Admin GetAdminByUsername(string username)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.GET_ADMIN_BY_USERNAME, connection))
                {
                    command.Parameters.AddWithValue("@A_UserName", username);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToAdmin(reader) : null;
                    }
                }
            });
        }

        public Admin GetAdminByEmail(string email)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.GET_ADMIN_BY_EMAIL, connection))
                {
                    command.Parameters.AddWithValue("@A_Email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToAdmin(reader) : null;
                    }
                }
            });
        }

        public Admin GetAdminByMobileNo(string mobileNo)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.GET_ADMINS_BY_MOBILE_NO, connection))
                {
                    command.Parameters.AddWithValue("@A_MobileNo", mobileNo);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToAdmin(reader) : null;
                    }
                }
            });
        }

        public void InsertAdmin(Admin admin)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.INSERT_ADMIN, connection))
                {
                    command.Parameters.AddWithValue("@A_Email", admin.A_Email);
                    command.Parameters.AddWithValue("@A_Name", admin.A_Name);
                    command.Parameters.AddWithValue("@A_Dob", admin.A_Dob);
                    command.Parameters.AddWithValue("@A_MobileNo", admin.A_MobileNo);
                    command.Parameters.AddWithValue("@A_UserName", admin.A_UserName);
                    command.Parameters.AddWithValue("@A_Password", admin.A_Password);
                    command.ExecuteNonQuery();
                }
            });
        }

        public void UpdateAdmin(Admin admin)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.UPDATE_ADMIN, connection))
                {
                    command.Parameters.AddWithValue("@A_Id", admin.A_Id);
                    command.Parameters.AddWithValue("@A_Email", admin.A_Email);
                    command.Parameters.AddWithValue("@A_Name", admin.A_Name);
                    command.Parameters.AddWithValue("@A_Dob", admin.A_Dob);
                    command.Parameters.AddWithValue("@A_MobileNo", admin.A_MobileNo);
                    command.Parameters.AddWithValue("@A_UserName", admin.A_UserName);
                    command.Parameters.AddWithValue("@A_Password", admin.A_Password);
                    command.ExecuteNonQuery();
                }
            });
        }

        public void DeleteAdmin(int id)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.DELETE_ADMIN, connection))
                {
                    command.Parameters.AddWithValue("@A_Id", id);
                    command.ExecuteNonQuery();
                }
            });
        }

        public int CountTotalAdmins()
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.COUNT_TOTAL_ADMINS, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            });
        }

        public Admin GetAdminByCriteria(string username, int? id, string name, string email, string mobileNo)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command =
                       new SqlCommand(AdminQueries.GET_ADMIN_BY_USERNAME_OR_ID_OR_NAME_OR_EMAIL_OR_MOBILE_NO,
                           connection))
                {
                    command.Parameters.AddWithValue("@A_UserName", username ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_Id", id ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_Name", name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_Email", email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_MobileNo", mobileNo ?? (object)DBNull.Value);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToAdmin(reader) : null;
                    }
                }
            });
        }

        private Admin MapToAdmin(IDataReader reader)
        {
            return new Admin
            {
                A_Id = Convert.ToInt32(reader["A_Id"]),
                A_Email = reader["A_Email"].ToString(),
                A_Password = reader["A_Password"].ToString(),
                A_Name = reader["A_Name"].ToString(),
                A_Dob = Convert.ToDateTime(reader["A_Dob"]),
                A_MobileNo = reader["A_MobileNo"].ToString(),
                A_UserName = reader["A_UserName"].ToString()
            };
        }
        public bool ValidateAdminLogin(string usernameOrEmail, string password) {
            return SqlDatabaseManager.Instance.Execute(connection => {
                using (var cmd = new SqlCommand(AdminQueries.VALIDATE_ADMIN_LOGIN, connection)) {
                    // Check both username and email for login.
                    cmd.Parameters.AddWithValue("@A_UserName", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@A_Email", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@A_Password", password);

                    using (var reader = cmd.ExecuteReader()) {
                        // If the query returns a result, login is successful
                        return reader.HasRows;
                    }
                }
            });
        }
        
        public IEnumerable<Admin> GetAllAdmins() {
            return SqlDatabaseManager.Instance.Execute(connection => {
                var admins = new List<Admin>();
                using (var cmd = new SqlCommand(AdminQueries.GET_ALL_ADMINS, connection)) {
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            admins.Add(MapToAdmin(reader));
                        }
                    }
                }
                return admins;
            });
        }
        
    }
}