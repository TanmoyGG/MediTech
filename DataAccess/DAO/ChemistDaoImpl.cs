using System;
using System.Data;
using System.Data.SqlClient;
using MediTech.DataAccess.DAO.Constants;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public class ChemistDAOImpl : IChemistDAO
    {
        public Chemist GetChemistById(int id)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_ID, connection))
                {
                    command.Parameters.AddWithValue("@P_Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToChemist(reader) : null;
                    }
                }
            });
        }

        public Chemist GetChemistByName(string name)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_NAME, connection))
                {
                    command.Parameters.AddWithValue("@P_Name", name);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToChemist(reader) : null;
                    }
                }
            });
        }

        public Chemist GetChemistByUsername(string username)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_USERNAME, connection))
                {
                    command.Parameters.AddWithValue("@P_UserName", username);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToChemist(reader) : null;
                    }
                }
            });
        }

        public Chemist GetChemistByEmail(string email)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_EMAIL, connection))
                {
                    command.Parameters.AddWithValue("@P_Email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToChemist(reader) : null;
                    }
                }
            });
        }

        public Chemist GetChemistByMobileNo(string mobileNo)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.GET_ChemistS_BY_MOBILE_NO, connection))
                {
                    command.Parameters.AddWithValue("@P_MobileNo", mobileNo);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToChemist(reader) : null;
                    }
                }
            });
        }

        public void InsertChemist(Chemist chemist)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.INSERT_Chemist, connection))
                {
                    command.Parameters.AddWithValue("@P_Email", chemist.P_Email);
                    command.Parameters.AddWithValue("@P_Name", chemist.P_Name);
                    command.Parameters.AddWithValue("@P_Dob", chemist.P_Dob);
                    command.Parameters.AddWithValue("@P_MobileNo", chemist.P_MobileNo);
                    command.Parameters.AddWithValue("@P_UserName", chemist.P_UserName);
                    command.Parameters.AddWithValue("@P_Password", chemist.P_Password);

                    command.ExecuteNonQuery();
                }
            });
        }

        public void UpdateChemist(Chemist chemist)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.UPDATE_Chemist, connection))
                {
                    command.Parameters.AddWithValue("@P_Id", chemist.P_Id);
                    command.Parameters.AddWithValue("@P_Email", chemist.P_Email);
                    command.Parameters.AddWithValue("@P_Name", chemist.P_Name);
                    command.Parameters.AddWithValue("@P_Dob", chemist.P_Dob);
                    command.Parameters.AddWithValue("@P_MobileNo", chemist.P_MobileNo);
                    command.Parameters.AddWithValue("@P_UserName", chemist.P_UserName);
                    command.Parameters.AddWithValue("@P_Password", chemist.P_Password);

                    command.ExecuteNonQuery();
                }
            });
        }

        public void DeleteChemist(int id)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.DELETE_Chemist, connection))
                {
                    command.Parameters.AddWithValue("@P_Id", id);
                    command.ExecuteNonQuery();
                }
            });
        }

        public int CountTotalChemists()
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.COUNT_TOTAL_ChemistS, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            });
        }

        public Chemist GetChemistByCriteria(string username, int? id, string name, string email, string mobileNo)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_USERNAME_OR_ID_OR_NAME_OR_EMAIL_OR_MOBILE_NO, connection))
                {
                    command.Parameters.AddWithValue("@P_UserName", username ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@P_Id", id ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@P_Name", name ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@P_Email", email ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@P_MobileNo", mobileNo ?? (object)DBNull.Value);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToChemist(reader) : null;
                    }
                }
            });
        }

        private Chemist MapToChemist(IDataRecord record)
        {
            return new Chemist(
                record["P_Email"].ToString(),
                record["P_Name"].ToString(),
                DateTime.Parse(record["P_Dob"].ToString()),
                record["P_MobileNo"].ToString(),
                record["P_UserName"].ToString(),
                record["P_Password"].ToString())
            {
                P_Id = int.Parse(record["P_Id"].ToString())
            };
        }
    }
}
