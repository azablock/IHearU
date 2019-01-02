using System.Collections.Generic;
using System.Linq;
using Models.MarkovChain;
using Models.Voice.Harmony.Model;

namespace Models.Voice.Harmony.Generator {
  public class MarkovChainHarmonyGenerator : IHarmonyGenerator<MarkovChainHarmonyGenerationEvent, Queue<int>> {
    private readonly ScaleMarkovChain _markovChain;

    public MarkovChainHarmonyGenerator(ScaleMarkovChain markovChain) {
      _markovChain = markovChain;
    }

    public Queue<int> Generate(MarkovChainHarmonyGenerationEvent input) {
      var intervals = new List<int>();
      var currentInterval = SourceHarmonyInterval(input.Voice);

      for (var i = 0; i < input.NoteCount; i++) {
        var nextInterval = _markovChain.Decide(currentInterval);
        currentInterval = nextInterval;
        intervals.Add(currentInterval);
      }

      return new Queue<int>(intervals);
      
    }

    public int SourceHarmonyInterval(MusicVoice voice) {
      var targetMidiValue = voice.IsEmpty ? voice.KeyRootMidiValue : voice.MusicPhrase.Last(note => !note.IsPause).MidiValue;
      return MusicKey.IntervalBy(voice.KeyRootMidiValue, targetMidiValue);
    }
  }
}