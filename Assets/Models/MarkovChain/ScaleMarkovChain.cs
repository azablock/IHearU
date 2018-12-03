using System.Collections.Generic;
using System.Linq;
using Models.Voice;

namespace Models.MarkovChain {

  public class ScaleMarkovChain : IMarkovChain<Note> {
    private readonly HashSet<Note> _vertices;
    private readonly HashSet<MarkovChainTransition<Note>> _transitions;

    public ScaleMarkovChain(HashSet<Note> vertices, HashSet<MarkovChainTransition<Note>> transitions) {
      _vertices = vertices;
      _transitions = transitions;
    }

    public HashSet<Note> Vertices() {
      return _vertices;
    }

    public HashSet<MarkovChainTransition<Note>> Transitions() {
      return _transitions;
    }

    public IEnumerable<MarkovChainTransition<Note>> TransitionsEnteringTo(Note vertex) {
      return _transitions.Where(transition => transition.To.MidiValue == vertex.MidiValue);
    }

    public IEnumerable<MarkovChainTransition<Note>> TransitionsExitingFrom(Note vertex) {
      return _transitions.Where(transition => transition.From.MidiValue == vertex.MidiValue);
    }
  }
}