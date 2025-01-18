using System;
using System.Collections.Generic;
using MediTech.DataAccess.DAO;
using MediTech.Model;
using MediTech.OTP;

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
            EmailService.Instance.SendLoginDetailsToEmail(chemist.P_Email, chemist.P_UserName, chemist.P_Password);
        }

        public void UpdateChemist(Chemist chemist)
        {
            _chemistDao.UpdateChemist(chemist);
            EmailService.Instance.SendLoginDetailsToEmail(chemist.P_Email, chemist.P_UserName, chemist.P_Password);
        }

        public void DeleteChemist(int id)
        {
            _chemistDao.DeleteChemist(id);
            Console.WriteLine("Pharmacist removed successfully.");
        }

        public int DisplayTotalPharmacists()
        {
            var count = _chemistDao.CountTotalChemists();
            Console.WriteLine($"Total Pharmacists: {count}");
            return count;
        }

        public Chemist GetChemistByCriteria(string username, int? id, string name, string email, string mobileNo)
        {
            return _chemistDao.GetChemistByCriteria(username, id, name, email, mobileNo);
        }
        
        public bool Login(string usernameOrEmail, string password) {
            return _chemistDao.ValidateChemistLogin(usernameOrEmail, password);
        }
        
        public IEnumerable<Chemist> GetAllChemists() {
            return _chemistDao.GetAllChemists();
        }
    }
}