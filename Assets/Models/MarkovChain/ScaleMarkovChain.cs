using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Models.Common;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Models.MarkovChain {

  public class ScaleMarkovChain : IMarkovChain<int> {
    
    private readonly ImmutableHashSet<MarkovChainTransition<int>> _transitions;

    public ScaleMarkovChain(ImmutableHashSet<MarkovChainTransition<int>> transitions) {
      _transitions = transitions;
    }

    //todo remove Unity method usage
    public int Decide(int vertex) {
      var decisionWeight = Random.Range(0.0f, 1.0f);
      var ranges = ProbabilityRangesExitingFrom(vertex);
      var firstOrDefault = ranges.FirstOrDefault(range => range.Key.ContainsValue(decisionWeight));
      var matchedTransition = firstOrDefault.Value;

      return matchedTransition.To;
    }

    public IEnumerable<MarkovChainTransition<int>> Transitions() {
      return _transitions;
    }

    public IEnumerable<MarkovChainTransition<int>> TransitionsEnteringTo(int vertex) {
      return _transitions.Where(transition => transition.To == vertex);
    }

    public IEnumerable<MarkovChainTransition<int>> TransitionsExitingFrom(int vertex) {
      return _transitions.Where(transition => transition.From == vertex);
    }

    public ImmutableDictionary<Range<float>, MarkovChainTransition<int>> ProbabilityRangesExitingFrom(int vertex) {
      var transitions = TransitionsExitingFrom(vertex);
      var probabilityOffset = 0.0f;

      return transitions.Aggregate(
        ImmutableDictionary.Create<Range<float>, MarkovChainTransition<int>>(),
        (ranges, transition) => ranges.Add(Range<float>.Of(probabilityOffset, probabilityOffset += transition.Probability), transition)
      );
    }
  }
}