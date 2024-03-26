namespace Robo_Tupiniquim.ConsoleApp
{
    //Robo Tupiniquim
    internal class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            Console.WriteLine("--------------------");
            Console.WriteLine("| Robo Tupiniquim! |");
            Console.WriteLine("--------------------\n");

            Console.WriteLine("Tamanho da Área a ser Explorada:");
            Console.WriteLine("Digite o tamanho da coordenada X");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o tamanho da coordenada Y");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[,] array2D = new int[x, y];



            //Imprimindo na tela o tamanho do Array Bidimensional
            Console.Write("|");
            
            //Contando os giros de Y e imprimindo
            for (int i = 0; i < y; i++)
            {
                //Imprimindo as casas X
                for (int j = 0; j < x; j++)
                {
                    Console.Write(" |");
                }
                Console.WriteLine();
                //Eliminando o simbolo restante(ajustando o tamanho correto)
                if (i != y-1)
                {
                    Console.Write("|");
                }
            }
        }
    }
}
