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
        public Medicine GetMedicineById(int id)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.GET_MEDICINE_BY_ID, connection))
                {
                    command.Parameters.AddWithValue("@M_Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToMedicine(reader) : null;
                    }
                }
            });
        }

        public Medicine GetMedicineByName(string name)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.GET_MEDICINE_BY_NAME, connection))
                {
                    command.Parameters.AddWithValue("@M_Name", name);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToMedicine(reader) : null;
                    }
                }
            });
        }

        public Medicine GetMedicineByGroupName(string groupName)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_BY_GROUP_NAME, connection))
                {
                    command.Parameters.AddWithValue("@M_GroupName", groupName);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToMedicine(reader) : null;
                    }
                }
            });
        }

        public List<Medicine> GetAllMedicines()
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                var medicines = new List<Medicine>();
                using (var command = new SqlCommand(MedicineQueries.GET_ALL_MEDICINES, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) medicines.Add(MapToMedicine(reader));
                    }
                }

                return medicines;
            });
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
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_BY_DATE_RANGE, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    return GetMedicinesFromReader(command);
                }
            });
        }

        public List<Medicine> GetMedicinesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_BY_PRICE_RANGE, connection))
                {
                    command.Parameters.AddWithValue("@MinPrice", minPrice);
                    command.Parameters.AddWithValue("@MaxPrice", maxPrice);
                    return GetMedicinesFromReader(command);
                }
            });
        }

        public List<Medicine> GetLowStockMedicines(int threshold)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.GET_LOW_STOCK_MEDICINES, connection))
                {
                    command.Parameters.AddWithValue("@Threshold", threshold);
                    return GetMedicinesFromReader(command);
                }
            });
        }

        public List<Medicine> GetMedicinesCloseToExpiry(DateTime expiryDate)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.GET_MEDICINES_CLOSE_TO_EXPIRY, connection))
                {
                    command.Parameters.AddWithValue("@ExpiryDate", expiryDate);
                    return GetMedicinesFromReader(command);
                }
            });
        }

        public void InsertMedicine(Medicine medicine)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.INSERT_MEDICINE, connection))
                {
                    command.Parameters.AddWithValue("@M_Name", medicine.M_Name);
                    command.Parameters.AddWithValue("@M_GroupName", medicine.M_GroupName);
                    command.Parameters.AddWithValue("@M_Type", medicine.M_Type);
                    command.Parameters.AddWithValue("@Price", medicine.Price);
                    command.Parameters.AddWithValue("@ManuDate", medicine.ManuDate);
                    command.Parameters.AddWithValue("@ExpDate", medicine.ExpDate);
                    command.Parameters.AddWithValue("@Quantity", medicine.Quantity);
                    command.ExecuteNonQuery();
                }
            });
        }

        public void UpdateMedicine(Medicine medicine)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
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
                    command.ExecuteNonQuery();
                }
            });
        }

        public void DeleteMedicine(int id)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.DELETE_MEDICINE, connection))
                {
                    command.Parameters.AddWithValue("@M_Id", id);
                    command.ExecuteNonQuery();
                }
            });
        }

        public int CountTotalMedicines()
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(MedicineQueries.COUNT_TOTAL_MEDICINES, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            });
        }

        public List<Medicine> GetMedicineByPartialCriteria(string name, string id, string groupName)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command =
                       new SqlCommand(MedicineQueries.GET_MEDICINE_BY_PARTIAL_NAME_OR_PARTIAL_ID_OR_PARTIAL_GROUP_NAME,
                           connection))
                {
                    command.Parameters.AddWithValue("@M_Name", name ?? string.Empty);
                    command.Parameters.AddWithValue("@M_Id", id ?? string.Empty);
                    command.Parameters.AddWithValue("@M_GroupName", groupName ?? string.Empty);
                    return GetMedicinesFromReader(command);
                }
            });
        }

        private List<Medicine> GetMedicinesByQuery(string query)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(query, connection))
                {
                    return GetMedicinesFromReader(command);
                }
            });
        }

        private List<Medicine> GetMedicinesFromReader(SqlCommand command)
        {
            var medicines = new List<Medicine>();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) medicines.Add(MapToMedicine(reader));
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