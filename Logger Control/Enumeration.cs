namespace Singleton_Pattern
{
    /// <summary>
    /// Classe que detém os Enumeradores para controle do Log
    /// </summary>
    public class Enumeration
    {
        /// <summary>
        /// Enumerador referente ao Nível do Erro ocorrido
        /// </summary>
        public enum ErrorLevel
        {
            Baixo = 0,
            Medio = 1,
            Alto = 2,
            Critico = 3
        }

        /// <summary>
        /// Enumerador referente aoTipo de log
        /// </summary>
        public enum LogType
        {
            Info = 0,
            Error = 1
        }
    }
}
