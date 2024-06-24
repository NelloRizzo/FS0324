namespace W2_D1_Generics
{
    class MyValue : Object
    {
        public required int Value { get; set; }

        public override string ToString() {
            Console.WriteLine("Accesso al metodo ToString di MyValue");
            return $"MyValue(Value = {Value})";
        }
    }

    class MyDerived : MyValue
    {
        public override string ToString() {
            return $"MyDerived(Value = {Value})";
        }

    }

    internal class Program
    {
        static void Main(string[] args) {
            var my = new MyValue { Value = 1 };
            Console.WriteLine(my);

            // notazione generica <> - string è il parametro generico
            IList<string> list = new List<string>();
            list.Add("Uno");
            list.Add("Due");
            Console.WriteLine(list[0]);

            foreach (var item in list) {
                Console.WriteLine(item);
            }

            var numbers = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> n = [321, 435, 24536, 35467, 3456, 74653];

            var mines = new List<MyValue>() {
                new MyValue { Value = 10 }, new MyValue { Value = 20 }, new MyValue { Value = 30 }, new MyDerived{ Value=100 } };
            foreach (var item in mines) {
                Console.WriteLine(item);
            }
        }
    }
}
