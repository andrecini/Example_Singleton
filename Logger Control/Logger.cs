using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Singleton_Pattern
{
    public class Logger : ILogger
    {
        #region Singleton
        
        private static Logger _instance; //Variável estática privada para controle da instância única.
        
        private Logger() { } //Construtor Padrão privado para utilização interna.

        /// <summary>
        /// Método Global que retorna uma instãncia única da Classe logger.
        /// </summary>
        /// <param name="path">Endereço do Arquivo Log</param>
        /// <returns>Instância única do objeto</returns>
        public static Logger GetSingleInstance()
        {
            //Verifica se a Classe Logger já foi instânciada, caso não tenha sido,
            //cria uma nova instância da mesma
            if (_instance == null)
            {
                _instance = new Logger();
            }

            //Retorna uma instância única do objeto
            return _instance;
        }

        #endregion

        #region Variáveis Locais
        //Caminho padrão: ".../bin/Debug"
        private const string loggerPath = "Log.txt";

        //Mensagens dos Enumeradores
        private string[] errorLevels = { "Baixo", "Médio", "Alto", "Crítico" };
        private string[] LogTypes = { "Info", "Erro" };
        #endregion

        #region Métodos Para Mensagens Log
        //Retorna a mensagem base (Hora + Tipo da Mensagem)
        private string GetBaseMessage(Enumeration.LogType type)
        {
            return string.Format("{0} - Log Type: {1} - ", DateTime.Now.ToString("dd/MM/yy HH:mm:ss.fff"), LogTypes[(int)type]);
        }

        /// <summary>
        /// Método para Escrever uma mensagem de informação no Log
        /// </summary>
        /// <param name="conteudo">Mensagem para o Log</param>
        public void Info(string conteudo)
        {
            string message = GetBaseMessage(Enumeration.LogType.Info) + "Message: " + conteudo + "\n";

            File.AppendAllText(loggerPath, message);
        }

        /// <summary>
        /// Método para Escrever uma mensagem de erro no Log
        /// </summary>
        /// <param name="conteudo">Mensagem para o Log</param>
        /// <param name="level">Nível do Erro</param>
        public void Error(string conteudo, Enumeration.ErrorLevel level)
        {
            string message = GetBaseMessage(Enumeration.LogType.Error) + "Error Level: " + errorLevels[(int)level] + " - Message: " + conteudo + "\n";

            File.AppendAllText(loggerPath, message);
        }

        /// <summary>
        /// Apaga todas as linhas do Arquivo Log
        /// </summary>
        public void Reset()
        {
            File.WriteAllText(loggerPath, "");
        }
        #endregion
    }
}
