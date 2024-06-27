using System.Collections;
using System.Security.Authentication;

internal class Program
{
    class MyInt
    {
        public int Value { get; set; }
        public override string ToString() => $"MyInt({Value})";
    }
    class MyString
    {
        public string Value { get; set; }
        public override string ToString() => $"MyInt({Value})";
    }

    class My<T>
    {
        public T Value { get; set; }
        public override string ToString() => $"My({Value})";
    }

    class Pair<F, S>
    {
        public F First { get; set; }
        public S Second { get; set; }
        public override string ToString() => $"Pair(First={First}, Second={Second})";
    }

    class MyPairOfInt : MyInt
    {
        public int SecondValue { get; set; }
        public override string ToString() => $"MyPairOfInt({Value}, {SecondValue})";
    }

    static string mySystemString = "";
    static int mySystemInt = 0;
    static void MySystem(Pair<int, string> pair) {
        mySystemString += pair.Second;
        mySystemInt += pair.First;
    }

    static void Scegli<T1, T2>(T1 t1, T2 t2) where T1 : IComparable<T2> {
        if (t1.CompareTo(t2) > 0) {
            Console.WriteLine($"Ho scelto {t1}");
        }
        else {
            Console.WriteLine($"Ho scelto {t2}");
        }
    }

    class My : IComparable<int>, IComparable<My>
    {
        public int Value { get; set; }

        public int CompareTo(int other) => Value.CompareTo(other);

        public int CompareTo(My? other) => Value.CompareTo(other.Value);

        public override string ToString() => $"My({Value})";
    }



    //static void Scegli(int t1, int t2) {
    //    if (t1.CompareTo(t2) > 0) {
    //        Console.WriteLine($"Ho scelto {t1}");
    //    }
    //    else {
    //        Console.WriteLine($"Ho scelto {t2}");
    //    }
    //}
    //static void Scegli(string t1, string t2) {
    //    if (t1.CompareTo(t2) > 0) {
    //        Console.WriteLine($"Ho scelto {t1}");
    //    }
    //    else {
    //        Console.WriteLine($"Ho scelto {t2}");
    //    }
    //}

    private static void Main(string[] args) {
        Scegli(1, 2);
        Scegli("Uno", "Due");
        Scegli(new My { Value = 1 }, 0);
        var oli = new SortedList<int, string>();
        oli.Add(10, "Dieci");
        oli.Add(1, "Uno");
        oli.Add(-10, "Meno dieci");
        foreach (var i in oli) { Console.WriteLine(i); }

        var ols = new SortedList<string, int>();
        ols.Add("Dieci", 10);
        ols.Add("Uno", 1);
        foreach (var i in ols) { Console.WriteLine(i); }

        var olm = new SortedList<string, My>();
        olm.Add("Primo", new My { Value = 1 });
        olm.Add("Secondo", new My { Value = 2 });
        olm.Add("Quarto", new My{ Value = 3 });
        Console.WriteLine($"Elemento con chiave 'Quattro': {olm["Quarto"]}");

        foreach (var i in olm) { Console.WriteLine(i); }

        var olmm = new SortedList<My, int>();
        olmm.Add(new My { Value = 1 }, 10);
        olmm.Add(new My { Value = -10 }, 1);
        foreach(var i in olmm) { Console.WriteLine( i ); }
    }

    private static void Main1(string[] args) {
        System.Collections.IList list = new System.Collections.ArrayList();
        list.Add(1);
        list.Add("Prova");
        list.Add(DateTime.Today);
        list.Add(new MyInt { Value = 1 });

        foreach (var item in list) { Console.WriteLine(item); }

        list.RemoveAt(1);

        Console.WriteLine("Secondo elemento della lista: {0}", list[1]);

        System.Collections.Generic.IList<MyInt> gl = new System.Collections.Generic.List<MyInt>();
        //gl.Add(1);
        gl.Add(new MyInt { Value = 1 });
        gl.Add(new MyInt { Value = 2 });
        gl.Add(new MyPairOfInt { Value = 3, SecondValue = 4 });

        foreach (var i in gl) { Console.WriteLine(i); }

        My<int> mi = new My<int> { Value = 1 };
        My<string> ms = new My<string> { Value = "Prova" };
        My<DateTime> md = new My<DateTime> { Value = DateTime.Now };

        var pis = new Pair<int, string> { First = 1, Second = "Uno" };
        MySystem(pis);
        MySystem(new Pair<int, string> { First = 10, Second = "Dieci" });
        Console.WriteLine(mySystemString);
        Console.WriteLine(mySystemInt);

    }
}