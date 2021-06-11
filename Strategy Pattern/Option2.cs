using System;

namespace Singleton_Pattern.Strategy_Pattern
{
    /// <summary>
    /// Opção: "Mostrar Média"
    /// </summary>
    public class Option2 : IStrategy
    {
        /// <summary>
        /// Realiza a Lógica da Opção 2 => Mostrar Média
        /// </summary>
        /// <param name="aluno">Aluno Atual</param>
        public void DoLogic(ref Aluno aluno)
        {
            //Se o objeto aluno não possuir os dados iniciais (Nome, RA),
            //é informado para que seja cadastrado primeiro.
            if(!string.IsNullOrEmpty(aluno.Nome))
            {
                Console.Write("\nNota 1: ");
                GetNota1(ref aluno);
                Console.Write("\nNota 2: ");
                GetNota2(ref aluno);

                Console.WriteLine("\nA média do {0} foi de: {1}", aluno.Nome, aluno.Media);
            }
            else
            {
                Console.WriteLine("\nNenhum aluno Cadastrado. Cadastre e tente novamente!");
            }       
        }

        #region GetNotas
        //Pega a Nota 1
        private void GetNota1(ref Aluno aluno)
        {
            while (true)
            {
                try
                {
                    aluno.Nota1 = Convert.ToDecimal(Console.ReadLine().Trim());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    Console.Write("\nNota 1: ");
                }
            }
        }

        //Pega a Nota 2
        private void GetNota2(ref Aluno aluno)
        {
            while (true)
            {
                try
                {
                    aluno.Nota2 = Convert.ToDecimal(Console.ReadLine().Trim());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                    Console.Write("\nNota 2: ");
                }
            }
        }
        #endregion

    }
}
