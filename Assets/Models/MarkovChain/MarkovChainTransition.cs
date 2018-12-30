namespace Models.MarkovChain {

  public class MarkovChainTransition<T> {

    public MarkovChainTransition(T from, T to, float probability) {
      From = from;
      To = to;
      Probability = probability;
    }

    public T From { get; }

    public T To { get; }

    public float Probability { get; }
  }
}