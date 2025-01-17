using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MediTech.DataAccess.DAO.Constants;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public class MedicineDAOImpl : IMedicineDAO
    {
        private readonly string _connectionString;

        public MedicineDAOImpl(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public Medicine GetMedicineById(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_MEDICINE_BY_ID, connection))
            {
                command.Parameters.AddWithValue("@M_Id", id);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToMedicine(reader) : null;
                }
            }
        }

        public Medicine GetMedicineByName(string name)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_MEDICINE_BY_NAME, connection))
            {
                command.Parameters.AddWithValue("@M_Name", name);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToMedicine(reader) : null;
                }
            }
        }

        public Medicine GetMedicineByGroupName(string groupName)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_BY_GROUP_NAME, connection))
            {
                command.Parameters.AddWithValue("@M_GroupName", groupName);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? MapToMedicine(reader) : null;
                }
            }
        }

        public List<Medicine> GetAllMedicines()
        {
            var medicines = new List<Medicine>();

            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_ALL_MEDICINES, connection))
            {
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicines.Add(MapToMedicine(reader));
                    }
                }
            }

            return medicines;
        }

        public List<Medicine> GetExpiredMedicines()
        {
            return GetMedicinesByQuery(MedicineQueries.GET_EXPIRED_MEDICINES);
        }

        public List<Medicine> GetValidMedicines()
        {
            return GetMedicinesByQuery(MedicineQueries.GET_VALID_MEDICINES);
        }

        public List<Medicine> GetMedicinesByDateRange(DateTime startDate, DateTime endDate)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_BY_DATE_RANGE, connection))
            {
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                connection.Open();

                return GetMedicinesFromReader(command);
            }
        }

        public List<Medicine> GetMedicinesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_BY_PRICE_RANGE, connection))
            {
                command.Parameters.AddWithValue("@MinPrice", minPrice);
                command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                connection.Open();

                return GetMedicinesFromReader(command);
            }
        }

        public List<Medicine> GetLowStockMedicines(int threshold)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_LOW_STOCK_MEDICINES, connection))
            {
                command.Parameters.AddWithValue("@Threshold", threshold);
                connection.Open();

                return GetMedicinesFromReader(command);
            }
        }

        public List<Medicine> GetMedicinesCloseToExpiry(DateTime expiryDate)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_CLOSE_TO_EXPIRY, connection))
            {
                command.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                connection.Open();

                return GetMedicinesFromReader(command);
            }
        }

        public void InsertMedicine(Medicine medicine)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.INSERT_MEDICINE, connection))
            {
                command.Parameters.AddWithValue("@M_Name", medicine.M_Name);
                command.Parameters.AddWithValue("@M_GroupName", medicine.M_GroupName);
                command.Parameters.AddWithValue("@M_Type", medicine.M_Type);
                command.Parameters.AddWithValue("@Price", medicine.Price);
                command.Parameters.AddWithValue("@ManuDate", medicine.ManuDate);
                command.Parameters.AddWithValue("@ExpDate", medicine.ExpDate);
                command.Parameters.AddWithValue("@Quantity", medicine.Quantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateMedicine(Medicine medicine)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.UPDATE_MEDICINE, connection))
            {
                command.Parameters.AddWithValue("@M_Id", medicine.M_Id);
                command.Parameters.AddWithValue("@M_Name", medicine.M_Name);
                command.Parameters.AddWithValue("@M_GroupName", medicine.M_GroupName);
                command.Parameters.AddWithValue("@M_Type", medicine.M_Type);
                command.Parameters.AddWithValue("@Price", medicine.Price);
                command.Parameters.AddWithValue("@ManuDate", medicine.ManuDate);
                command.Parameters.AddWithValue("@ExpDate", medicine.ExpDate);
                command.Parameters.AddWithValue("@Quantity", medicine.Quantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteMedicine(int id)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.DELETE_MEDICINE, connection))
            {
                command.Parameters.AddWithValue("@M_Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int CountTotalMedicines()
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.COUNT_TOTAL_MEDICINES, connection))
            {
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public List<Medicine> GetMedicineByPartialCriteria(string name, string id, string groupName)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(MedicineQueries.GET_MEDICINE_BY_PARTIAL_NAME_OR_PARTIAL_ID_OR_PARTIAL_GROUP_NAME, connection))
            {
                command.Parameters.AddWithValue("@M_Name", name ?? string.Empty);
                command.Parameters.AddWithValue("@M_Id", id ?? string.Empty);
                command.Parameters.AddWithValue("@M_GroupName", groupName ?? string.Empty);
                connection.Open();

                return GetMedicinesFromReader(command);
            }
        }

        private List<Medicine> GetMedicinesByQuery(string query)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand(query, connection))
            {
                connection.Open();
                return GetMedicinesFromReader(command);
            }
        }

        private List<Medicine> GetMedicinesFromReader(SqlCommand command)
        {
            var medicines = new List<Medicine>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    medicines.Add(MapToMedicine(reader));
                }
            }

            return medicines;
        }

        private Medicine MapToMedicine(IDataRecord record)
        {
            return new Medicine(
                record["M_Name"].ToString(),
                record["M_GroupName"].ToString(),
                record["M_Type"].ToString(),
                decimal.Parse(record["Price"].ToString()),
                DateTime.Parse(record["ManuDate"].ToString()),
                DateTime.Parse(record["ExpDate"].ToString()),
                int.Parse(record["Quantity"].ToString())
            )
            {
                M_Id = int.Parse(record["M_Id"].ToString())
            };
        }
    }
}

