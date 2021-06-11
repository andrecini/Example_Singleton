using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_Pattern
{
    public class Aluno
    {
        //Instância do objeto Logger
        private ILogger logger = Logger.GetSingleInstance();

        #region Propriedades
        private string _nome;
        private string _ra;
        private decimal? _nota1 = null;
        private decimal? _nota2 = null;

        public string Nome
        {
            get => _nome;
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    logger.Error("Nome passado como nulo/vazio", Enumeration.ErrorLevel.Medio);
                    throw new Exception("O Nome não pode ser nulo/vazio. Preencha corretamente!");
                }
                else
                {
                    logger.Info("Estrutura da propriedade nome passada corretamente.");
                    _nome = value;
                }
            }
        }

        public string RA
        {
            get => _ra;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    logger.Error("RA passado como nulo/vazio", Enumeration.ErrorLevel.Medio);
                    throw new Exception("O RA não pode ser nulo/vazio. Preencha corretamente!");
                }
                else if(value.Length < 4)
                {
                    logger.Error(string.Format("RA passado com apenas {0} caracteres.", value.Length), Enumeration.ErrorLevel.Baixo);
                    throw new Exception("O RA deve ser passado com pelo menos 4 caracteres. Preencha corretamente!");
                }
                else
                {
                    logger.Info("Estrutura da propriedade RA passada corretamente.");
                    _ra = value;
                }
            }
        }

        public decimal Nota1
        { 
            get => (decimal)_nota1;
            set
            {
                if (value > 10 || value < 0)
                {
                    logger.Error(string.Format("Nota 1 passada incorretamente. Nota: {0}", value), Enumeration.ErrorLevel.Alto);
                    throw new Exception("A nota deve estar entre 0 e 10. Preencha corretamente!");
                }
                else
                {
                    logger.Info("Estrutura da propriedade Nota1 passada corretamente.");
                    _nota1 = value;
                }
            }
        }

        public decimal Nota2
        {
            get => (decimal)_nota2;
            set
            {
                if (value > 10 || value < 0)
                {
                    logger.Error(string.Format("Nota 2 passada incorretamente. Nota: {0}", value), Enumeration.ErrorLevel.Alto);
                    throw new Exception("A nota deve estar entre 0 e 10. Preencha corretamente!");
                }
                else
                {
                    logger.Info("Estrutura da propriedade Nota2 passada corretamente.");
                    _nota2 = value;
                }
            }
        }

        public decimal Media
        { 
            get
            {
                if(_nota1 == null || _nota2 == null)
                {
                    logger.Error("Tentativa de calcular a Média sem informar a nota.", Enumeration.ErrorLevel.Medio);
                    throw new Exception("Nenhuma nota Informada. Informe as Notas primeiro e tente novamente!");
                }
                else 
                {
                    logger.Info("Média Calculada com Sucesso!");
                    return ((decimal)_nota1 + (decimal)_nota2) / 2;
                }
            }
        }

        #endregion
    }
}
