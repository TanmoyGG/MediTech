using System;
using System.Collections.Generic;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.DataAccess.Controller
{
    public class SalesReportController
    {
        private readonly ISalesReportDAO _salesReportDAO;

        public SalesReportController(ISalesReportDAO salesReportDAO)
        {
            _salesReportDAO = salesReportDAO;
        }

        public SalesReport GetReportById(int id)
        {
            return _salesReportDAO.GetSalesReportById(id);
        }

        public List<SalesReport> GetReportsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _salesReportDAO.GetSalesReportsByDateRange(startDate, endDate);
        }

        public List<SalesReport> GetReportsByMedicineId(int medicineId)
        {
            return _salesReportDAO.GetSalesReportsByMedicineId(medicineId);
        }

        public void AddSalesReport(SalesReport salesReport)
        {
            _salesReportDAO.InsertSalesReport(salesReport);
        }

        public int GetTotalSalesReports()
        {
            return _salesReportDAO.CountTotalSalesReports();
        }
        public List<SalesReport> GetAllReports()
        {
            return _salesReportDAO.GetAllSalesReports();
        }
    }
}