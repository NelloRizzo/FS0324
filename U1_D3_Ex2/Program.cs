namespace U1_D3_Ex2
{
    internal class Program
    {
        static void Search(string[] s, string target) {
            int pos = -1;
            for (int i = 0; i < s.Length && pos == -1; i++) {
                if (s[i] == target)
                    pos = i;
            }
            if (pos == -1)
                Console.WriteLine($"Elemento <{target}> non trovato");
            else
                Console.WriteLine($"Elemento <{target}> trovato in posizione {pos}");
        }

        static void Main(string[] args) {
            string[] names = ["Pippo", "Pluto", "Paperino", "Topolino", "Gastone", "Archimede"];
            Search(names, "Paperino");
            Search(names, "paperino");
        }
    }
}
