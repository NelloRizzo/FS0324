namespace U1_D4_Ex
{
    //  TRACCIA DELL'ESERCIZIO:
    //  Creare una console application che riproponga un menu come quello proposto di seguito:

    //	===============OPERAZIONI==============
    //	Scegli l'operazione da effettuare:
    //	1.: Login
    //	2.: Logout
    //	3.: Verifica ora e data di login
    //	4.: Lista degli accessi
    //	5.: Esci
    //	========================================
    //  L'esercizio deve poter simulare l'attività di login di un utente, ed in particolare:
    //  - L'operazione di login deve richiedere una username, una password ed una conferma password.
    //      Solo se la username è stata inserita e le password coincidono, l'utente verrà autenticato,
    //  - L'operazione di logout deve consentire di dimenticare l'utente autenticato.
    //      Se si richiede il logout quando un utente non è loggato,
    //      il sistema deve riproporre un messaggio di errore,
    //  - L'operazione di verifica deve riportare la data e l'ora di quando è stato effettuato il login
    //      dell'utente. Nel caso in cui venisse richiamato il metodo ma nessun utente risulta autenticato,
    //      il sistema deve riproporre un messaggio di errore.
    //  - La lista degli accessi deve riportare la lista storica degli ultimi 10 accessi
    //      all'interno di un array di 10 elementi.

    //  Affinché l'esercizio venga svolto im modo corretto, deve essere implementata una classe statica
    //  'Utente' che comprenda metodi e proprietà anch'esse statiche.
    internal class Program
    {
        static char Choice() {
            // answer è una variabile di tipo carattere singolo
            char answer;
            do // inizio il ciclo
            {
                // leggo il prossimo carattere da tastiera come un numero (in pratica legge il codice UNICODE del carattere)
                int c = Console.Read();
                // prendo l'intero c e lo converto in carattere (char)
                answer = (char)c;
                // il ciclo si ripete fino a che answer è >= 1 e <= 5
            } while (answer < '1' || answer > '5');
            // scarta il ritorno a capo perché la Read() lo lascia in ingresso e quindi la prossima ReadLine() fallirebbe perché
            // troverebbe come primo carattere proprio il ritorno a capo!!!
            Console.ReadLine();
            // restituisce il valore letto
            return answer;
        }

        static char Menu() {
            string[] items = ["Login", "Logout", "Verifica", "Elenco accessi", "Esci"];
            // PadLeft riempie la stringa con caratteri a sinistra fino a raggiungere la dimensione specificata
            // PadRight riempie a destra
            string title = " OPERAZIONI ".PadLeft(25, '=').PadRight(42, '=');
            Console.WriteLine(title);
            for (int i = 0; i < items.Length; i++) {
                Console.WriteLine($"{i + 1}.\t{items[i]}");
            }
            Console.WriteLine("".PadLeft(title.Length, '='));
            Console.Write("Scegli: ");
            return Choice();
        }

        static User InputUser() {
            Console.Write("Username: "); string username = Console.ReadLine();
            Console.Write("Password: "); string password = Console.ReadLine();
            Console.Write("Conferma password: "); string confirm = Console.ReadLine();
            return new User { Confirmation = confirm, Password = password, Username = username };
        }
        static void Main(string[] args) {
            //Console.Write("Scrivi una scelta (1-5): ");
            //char c = Choice();
            //Console.WriteLine($"Hai scelto {c}");
            //DateTime dt = DateTime.Now;
            char choice;
            while ((choice = Menu()) != '5') {
                switch (choice) {
                    case '1': LoginManager.Login(InputUser()); break;
                    case '2': LoginManager.Logout(); break;
                    case '3': LoginManager.IsLoggedIn(); break;
                    case '4': LoginManager.PrintLogin(); break;
                }
            }
            Console.WriteLine("Fine applicazione");
        }
    }
}
