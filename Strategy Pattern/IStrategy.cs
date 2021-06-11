namespace Singleton_Pattern.Strategy_Pattern
{
    /// <summary>
    /// Declara a operação comum em diversos algorítmos.
    /// 
    /// O Contexto a utiliza para definir qual Estratégia
    /// Concreta utilizar, que neste caso seriam as opções
    /// escolhidas.
    /// </summary>
    public interface IStrategy
    {
        void DoLogic(ref Aluno aluno);
    }
}
