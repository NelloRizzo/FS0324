internal class Program
{
    class My
    {
        public int Value { get; set; }
        public override string ToString() => $"My({Value})";
    }

    private static void Increment(int value) { // int è value type
        Console.WriteLine("In ingresso al metodo Increment(int), value vale {0}", value);
        value++;
        Console.WriteLine("In uscita dal metodo Increment(int), value vale {0}", value);
    }
    private static void Increment(My value) { // My essendo una classe è un reference type
        Console.WriteLine("In ingresso al metodo Increment(My), value vale {0}", value);
        value.Value++;
        Console.WriteLine("In uscita dal metodo Increment(My), value vale {0}", value);
    }
    private static void Main(string[] args) {
        var n = 0;
        Console.WriteLine("Dopo l'inizializzazione n vale {0}", n);
        Increment(n);
        Console.WriteLine("Dopo la chiamata al metodo Increment(int), n vale {0}", n);
        var m = new My();
        Console.WriteLine("Dopo l'inizializzazione m vale {0}", m);
        Increment(m);
        // effetto collaterale: side effect
        // il valore di m cambia perché My è Reference Type
        Console.WriteLine("Dopo la chiamata al metodo Increment(My), m vale {0}", m); 
    }
}