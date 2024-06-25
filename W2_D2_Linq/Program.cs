internal class Program
{
    class My
    {
        public int Value { get; set; }
        public override string ToString() => $"My({Value})";
    }
    private static void Main(string[] args) {
        List<int> numbers = [123, 2435, 4567, 4312, 4679, 234, 568, 92435, 65689, 7345, 456879, 3456, 4679, 234567457, 83, 6583568];
        // contesto imperativo
        List<int> even = new List<int>();
        foreach (int i in numbers) {
            if (i % 2 == 0) even.Add(i);
        }

        foreach (int i in even) {
            Console.WriteLine(i);
        }
        Console.WriteLine("LINQ");
        // LINQ - Language INtegrated Query
        //          notazione descrittiva del processo di filtro e selezione da un contenitore
        var even1 = from n in numbers where n % 2 == 0 select new My { Value = n };

        numbers.Insert(0, 20); numbers.Insert(3, 1234);

        foreach (var i in even1) { Console.WriteLine(i); }

        Console.WriteLine("Con notazione fluente");
        // notazione fluente
        var e = numbers.Where(n => n % 2 == 0).Select(n => new My { Value = n }).ToList();
        e.ForEach(n => Console.WriteLine(n));
    }
}