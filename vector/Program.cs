using vector;

internal class Program
{
    private static void Main(string[] args)
    {

        Console.WriteLine("=== Prueba ===");
        int[] data = { 1, 1, 2, 3, 4};
        Vectorclase vector = new Vectorclase(data.Length);
        for (int i = 0; i < data.Length; i++)
        {
            vector.ponerelemento(i, data[i]);
        }

        Console.WriteLine("Array original:");
        for (int i = 0; i < data.Length; i++)
        {
            Console.Write(vector.obtenerelemento(i) + " ");

        }

        Console.WriteLine();

        int[] data2 = { 1, 2, 3, 4 };
        Vectorclase vector2 = new Vectorclase(data2.Length);
        for (int i = 0; i < data2.Length; i++)
        {
            vector2.ponerelemento(i, data2[i]);
        }






        Console.WriteLine(vector.Subconjunto(vector2));
        for (int i = 0; i < vector.obtenerlongitud(); i++)
        {
            Console.Write(vector.obtenerelemento(i)+" ");
        }
        Console.WriteLine();










    }
}