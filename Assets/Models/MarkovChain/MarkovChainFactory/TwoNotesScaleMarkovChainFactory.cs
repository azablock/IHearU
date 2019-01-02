using System.Collections.Immutable;
using Models.Voice.Harmony.Model;

namespace Models.MarkovChain.MarkovChainFactory {
  
  public class TwoNotesScaleMarkovChainFactory : IMarkovChainFactory<ScaleMarkovChain> {
  
    public ScaleMarkovChain NewInstance() {
      var transRootFifth = new MarkovChainTransition<int>(NoteInterval.ROOT, NoteInterval.MIN_3RD, 0.1f);
      var transRootFajnieJest = new MarkovChainTransition<int>(NoteInterval.ROOT, NoteInterval.MIN_6TH, 0.15f);
      var transRootRoot = new MarkovChainTransition<int>(NoteInterval.ROOT, NoteInterval.ROOT, 0.75f);
      var transRootFajnieJest2 = new MarkovChainTransition<int>(NoteInterval.MIN_6TH, NoteInterval.ROOT, 1.0f);
      var transFifthRoot = new MarkovChainTransition<int>(NoteInterval.MIN_3RD, NoteInterval.MIN_3RD, 1.0f); //todo min3 -> root

      var transitions = ImmutableHashSet.Create(transRootFifth, transRootRoot, transFifthRoot, transRootFajnieJest, transRootFajnieJest2);

      return new ScaleMarkovChain(transitions);
    }
  }
}