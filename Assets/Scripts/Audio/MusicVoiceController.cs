using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.CellularAutomata;
using Models.Voice;
using Models.Voice.Harmony.Model;
using Models.Voice.Rhythm.Model;
using Models.Voice.Rhythm.Util;
using Scriptable_Objects_Definitions.Voice;
using Scriptable_Objects_Definitions.Voice.Harmony;
using Scriptable_Objects_Definitions.Voice.Rhythm;
using UnityEngine;

namespace Audio {
  public class MusicVoiceController : MonoBehaviour {
    
    public string deviceName;
    public RhythmProvider rhythmProvider;
    public HarmonyProvider harmonyProvider;
    public MusicVoiceFilter[] musicVoiceFilters;
    
    private GameOfLifeCellularAutomataHolder _gameOfLifeHolder;
    private MidiSender _midiSender;

    public GameOfLifeCellularAutomata GameOfLifeCellularAutomata => _gameOfLifeHolder.Automata;
    public MusicVoice Voice { get; private set; }

    private void Start() {
      _midiSender = new MidiSender(deviceName);
      _gameOfLifeHolder = GetComponent<GameOfLifeCellularAutomataHolder>();
      Voice = new MusicVoice(OctaveNoteRange.From(harmonyProvider.noteRange));

      var repeatRate = Metronome.LengthMillisByMeasure(rhythmProvider.measure) / 1000.0f;
      InvokeRepeating(nameof(PlayNote), 1.0f, repeatRate);
    }

    private void OnDestroy() {
      _midiSender.Destroy();
    }

    private Task PlayNote() {
      if (Voice.PhraseAlreadyPlayed) {
        Voice.AddMusicPhrase(GeneratedPhrase());
      }

      musicVoiceFilters.ToList().ForEach(filter => filter.Filter(this));

      return _midiSender.PlayNoteAsync(Voice.UseNextNote());
    }
    
    //todo to refactor
    private IEnumerable<Note> GeneratedPhrase() {
      _gameOfLifeHolder.UpdateCellularAutomata();

      Voice.RhythmPattern = rhythmProvider.Provide(this);
      Voice.HarmonyPattern = harmonyProvider.Provide(this);

      return Voice.RhythmPattern.Select(rhythmData => NoteFrom(rhythmData, Voice.HarmonyPattern));
    }

    //todo to be moved (or deleted?)
    private Note NoteFrom(RhythmData rhythmData, Queue<int> harmony) {
      return rhythmData.IsPause
        ? Note.Pause(rhythmData.LengthMillis, 0.0f)
        : Note.Of(harmony.Dequeue() + Voice.NoteRange.Offset, rhythmData.LengthMillis, 0.0f);
    }
  }
}