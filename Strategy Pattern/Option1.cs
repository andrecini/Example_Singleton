using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern.Strategy_Pattern
{
    /// <summary>
    /// Opção: "Cadastro Aluno"
    /// </summary>
    public class Option1 : IStrategy
    {
        /// <summary>
        /// Realiza a Lógica da Opção 1 => Pega dados do Aluno
        /// </summary>
        /// <param name="aluno">Aluno Atual</param>
        public void DoLogic(ref Aluno aluno)
        {
            aluno = SetNewAluno(ref aluno);
        }

        #region Métodos GetDados 
        //Define o novo Aluno
        private Aluno SetNewAluno(ref Aluno aluno)
        {
            Console.WriteLine("\nDigite os dados solicitados para o cadastro:");

            Console.Write("\nNome: ");
            GetNome(ref aluno);
            Console.Write("\nRA: ");
            GetRA(ref aluno);

            return aluno;
        }

        //Pega o Nome
        private void GetNome(ref Aluno aluno)
        {
            while (true)
            {
                try
                {
                    aluno.Nome = Console.ReadLine().Trim();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    Console.Write("\nNome: ");
                }
            }
        }

        //Pega o RA
        private void GetRA(ref Aluno aluno)
        {
            while (true)
            {
                try
                {
                    aluno.RA = Console.ReadLine().Trim();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    Console.Write("RA: ");
                }
            }
        }
        #endregion
    }
}
