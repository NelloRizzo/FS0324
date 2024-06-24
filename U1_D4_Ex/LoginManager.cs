namespace U1_D4_Ex
{
    internal static class LoginManager
    {
        // utente loggato
        public static User LoggedUser { get; private set; }
        // ultimi 10 login
        private static DateTime[] lastLogin = new DateTime[10];
        // contatore dei login effettuati finora
        private static int lastLoginCount = 0;

        // registra nell'elenco dei login un nuovo accesso
        private static void RegisterLogin() {
            // se ci sono già 10 login
            if (lastLoginCount == 10) {
                // sposta gli ultimi 9 di una posizione in alto (scarta il primo login)
                for (int i = 1; i < 10; i++) { lastLogin[i - 1] = lastLogin[i]; }
            }
            // registro la nuova data di login
            lastLogin[lastLoginCount] = DateTime.Now;
            // se ci sono meno di 10 login
            if (lastLoginCount < 10) {
                // incremento il numero totale di login effettuati
                lastLoginCount++;
            }
        }
        // stampa i login dall'elenco
        public static void PrintLogin() {
            Console.WriteLine("Ultimi login dell'utente:");
            // stampa i login in ordine inverso
            for (int i = lastLoginCount - 1; i >= 0; i--) {
                Console.WriteLine($"{i + 1}\t{lastLogin[i]}");
            }
        }
        // effettua il login di un utente
        public static bool Login(User user) {
            // se c'è un utente già autenticato LoggedUser è stato già valorizzato ed è diverso da null
            if (LoggedUser != null) {
                Console.WriteLine("Utente già autenticato.");
                return false;
            }
            // controllo che password e conferma password siano uguali
            if (user.Password == user.Confirmation) {
                // registro l'utente autenticato
                LoggedUser = new User { Confirmation = user.Confirmation, Password = user.Password, Username = user.Username };
                RegisterLogin();
                Console.WriteLine($"Utente {LoggedUser.Username} autenticato");
                return true;
            }
            Console.WriteLine("Le password non coincidono");
            return false;
        }
        // effettua il logout
        public static bool Logout() {
            // se l'utente non è stato autenticato
            if (LoggedUser == null) {
                Console.WriteLine("Nessun utente autenticato");
                return false;
            }
            // "dimentica" l'utente
            LoggedUser = null;
            return true;
        }
        // procedura di verifica
        public static bool IsLoggedIn() {
            if (LoggedUser == null) {
                Console.WriteLine("Nessun utente autenticato");
                return false;
            }
            Console.WriteLine($"Utente autenticato alle ore {lastLogin[lastLoginCount - 1]:T} del {lastLogin[lastLoginCount - 1]:D}");
            return true;
        }
    }
}
