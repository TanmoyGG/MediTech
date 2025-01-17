﻿using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.DataAccess.Controller
{
    public class ChemistController
    {
        private readonly IChemistDAO _chemistDao;

        public ChemistController(IChemistDAO chemistDao)
        {
            _chemistDao = chemistDao;
        }

        public Chemist GetChemistById(int id)
        {
            return _chemistDao.GetChemistById(id);
        }

        public Chemist GetChemistByName(string name)
        {
            return _chemistDao.GetChemistByName(name);
        }

        public Chemist GetChemistByUsername(string username)
        {
            return _chemistDao.GetChemistByUsername(username);
        }

        public Chemist GetChemistByEmail(string email)
        {
            return _chemistDao.GetChemistByEmail(email);
        }

        public Chemist GetChemistByMobileNo(string mobileNo)
        {
            return _chemistDao.GetChemistByMobileNo(mobileNo);
        }

        public void InsertChemist(Chemist chemist)
        {
            _chemistDao.InsertChemist(chemist);
        }

        public void UpdateChemist(Chemist chemist)
        {
            _chemistDao.UpdateChemist(chemist);
        }

        public void DeleteChemist(int id)
        {
            _chemistDao.DeleteChemist(id);
        }

        public int CountTotalChemists()
        {
            return _chemistDao.CountTotalChemists();
        }

        public Chemist GetChemistByCriteria(string username, int? id, string name, string email, string mobileNo)
        {
            return _chemistDao.GetChemistByCriteria(username, id, name, email, mobileNo);
        }
    }
}