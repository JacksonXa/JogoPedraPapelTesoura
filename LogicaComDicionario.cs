namespace JogoPedraPapelTesoura
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            /*Nessa estrutura, caso hajam novas jogadas possiveis, será necessario adiciona-las 
             * em ambos os dicionários de Jogadas e Condicoes, o restante da lógica continuara 
             * funcionando sem problemas
             */

            string jogadaJogador1 = "pedra";
            string jogadaJogador2 = "spock";

            // Chama a função para determinar o vencedor
            string vencedor = DeterminaVencedor(jogadaJogador1, jogadaJogador2);

            // Imprime o vencedor
            Console.WriteLine($"O vencedor é: {vencedor}");
        }


        // Esta função retorna um dicionário que mapeia as jogadas e atribui um número
        // para cada jogada diferente
        static Dictionary<string, int> ObtemJogadasPossiveis()
        {
            return new Dictionary<string, int>
            {
                {"pedra", 1},
                {"papel", 2},
                {"tesoura", 3},
                {"lagarto", 4},
                {"spock", 5}
            };
        }

        // Esta função retorna um dicionário que mapeia as jogadas para uma lista de jogadas que vencem
        static Dictionary<string, string[]> ObterCondicaoVitoria()
        {
            return new Dictionary<string, string[]>
            {
                {"pedra", new[] { "tesoura", "lagarto"}},
                {"papel", new[] { "pedra", "spock"}},
                {"tesoura", new[] { "papel", "spock"}},
                {"lagarto", new[] { "papel", "tesoura"}},
                {"spock", new[] { "lagarto", "pedra"}},
            };
        }

        // Esta função determina o vencedor do jogo
        static string DeterminaVencedor(string jogadaJogador1, string jogadaJogador2)
        {
            // Obtém os dicionários de movimentos e condições de vitória
            Dictionary<string, int> moves = ObtemJogadasPossiveis();
            Dictionary<string, string[]> winConditions = ObterCondicaoVitoria();

            // Obtém os valores das jogadas dos jogadores
            int moveJogador1 = moves[jogadaJogador1];
            int moveJogador2 = moves[jogadaJogador2];

            // Determina o vencedor
            if (moveJogador1 == moveJogador2)
            {
                return "empate";
            }
            //Se dentro da lista de condições de vitoria da jogada do jogador1
            //contiver o que foi jogado pelo jogador 2, a vitória é do jogador 1
            else if (winConditions[jogadaJogador1].Contains(jogadaJogador2))
            {
                return $"jogador 1 que jogou {jogadaJogador1}";
            }
            //Caso não tenha, como ja foi visto que não é empate, a vitória pode
            //ser apenas do jogador 2
            else
            {
                return $"jogador 2 que jogou {jogadaJogador2}";
            }
        }
    }
}