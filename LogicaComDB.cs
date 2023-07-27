using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace JogoPedraPapelTesoura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Nessa estrutura, caso hajam novas jogadas possiveis, basta adiciona-las ao banco de dados
             * e a lógica continuara funcionando sem problemas, pois não existem dados em hardcode             * 
             */

            // Conexão ao banco de dados
            SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Local;Integrated Security=True;TrustServerCertificate=true;");

            // Inicializa as variáveis para armazenar as jogadas dos jogadores
            string jogadaJogador1 = "Papel";
            string jogadaJogador2 = "Spock";
            bool vencedor;

            // Valida se há empate
            if (jogadaJogador1 == jogadaJogador2)
            {
                Console.WriteLine("Empate");
            }
            else
            {
                // Executa a consulta para obter as regras do jogo
                SqlCommand command = new SqlCommand($"SELECT Vence FROM RegrasJogo WHERE Jogada = " +
                    $"'{jogadaJogador1}' AND Vence LIKE '%{jogadaJogador2}%'", connection);

                connection.Open();

                // Obtém os resultados da consulta
                SqlDataReader reader = command.ExecuteReader();
                vencedor = reader.Read();

                // Verifica se a consulta retornou True ou False, onde True significa que o Jogador 1 ganhou
                // e False significa que o Jogador 2 ganhou
                if (vencedor)
                {
                    Console.WriteLine("Jogador 1 Ganhou");
                }
                else
                {
                    Console.WriteLine("Jogador 2 Ganhou");
                }

                connection.Close();

            }            
        }
    }
}