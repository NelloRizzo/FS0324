namespace U1_D4_Ex
{
    internal class LoginManager
    {
        public static User LoggedUser { get; private set; }
        private static DateTime[] lastLogin = new DateTime[10];
        private static int lastLoginCount = 0;

        private static void RegisterLogin()
        {
            if (lastLoginCount == 10)
            {
                for (int i = 1; i < 10; i++) { lastLogin[i - 1] = lastLogin[i]; }
            }
            lastLogin[lastLoginCount] = DateTime.Now;
            if (lastLoginCount < 10) { lastLoginCount++; }
        }

        public static void PrintLogin()
        {
            Console.WriteLine("Ultimi login dell'utente:");
            for (int i = 0; i < lastLoginCount; i++)
            {
                Console.WriteLine($"{i + 1}\t{lastLogin[i]}");
            }
        }
        public static bool Login(User user)
        {
            if (LoggedUser != null)
            {
                Console.WriteLine("Utente già autenticato.");
                return false;
            }
            if (user.Password == user.Confirmation)
            {
                LoggedUser = new User { Confirmation = user.Confirmation, Password = user.Password, Username = user.Username};
                RegisterLogin();
                Console.WriteLine($"Utente {LoggedUser.Username} autenticato");
                return true;
            }
            Console.WriteLine("Le password non coincidono");
            return false;
        }

        public static bool Logout()
        {
            if (LoggedUser == null)
            {
                Console.WriteLine("Nessun utente autenticato");
                return false;
            }
            LoggedUser = null;
            return true;
        }

        public static bool IsLoggedIn()
        {
            if (LoggedUser == null)
            {
                Console.WriteLine("Nessun utente autenticato");
                return false;
            }
            Console.WriteLine($"Utente autenticato alle ore {lastLogin[lastLoginCount]:T} del {lastLogin[lastLoginCount]:D}");
            return true;
        }
    }
}
