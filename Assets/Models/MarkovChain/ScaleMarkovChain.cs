using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Models.MarkovChain {

  public class ScaleMarkovChain : IMarkovChain<int> {
    
    private readonly ImmutableHashSet<MarkovChainTransition<int>> _transitions;

    public ScaleMarkovChain(ImmutableHashSet<MarkovChainTransition<int>> transitions) {
      _transitions = transitions;
    }

    public int Decide(int vertex) {
      var decisionWeight = new Random().Next(0, 1);
      var transitionsExitingFrom = TransitionsExitingFrom(vertex).OrderBy(transition => transition.Probability);
      var matchedDecisionTransition = transitionsExitingFrom.First(transition => transition.Probability > decisionWeight);

      return matchedDecisionTransition.To;
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
  }
}