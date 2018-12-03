namespace Models.MarkovChain.MarkovChainFactory {

  public interface IMarkovChainFactory<out T> {

    T NewInstance();
  }
}