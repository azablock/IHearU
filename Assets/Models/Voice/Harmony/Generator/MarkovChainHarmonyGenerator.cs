using System.Collections.Generic;
using System.Linq;
using Models.MarkovChain;
using Models.Voice.Harmony.Generator.Model;
using Models.Voice.Harmony.Model;

namespace Models.Voice.Harmony.Generator {
  
  public class MarkovChainHarmonyGenerator : IHarmonyGenerator<MusicVoice, Queue<int>> {
  
    private readonly ScaleMarkovChain _markovChain;

    public MarkovChainHarmonyGenerator(ScaleMarkovChain markovChain) {
      _markovChain = markovChain;
    }

    public Queue<int> Generate(MusicVoice voice) {
      var intervals = new List<int>();
      var currentInterval = SourceHarmonyInterval(voice);
      var noteCount = voice.RhythmPattern.Count(rhythmData => !rhythmData.IsPause);

      for (var i = 0; i < noteCount; i++) {
        var nextInterval = _markovChain.Decide(currentInterval);
        currentInterval = nextInterval;
        intervals.Add(currentInterval);
      }

      return new Queue<int>(intervals);
    }

    private static int SourceHarmonyInterval(MusicVoice voice) {
      var targetMidiValue = voice.IsEmpty ? voice.KeyRootMidiValue : voice.MusicPhrase.Last(note => !note.IsPause).MidiValue;
      return NoteInterval.IntervalBy(voice.KeyRootMidiValue, targetMidiValue);
    }
  }
}