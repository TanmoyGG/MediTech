using System;
using System.Collections.Generic;
using MediTech.Model;

namespace MediTech.DataAccess.DAO
{
    public interface IAdminDAO
    {
        Admin GetAdminById(int id);
        Admin GetAdminByName(string name);
        Admin GetAdminByUsername(string username);
        Admin GetAdminByEmail(string email);
        Admin GetAdminByMobileNo(string mobileNo);
        void InsertAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
        void DeleteAdmin(int id);
        int CountTotalAdmins();
        Admin GetAdminByCriteria(string username, int? id, string name, string email, string mobileNo);

        bool ValidateAdminLogin(string usernameOrEmail, string password);

        IEnumerable<Admin> GetAllAdmins();

        List<Admin> SearchAdmin(string name);


    }

    public interface IChemistDAO
    {
        Chemist GetChemistById(int id);
        Chemist GetChemistByName(string name);
        Chemist GetChemistByUsername(string username);
        Chemist GetChemistByEmail(string email);
        Chemist GetChemistByMobileNo(string mobileNo);
        void InsertChemist(Chemist Chemist);
        void UpdateChemist(Chemist Chemist);
        void DeleteChemist(int id);
        int CountTotalChemists();
        Chemist GetChemistByCriteria(string username, int? id, string name, string email, string mobileNo);

        bool ValidateChemistLogin(string usernameOrEmail, string password);

        IEnumerable<Chemist> GetAllChemists();

        List<Chemist> SearchChemist(string name);
    }

    public interface IMedicineDAO
    {
        Medicine GetMedicineById(int id);
        Medicine GetMedicineByName(string name);
        Medicine GetMedicineByGroupName(string groupName);
        List<Medicine> GetAllMedicines();
        List<Medicine> GetExpiredMedicines();
        List<Medicine> GetValidMedicines();
        List<Medicine> GetMedicinesByDateRange(DateTime startDate, DateTime endDate);
        List<Medicine> GetMedicinesByPriceRange(decimal minPrice, decimal maxPrice);
        List<Medicine> GetLowStockMedicines(int threshold);
        List<Medicine> GetMedicinesCloseToExpiry(DateTime expiryDate);
        void InsertMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        void DeleteMedicine(int id);
        int CountTotalMedicines();
        int CountTotalValidMedicines();
        int CountTotalExpiredMedicines();
        List<Medicine> SearchMedicine(string name);
        List<Medicine> SearchValidMedicine(string name);
    }

    public interface ISalesReportDAO
    {
        SalesReport GetSalesReportById(int id);
        List<SalesReport> GetSalesReportsByDateRange(DateTime startDate, DateTime endDate);
        List<SalesReport> GetSalesReportsByMedicineId(int medicineId);
        void InsertSalesReport(SalesReport salesReport);
        int CountTotalSalesReports();

        List<SalesReport> SearchSalesReport(string P_name);

        List<SalesReport> GetAllSalesReports();
    }
}