using System.Collections.Immutable;
using Models.Voice.Harmony.Model;

namespace Models.MarkovChain.MarkovChainFactory {
  
  public class TwoNotesScaleMarkovChainFactory : IMarkovChainFactory<ScaleMarkovChain> {
  
    public ScaleMarkovChain NewInstance() {
      var transitionDFsharp = new MarkovChainTransition<int>(NoteInterval.ROOT, NoteInterval.FIFTH, 1.0f);
      var transitionFsharpD = new MarkovChainTransition<int>(NoteInterval.FIFTH, NoteInterval.ROOT, 1.0f);

      var transitions = ImmutableHashSet.Create(transitionDFsharp, transitionFsharpD);

      return new ScaleMarkovChain(transitions);
    }
  }
}