namespace U1_D3_Ex3
{
    internal class Program
    {
        static void Process(int[] numbers) {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++) {
                sum += numbers[i];
            }
            Console.WriteLine($"Somma: {sum}");
            Console.WriteLine($"Media: {1.0 * sum / numbers.Length}");
        }

        static void Main(string[] args) {
            int[] n = { 34, 24365, 438675, 3242, 46738, 78596, 2435, 54678, 5679, 4567, 458679, 707070 };
            Process(n);
        }
    }
}
