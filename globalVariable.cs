using MediTech.Model;

namespace MediTech
{
    public class globalVariable
    {
        private static Admin adminLogin;
        private static Chemist chemistLogin;

        public static Admin AdminLogin
        {
            get => adminLogin;
            set => adminLogin = value;
        }

        public static Chemist ChemistLogin
        {
            get => chemistLogin;
            set => chemistLogin = value;
        }
    }
}