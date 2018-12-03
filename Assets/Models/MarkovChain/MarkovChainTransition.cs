namespace Models.MarkovChain {

  public class MarkovChainTransition<T> {
    
    private readonly T _from;
    private readonly T _to;
    private readonly float _probability;

    public MarkovChainTransition(T from, T to, float probability) {
      _from = from;
      _to = to;
      _probability = probability;
    }

    public T From {
      get { return _from; }
    }

    public T To {
      get { return _to; }
    }

    public float Probability {
      get { return _probability; }
    }
  }
}