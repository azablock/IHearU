using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Models.Common;

namespace Models.MarkovChain {

  public interface IMarkovChain<T> {

    T Decide(T vertex);
    IEnumerable<MarkovChainTransition<T>> Transitions();
    IEnumerable<MarkovChainTransition<T>> TransitionsEnteringTo(T vertex);
    IEnumerable<MarkovChainTransition<T>> TransitionsExitingFrom(T vertex);

    ImmutableDictionary<Range<float>, MarkovChainTransition<T>> ProbabilityRangesExitingFrom(T vertex);
  }
}