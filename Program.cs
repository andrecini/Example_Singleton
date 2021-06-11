using Singleton_Pattern.Strategy_Pattern;
using System;

namespace Singleton_Pattern
{
    class Program
    {
        //Variável referente ao objeto Logger
        private static ILogger logger = Logger.GetSingleInstance();

        static void Main(string[] args)
        {
            Aluno aluno = new Aluno();
            
            Console.WriteLine("Bem vindo ao Programa de Exemplificação do Padrão Singleton...");
                        
            int opcao = GetOpcao();

            //Enquanto não for escolhida a opção de sair...
            while (opcao != 3)
            {
                DoOption(opcao, ref aluno);
                
                //Pergunta a opção novamente
                opcao = GetOpcao();
            }

            Console.Write("\nDigite 'Enter' para Fechar...");

            logger.Info("Saindo do programa!");

            Console.ReadLine();
        }

        //Pergunta e pega a Opção desejada pelo cliente
        private static int GetOpcao()
        {
            Console.WriteLine("\n1 - Cadastro Aluno\t2 - Verifica Média\t3 - Sair");
            Console.Write("\nDigite a Opção desejada: ");
            
            string opcao = Console.ReadLine().Trim();
            
            //Enquanto não for digitada uma opção válida...
            while (opcao != "1" && opcao != "2" && opcao != "3")
            {
                logger.Error(string.Format("Opção Digitada incoretamente: '{0}'", opcao), Enumeration.ErrorLevel.Baixo);
                Console.WriteLine("\nDigite uma opção Válida!\n");

                Console.Write("Digite a Opção desejada: ");
                opcao = Console.ReadLine().Trim();
            }

            logger.Info(string.Format("Opção '{0}' digitada.", opcao));

            //Retorna a opção desejada como short
            return Convert.ToInt16(opcao);
        }

        //Realiza a Ação a partir da Opção escolhida
        private static void DoOption(int option, ref Aluno aluno)
        {
            try
            {
                Context context = new Context();

                context.SetStrategy(option);
                logger.Info(string.Format("Estratégia 'Option{0}' definida no Contexto.", option));

                context.DoCurrentOption(ref aluno);
                logger.Info(string.Format("Estratégia 'Option{0}' executada.", option));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex.Message, Enumeration.ErrorLevel.Critico);
            }
            
        }
    }
}
