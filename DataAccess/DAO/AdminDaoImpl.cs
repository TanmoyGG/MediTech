using System;
using System.Data;
using System.Data.SqlClient;
using MediTech.DataAccess.DAO.Constants;
using MediTech.Model;
using MediTech.DataAccess;

namespace MediTech.DataAccess.DAO
{
    public class AdminDAOImpl : IAdminDAO
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
                        return reader.Read() ? MapAdmin(reader) : null;
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
                        return reader.Read() ? MapAdmin(reader) : null;
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
                        return reader.Read() ? MapAdmin(reader) : null;
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
                        return reader.Read() ? MapAdmin(reader) : null;
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
                        return reader.Read() ? MapAdmin(reader) : null;
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
                    SetAdminParameters(command, admin);
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
                    SetAdminParameters(command, admin);
                    command.Parameters.AddWithValue("@A_Id", admin.A_Id);
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
                    return (int)command.ExecuteScalar();
                }
            });
        }

        public Admin GetAdminByCriteria(string username, int? id, string name, string email, string mobileNo)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(AdminQueries.GET_ADMIN_BY_USERNAME_OR_ID_OR_NAME_OR_EMAIL_OR_MOBILE_NO, connection))
                {
                    command.Parameters.AddWithValue("@A_UserName", username ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_Id", id ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_Name", name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_Email", email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@A_MobileNo", mobileNo ?? (object)DBNull.Value);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapAdmin(reader) : null;
                    }
                }
            });
        }

        private static Admin MapAdmin(IDataRecord record)
        {
            return new Admin(
                record["A_Email"].ToString(),
                record["A_Password"].ToString(),
                record["A_Name"].ToString(),
                Convert.ToDateTime(record["A_Dob"]),
                record["A_MobileNo"].ToString(),
                record["A_UserName"].ToString())
            {
                A_Id = Convert.ToInt32(record["A_Id"])
            };
        }

        private static void SetAdminParameters(SqlCommand command, Admin admin)
        {
            command.Parameters.AddWithValue("@A_Email", admin.A_Email);
            command.Parameters.AddWithValue("@A_Password", admin.A_Password);
            command.Parameters.AddWithValue("@A_Name", admin.A_Name);
            command.Parameters.AddWithValue("@A_Dob", admin.A_Dob);
            command.Parameters.AddWithValue("@A_MobileNo", admin.A_MobileNo);
            command.Parameters.AddWithValue("@A_UserName", admin.A_UserName);
        }
    }
}
