using System;
using System.Data;
using System.Data.SqlClient;
using MediTech.DataAccess.DAO.Constants;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public class ChemistDAOImpl : IChemistDAO
    {
        private readonly string _connectionString;

        public ChemistDAOImpl(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public Chemist GetChemistById(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_ID, connection))
            {
                command.Parameters.AddWithValue("@P_Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToChemist(reader) : null;
                }
            }
        }

        public Chemist GetChemistByName(string name)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_NAME, connection))
            {
                command.Parameters.AddWithValue("@P_Name", name);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToChemist(reader) : null;
                }
            }
        }

        public Chemist GetChemistByUsername(string username)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_USERNAME, connection))
            {
                command.Parameters.AddWithValue("@P_UserName", username);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToChemist(reader) : null;
                }
            }
        }

        public Chemist GetChemistByEmail(string email)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_EMAIL, connection))
            {
                command.Parameters.AddWithValue("@P_Email", email);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToChemist(reader) : null;
                }
            }
        }

        public Chemist GetChemistByMobileNo(string mobileNo)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.GET_ChemistS_BY_MOBILE_NO, connection))
            {
                command.Parameters.AddWithValue("@P_MobileNo", mobileNo);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToChemist(reader) : null;
                }
            }
        }

        public void InsertChemist(Chemist chemist)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.INSERT_Chemist, connection))
            {
                command.Parameters.AddWithValue("@P_Email", chemist.P_Email);
                command.Parameters.AddWithValue("@P_Name", chemist.P_Name);
                command.Parameters.AddWithValue("@P_Dob", chemist.P_Dob);
                command.Parameters.AddWithValue("@P_MobileNo", chemist.P_MobileNo);
                command.Parameters.AddWithValue("@P_UserName", chemist.P_UserName);
                command.Parameters.AddWithValue("@P_Password", chemist.P_Password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateChemist(Chemist chemist)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.UPDATE_Chemist, connection))
            {
                command.Parameters.AddWithValue("@P_Id", chemist.P_Id);
                command.Parameters.AddWithValue("@P_Email", chemist.P_Email);
                command.Parameters.AddWithValue("@P_Name", chemist.P_Name);
                command.Parameters.AddWithValue("@P_Dob", chemist.P_Dob);
                command.Parameters.AddWithValue("@P_MobileNo", chemist.P_MobileNo);
                command.Parameters.AddWithValue("@P_UserName", chemist.P_UserName);
                command.Parameters.AddWithValue("@P_Password", chemist.P_Password);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteChemist(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.DELETE_Chemist, connection))
            {
                command.Parameters.AddWithValue("@P_Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int CountTotalChemists()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.COUNT_TOTAL_ChemistS, connection))
            {
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public Chemist GetChemistByCriteria(string username, int? id, string name, string email, string mobileNo)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(ChemistQueries.GET_Chemist_BY_USERNAME_OR_ID_OR_NAME_OR_EMAIL_OR_MOBILE_NO, connection))
            {
                command.Parameters.AddWithValue("@P_UserName", username ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@P_Id", id ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@P_Name", name ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@P_Email", email ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@P_MobileNo", mobileNo ?? (object)DBNull.Value);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToChemist(reader) : null;
                }
            }
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

