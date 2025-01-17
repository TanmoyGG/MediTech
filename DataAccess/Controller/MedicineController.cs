using System;
using System.Collections.Generic;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.DataAccess.Controller
{
    public class MedicineController
    {
        private readonly IMedicineDAO _medicineDao;

        public MedicineController(IMedicineDAO medicineDao)
        {
            _medicineDao = medicineDao;
        }

        public Medicine GetMedicineById(int id)
        {
            return _medicineDao.GetMedicineById(id);
        }

        public Medicine GetMedicineByName(string name)
        {
            return _medicineDao.GetMedicineByName(name);
        }

        public Medicine GetMedicineByGroupName(string groupName)
        {
            return _medicineDao.GetMedicineByGroupName(groupName);
        }

        public List<Medicine> GetAllMedicines()
        {
            return _medicineDao.GetAllMedicines();
        }

        public List<Medicine> GetExpiredMedicines()
        {
            return _medicineDao.GetExpiredMedicines();
        }

        public List<Medicine> GetValidMedicines()
        {
            return _medicineDao.GetValidMedicines();
        }

        public List<Medicine> GetMedicinesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _medicineDao.GetMedicinesByDateRange(startDate, endDate);
        }

        public List<Medicine> GetMedicinesByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _medicineDao.GetMedicinesByPriceRange(minPrice, maxPrice);
        }

        public List<Medicine> GetLowStockMedicines(int threshold)
        {
            return _medicineDao.GetLowStockMedicines(threshold);
        }

        public List<Medicine> GetMedicinesCloseToExpiry(DateTime expiryDate)
        {
            return _medicineDao.GetMedicinesCloseToExpiry(expiryDate);
        }

        public void InsertMedicine(Medicine medicine)
        {
            _medicineDao.InsertMedicine(medicine);
        }

        public void UpdateMedicine(Medicine medicine)
        {
            _medicineDao.UpdateMedicine(medicine);
        }

        public void DeleteMedicine(int id)
        {
            _medicineDao.DeleteMedicine(id);
        }

        public int CountTotalMedicines()
        {
            return _medicineDao.CountTotalMedicines();
        }

        public List<Medicine> GetMedicineByPartialCriteria(string name, string id, string groupName)
        {
            return _medicineDao.GetMedicineByPartialCriteria(name, id, groupName);
        }
    }
}
