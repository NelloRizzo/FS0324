namespace U1_D2_Arrays
{
    internal class Program
    {
        static void Main(string[] args) {
            int[] numbers = { 425, 25436, 45367, 598, 234, 546798, 4568, 5789, 6980, 256, 4679, 609 };

            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] % 2 == 0)
                    sumEven += numbers[i];
                else
                    sumOdd += numbers[i];
            }
            Console.WriteLine("Somma dei numeri dispari: " + sumOdd + " e dei numeri pari: " + sumEven);
        }
    }
}
