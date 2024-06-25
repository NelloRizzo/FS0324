internal class Program
{
    #region Initial samples
    static void SortAsc(int[] array) {
        for (int i = 0; i < array.Length - 1; i++) {
            for (int j = i + 1; j < array.Length; j++) {
                if (array[i] > array[j]) {
                    // old style
                    //int t = array[i]; array[i] = array[j]; array[j] = t;
                    // le parentesi tonde introducono il concetto di TUPLA
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }
    }

    static void SortDesc(int[] array) {
        for (int i = 0; i < array.Length - 1; i++) {
            for (int j = i + 1; j < array.Length; j++) {
                if (array[i] < array[j]) {
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }
    }
    #endregion

    #region External functions
    //static bool SwapForAscendingSort(int a, int b) { return a > b; }
    static bool SwapForAscendingSort(int a, int b) => a > b;
    static bool SwapForDescendingSort(int a, int b) { return a < b; }

    static void SortAscWithExternalFunction(int[] array) {
        for (int i = 0; i < array.Length - 1; i++) {
            for (int j = i + 1; j < array.Length; j++) {
                if (SwapForAscendingSort(array[i], array[j])) {
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }
    }
    static void SortDescWithExternalFunction(int[] array) {
        for (int i = 0; i < array.Length - 1; i++) {
            for (int j = i + 1; j < array.Length; j++) {
                if (SwapForDescendingSort(array[i], array[j])) {
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }
    }
    #endregion

    #region Delegates

    delegate bool SwapFunc(int a, int b);
    static void SortWithDelegate(int[] array, SwapFunc func) {
        for (int i = 0; i < array.Length - 1; i++) {
            for (int j = i + 1; j < array.Length; j++) {
                if (func(array[i], array[j])) {
                    (array[i], array[j]) = (array[j], array[i]);
                }
            }
        }
    }
    #endregion

    static void Print(int[] array, string message = "Array:") {
        Console.WriteLine(message);
        foreach (int i in array) { Console.WriteLine(i); }
    }

    private static void Main(string[] args) {
        int[] numbers = { 234, 25, 3467, 578, 568, 9, 3453, 46, 4869, 68980, 2, 3546, 36, 680957 };
        Print(numbers);
        SortAsc(numbers);
        Print(numbers, "Ordinamento crescente:");
        SortDesc(numbers);
        Print(numbers, "Ordinamento decrescente:");

        SortWithDelegate(numbers, SwapForAscendingSort);
        Print(numbers, $"Ordinamento crescente con delegato {nameof(SwapForAscendingSort)}");
        SortWithDelegate(numbers, SwapForDescendingSort);
        Print(numbers, $"Ordinamento crescente con delegato {nameof(SwapForDescendingSort)}");
        SortWithDelegate(numbers, (int x, int y) => { return x > y; });
        Print(numbers, "Ordinamento crescente con arrow function");
        SortWithDelegate(numbers, (x, y) => x % 2 == 0 ? x > y : x < y);
        Print(numbers, "Ordinamento 'strano'");
        bool evenFirst = true;
        SortWithDelegate(numbers, (x, y) => x % 2 == 0 && evenFirst ? x > y : x < y);
        Print(numbers, "Ordinamento 'con cattura'");

    }
}