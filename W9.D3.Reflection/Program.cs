internal class Program
{
    class Test
    {
        public string? StrValue { get; set; }
        public int IntValue { get; set; }
    }

    private static void Main(string[] args) {
        var t1 = new Test { IntValue = 1, StrValue = "Test1" };
        var t2 = new Test { IntValue = 2, StrValue = "Test2" };
        
        typeof(Test).GetProperties()
            .ToList()
            .ForEach(p => {
                Console.WriteLine("{0} -> su t1 vale {1} e su t2 vale {2}",p.Name, p.GetValue(t1), p.GetValue(t2));
            });
    }
}