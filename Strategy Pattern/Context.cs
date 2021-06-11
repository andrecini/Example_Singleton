using System.Collections.Generic;

namespace Singleton_Pattern.Strategy_Pattern
{
    /// <summary>
    /// Define a interface a partir da escolha do Cliente.
    /// </summary>
    public class Context
    {
        //Retorna um Dicionário com todas Opçoes Criadas
        private Dictionary<int, IStrategy> GetAllStrategies()
        {
            Dictionary<int, IStrategy> strategies = new Dictionary<int, IStrategy>();
            
            strategies.Add(1, new Option1());
            strategies.Add(2, new Option2());
            //{ADD_NEW_OPTION_HERE} = strategies.Add(X, new OptionX());

            return strategies;
        }

        //Váriavel paara controle da estratégia desejada
        private IStrategy _strategy;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        public Context() { }

        /// <summary>
        /// Construtor Personalizado que Define a Estratégia automaticamente.
        /// </summary>
        /// <param name="option">Número da opção digitada</param>
        public Context(int option)
        {
            SetStrategy(option);
        }

        /// <summary>
        /// Método para definir a Estratégia a ser utilizada
        /// </summary>
        /// <param name="option">Opção Digitada</param>
        public void SetStrategy(int option)
        {
            //Define a estratégia a partir da chave
            _strategy = GetAllStrategies()[option];
        }

        /// <summary>
        /// Realiza a Lógica referente a Estratégia atual
        /// </summary>
        /// <param name="aluno">Aluno atual</param>
        public void DoCurrentOption(ref Aluno aluno)
        {
            _strategy.DoLogic(ref aluno);
        }
    }
}
