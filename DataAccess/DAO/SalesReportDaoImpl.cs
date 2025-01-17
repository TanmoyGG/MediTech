using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MediTech.DataAccess.DAO.Constants;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public class SalesReportDAOImpl : ISalesReportDAO
    {
        private readonly string _connectionString;

        public SalesReportDAOImpl(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SalesReport GetSalesReportById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SalesReportQueries.GET_SALES_REPORT_BY_ID, connection))
                {
                    command.Parameters.AddWithValue("@Report_Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapToSalesReport(reader);
                        }
                    }
                }
            }
            return null;
        }

        public List<SalesReport> GetSalesReportsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<SalesReport> reports = new List<SalesReport>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SalesReportQueries.GET_SALES_REPORT_BY_DATE, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reports.Add(MapToSalesReport(reader));
                        }
                    }
                }
            }
            return reports;
        }

        public List<SalesReport> GetSalesReportsByMedicineId(int medicineId)
        {
            List<SalesReport> reports = new List<SalesReport>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SalesReportQueries.GET_SALES_REPORT_BY_MEDICINE_ID, connection))
                {
                    command.Parameters.AddWithValue("@M_Id", medicineId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            reports.Add(MapToSalesReport(reader));
                        }
                    }
                }
            }
            return reports;
        }

        public void InsertSalesReport(SalesReport salesReport)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SalesReportQueries.INSERT_SALES_REPORT, connection))
                {
                    command.Parameters.AddWithValue("@M_Id", salesReport.M_Id);
                    command.Parameters.AddWithValue("@M_Name", salesReport.M_Name);
                    command.Parameters.AddWithValue("@Price", salesReport.Price);
                    command.Parameters.AddWithValue("@P_Name", salesReport.P_Name);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int CountTotalSalesReports()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(SalesReportQueries.COUNT_TOTAL_SALES_REPORTS, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        private SalesReport MapToSalesReport(SqlDataReader reader)
        {
            return new SalesReport(
                reportDateTime: reader.GetDateTime(reader.GetOrdinal("ReportDateTime")),
                mId: reader.GetInt32(reader.GetOrdinal("M_Id")),
                mName: reader.GetString(reader.GetOrdinal("M_Name")),
                price: reader.GetDecimal(reader.GetOrdinal("Price")),
                pName: reader.GetString(reader.GetOrdinal("P_Name"))
            )
            {
                Report_Id = reader.GetInt32(reader.GetOrdinal("Report_Id"))
            };
        }
    }

   
}
