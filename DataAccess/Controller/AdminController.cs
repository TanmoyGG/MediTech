using System;
using MediTech.DataAccess.DAO;
using MediTech.Model;

namespace MediTech.Controller
{
    public class AdminController
    {
        private readonly IAdminDAO _adminDAO;

        public AdminController(IAdminDAO adminDAO)
        {
            _adminDAO = adminDAO;
        }
        
        public void AddAdmin(Admin admin)
        {
            _adminDAO.InsertAdmin(admin);
            Console.WriteLine("Admin added successfully.");
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminDAO.UpdateAdmin(admin);
            Console.WriteLine("Admin updated successfully.");
        }

        public void RemoveAdmin(int id)
        {
            _adminDAO.DeleteAdmin(id);
            Console.WriteLine("Admin removed successfully.");
        }

        public void DisplayAdminById(int id)
        {
            var admin = _adminDAO.GetAdminById(id);
            if (admin != null)
                Console.WriteLine($"Admin: {admin.A_Name}, Email: {admin.A_Email}");
            else
                Console.WriteLine("Admin not found.");
        }

        public int DisplayTotalAdmins()
        {
            var count = _adminDAO.CountTotalAdmins();
            Console.WriteLine($"Total Admins: {count}");
            return count;
        }

        public Admin GetAdminByUserName(string name)
        {
            Console.WriteLine("Admin found successfully.");
            return _adminDAO.GetAdminByUsername(name);
        }
        public bool Login(string usernameOrEmail, string password) {
            return _adminDAO.ValidateAdminLogin(usernameOrEmail, password);
        }
        
        
    }
}