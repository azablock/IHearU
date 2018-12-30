using System.Collections.Generic;
using System.Linq;
using Models.MarkovChain;
using Models.Voice.Harmony.Model;

namespace Models.Voice.Harmony.Generator {
  public class MarkovChainHarmonyGenerator : IHarmonyGenerator<int, Queue<int>> {
    private readonly ScaleMarkovChain _markovChain;

    public MarkovChainHarmonyGenerator(ScaleMarkovChain markovChain) {
      _markovChain = markovChain;
    }

    public Queue<int> Generate(int noteCount) {
      var intervals = new List<int>();

      for (var i = 0; i < noteCount; i++) {
        intervals.Add(NoteInterval.ROOT);
      }

      return new Queue<int>(intervals.Select(interval => _markovChain.Decide(interval)));
    }
  }
}