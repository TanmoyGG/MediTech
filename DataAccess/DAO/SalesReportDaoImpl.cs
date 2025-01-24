using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MediTech.DataAccess.DAO.Constants;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public class SalesReportDAOImpl : ISalesReportDAO
    {
        public SalesReport GetSalesReportById(int id)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(SalesReportQueries.GET_SALES_REPORT_BY_ID, connection))
                {
                    command.Parameters.AddWithValue("@Report_Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? MapToSalesReport(reader) : null;
                    }
                }
            });
        }

        public List<SalesReport> GetSalesReportsByDateRange(DateTime startDate, DateTime endDate)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                var reports = new List<SalesReport>();
                using (var command = new SqlCommand(SalesReportQueries.GET_SALES_REPORT_BY_DATE, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) reports.Add(MapToSalesReport(reader));
                    }
                }

                return reports;
            });
        }

        public List<SalesReport> GetSalesReportsByMedicineId(int medicineId)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                var reports = new List<SalesReport>();
                using (var command = new SqlCommand(SalesReportQueries.GET_SALES_REPORT_BY_MEDICINE_ID, connection))
                {
                    command.Parameters.AddWithValue("@M_Id", medicineId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) reports.Add(MapToSalesReport(reader));
                    }
                }

                return reports;
            });
        }

        public void InsertSalesReport(SalesReport salesReport)
        {
            SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(SalesReportQueries.INSERT_SALES_REPORT, connection))
                {
                    command.Parameters.AddWithValue("@M_Id", salesReport.M_Id);
                    command.Parameters.AddWithValue("@M_Name", salesReport.M_Name);
                    command.Parameters.AddWithValue("@Price", salesReport.Price);
                    command.Parameters.AddWithValue("@P_Name", salesReport.P_Name);
                    command.Parameters.AddWithValue("@Quantity", salesReport.Quantity);
                    command.ExecuteNonQuery();
                }
            });
        }

        public int CountTotalSalesReports()
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                using (var command = new SqlCommand(SalesReportQueries.COUNT_TOTAL_SALES_REPORTS, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            });
        }

        private SalesReport MapToSalesReport(SqlDataReader reader)
        {
            return new SalesReport(
                reader.GetDateTime(reader.GetOrdinal("ReportDateTime")),
                reader.GetInt32(reader.GetOrdinal("M_Id")),
                reader.GetString(reader.GetOrdinal("M_Name")),
                reader.GetDecimal(reader.GetOrdinal("Price")),
                reader.GetString(reader.GetOrdinal("P_Name")),
                reader.GetInt32(reader.GetOrdinal("Quantity"))

            )
            {
                Report_Id = reader.GetInt32(reader.GetOrdinal("Report_Id"))
            };
        }

        public List<SalesReport>GetAllSalesReports()
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                var reports = new List<SalesReport>();
                using (var command = new SqlCommand(SalesReportQueries.GET_ALL_SALES_REPORTS, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) reports.Add(MapToSalesReport(reader));
                    }
                }
                return reports;
            });
        }

        public List<SalesReport> SearchSalesReport(string P_name)
        {
            return SqlDatabaseManager.Instance.Execute(connection =>
            {
                var reports = new List<SalesReport>();
                using (var command = new SqlCommand(SalesReportQueries.GET_SALES_REPORT_BY_PARTIAL_NAME, connection))
                {
                    command.Parameters.AddWithValue("@P_Name", P_name);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) reports.Add(MapToSalesReport(reader));
                    }
                }
                return reports;
            });
        }
    }
}