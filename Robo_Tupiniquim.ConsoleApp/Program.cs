namespace Robo_Tupiniquim.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int colunas, linhas;
            int roboX, roboY;
            char direcao;
            string instrucoes;

            TamanhoMapa(out colunas, out linhas);

            PosicaoRobo(colunas, linhas, out roboX, out roboY);

            direcao = DirecaoRobo();

            instrucoes = ColetandoCoordenadas();

            MovendoRobo(colunas, linhas, ref roboX, ref roboY, ref direcao, instrucoes);

            ExibirResultado(roboX, roboY, direcao);
        }

        #region Movendo Robo
        private static void MovendoRobo(int colunas, int linhas, ref int roboX, ref int roboY, ref char direcao, string instrucoes)
        {
            for (int i = 0; i < instrucoes.Length; i++)
            {
                if (instrucoes[i] == 'E')
                {
                    VirarEsquerda(ref direcao);
                }
                else if (instrucoes[i] == 'D')
                {
                    VirarDireita(ref direcao);
                }
                if (instrucoes[i] == 'M')
                {
                    Mover(ref direcao, ref roboX, ref roboY);
                }
                VerificaSeRoboEstaNoGrid(roboX, roboY, colunas, linhas);
            }
        }
        #endregion

        #region Atribui Direção ao Robo
        private static char DirecaoRobo()
        {
            Console.WriteLine("informe a direção do robô");
            char direcao = Convert.ToChar(Console.ReadLine().ToUpper());
            VerificaDirecao(direcao);
            return direcao;
        }
        #endregion

        #region Atribui Posicao ao Robo
        private static void PosicaoRobo(int colunas, int linhas, out int roboX, out int roboY)
        {
            Console.WriteLine("Digite o X do robô");
            roboX = Convert.ToInt32(Console.ReadLine());
            VerificaInput(colunas, roboX);

            Console.WriteLine("Digite o Y do robô");
            roboY = Convert.ToInt32(Console.ReadLine());
            VerificaInput(linhas, roboY);
        }
        #endregion

        #region Coletando Coordenadas
        private static string ColetandoCoordenadas()
        {
            Console.WriteLine("Informe as coordenadas do robô:");
            string instrucoes = Console.ReadLine().ToUpper();
            char[] instrucoesArray = instrucoes.ToCharArray();
            return instrucoes;
        }
        #endregion

        #region Verifica Direção
        private static void VerificaDirecao(char direcao)
        {
            if (direcao != 'N' && direcao != 'S' && direcao != 'L' && direcao != 'O')
            {
                Console.WriteLine("Erro: Direção inválida...");
            }
        }
        #endregion

        #region Coleta o Tamanho do Mapa
        private static void TamanhoMapa(out int colunas, out int linhas)
        {
            Console.WriteLine("digite o tamanho de colunas");
            colunas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("digite o tamanho de linhas");
            linhas = Convert.ToInt32(Console.ReadLine());
        }
        #endregion

        #region Verifica Valor Digitado
        private static void VerificaInput(int colunas, int roboX)
        {
            if (roboX > colunas || roboX < 0)
            {
                while (roboX > colunas || roboX < 0)
                {
                    Console.WriteLine("Erro: Limite de alcance...");
                    Console.WriteLine($"Digite um valor menorou igual à: {colunas}");
                    roboX = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        #endregion

        #region VirarEsquerda
        private static void VirarEsquerda(ref char direcao)
        {
            switch (direcao)
            {
                case 'N':
                    direcao = 'O';
                    break;
                case 'O':
                    direcao = 'S';
                    break;
                case 'S':
                    direcao = 'L';
                    break;
                case 'L':
                    direcao = 'N';
                    break;
            }

        }
        #endregion

        #region VirarDireita
        private static void VirarDireita(ref char direcao)
        {
            switch (direcao)
            {
                case 'N':
                    direcao = 'L';
                    break;
                case 'L':
                    direcao = 'S';
                    break;
                case 'S':
                    direcao = 'O';
                    break;
                case 'O':
                    direcao = 'N';
                    break;
            }
        }
        #endregion

        #region Mover
        private static void Mover(ref char direcao, ref int roboX, ref int roboY)
        {
            switch (direcao)
            {
                case 'N':
                    roboY++;
                    break;
                case 'L':
                    roboX++;
                    break;
                case 'S':
                    roboY--;
                    break;
                case 'O':
                    roboX--;
                    break;
            }
        }
        #endregion

        #region Verifica Se Robo Esta No Grid
        private static void VerificaSeRoboEstaNoGrid(int RoboX, int RoboY, int colunas, int linhas)
        {
            if (RoboX < 0)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
            else if (RoboY < 0)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
            else if (RoboX > colunas)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
            else if (RoboY > linhas)
            {
                Console.WriteLine("Erro: Limite de alcance...");
            }
        }
        #endregion

        #region ExibirResultado
        private static void ExibirResultado(int roboX, int roboY, char direcao)
        {
            Console.WriteLine($"{roboX},{roboY} {direcao}");
            Console.ReadLine();
        }
        #endregion
    }
}
