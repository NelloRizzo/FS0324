internal class Program
{
    class My : Object
    {
        public int Value { get; set; }
        public override string ToString() => $"My({Value})";

        public override bool Equals(object? obj) => obj is My m // is restituisce true se obj è di classe My
                                                                // se obj è di classe My, allora mette in m il valore di obj convertito in My
            && m.Value == this.Value;

        // fornisce una rappresentazione della classe attraverso un numero intero
        // unica considerazione da tener presente è che SE DUE OGGETTI SONO UGUALI RESTITUISCONO LO STESSO HASHCODE
        public override int GetHashCode() => HashCode.Combine(Value);
    }

    private static void Main(string[] args) {
        My m1 = new My { Value = 3 };
        My m2 = new My { Value = 3 };
        if (m1.Equals(m2)) // (m1 == m2)
            Console.WriteLine($"{m1} e {m2} sono uguali");
        else
            Console.WriteLine($"{m1} e {m2} sono diversi");

        My m3 = m2;
        if (m3 == m2)
            Console.WriteLine($"{m3} e {m2} sono uguali");
        else
            Console.WriteLine($"{m3} e {m2} sono diversi");

        HashSet<int> hi = new HashSet<int> { 1, 2, 3, 4, 3, 2, 4, 5, 6, 3, 5 };
        foreach (var i in hi) { Console.WriteLine(i); }

        HashSet<My> hm = new HashSet<My> { new My { Value = 3 }, new My { Value = 2 }, new My {Value = 3 } };
        foreach (var i in hm) { Console.WriteLine(i); }
    }
}