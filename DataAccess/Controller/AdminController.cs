using System.Collections.Generic;
using MediTech.DataAccess.DAO;
using MediTech.Model;
using MediTech.OTP;

namespace MediTech.DataAccess.Controller {
    public class AdminController
    {
        private readonly IAdminDAO _adminDAO;

        public AdminController(IAdminDAO adminDAO)
        {
            _adminDAO = adminDAO;
        }

        public Admin GetAdminById(int id)
        {
            return _adminDAO.GetAdminById(id);
        }

        public void AddAdmin(Admin admin)
        {
            _adminDAO.InsertAdmin(admin);
            EmailService.Instance.SendLoginDetailsToEmail(admin.A_Email,admin.A_UserName,admin.A_Password);
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminDAO.UpdateAdmin(admin);
            EmailService.Instance.SendLoginDetailsToEmail(admin.A_Email,admin.A_UserName,admin.A_Password);
        }

        public void DeleteAdmin(int id)
        {
            _adminDAO.DeleteAdmin(id);
        }

        public int GetTotalAdminCount()
        {
            return _adminDAO.CountTotalAdmins();
        }

        public Admin SearchAdminByCriteria(string username, int? id, string name, string email, string mobileNo)
        {
            return _adminDAO.GetAdminByCriteria(username, id, name, email, mobileNo);
        }
    }
}
