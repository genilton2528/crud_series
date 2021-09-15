using System;
using DIO.Series.Classes;
using DIO.Series.Enums;

namespace DIO.Series
{
    class Program
    {
        private static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcao = ObterOpcaoUsuario();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }
        
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
        
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indice = int.Parse(Console.ReadLine());

			repositorio.Exclui(indice);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indice = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indice);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indice = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string titulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string descricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indice,
										genero: (Genero)genero,
										titulo: titulo,
										ano: ano,
										descricao: descricao);

			repositorio.Atualiza(indice, atualizaSerie);
		}
        
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.ReturnExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.ReturnId(), serie.ReturnTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int genero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string titulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int ano = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string descricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)genero,
										titulo: titulo,
										ano: ano,
										descricao: descricao);

			repositorio.Insere(novaSerie);
		}
    }
}
