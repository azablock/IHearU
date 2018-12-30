using System.Collections.Generic;
using System.Linq;

namespace Models.MarkovChain {

  public interface IMarkovChain<T> {

    T Decide(T vertex);
    HashSet<T> Vertices();
    HashSet<MarkovChainTransition<T>> Transitions();
    IEnumerable<MarkovChainTransition<T>> TransitionsEnteringTo(T vertex);
    IEnumerable<MarkovChainTransition<T>> TransitionsExitingFrom(T vertex);
  }
}