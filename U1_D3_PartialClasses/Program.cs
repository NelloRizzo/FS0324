namespace U1_D3_PartialClasses
{
    internal class Program
    {
        void Test() {
            Console.WriteLine("Ciao");
        }

        static void TestS() {
            Console.WriteLine("Ciao");
        }
        static void Main(string[] args) {
            MyClass.StaticValue = 15;
            Console.WriteLine(MyClass.StaticValue);

            MyClass c = new MyClass();
            c.Value = 10;
            c.Print();

            MyClass c1 = new MyClass { Value = 15 };
            MyClass c2 = new MyClass { Value = 20 };

            MyClass.StaticValue = 40;

            c1.Print();
            c2.Print();

            new Program().Test();
            TestS();
        }
    }
}
