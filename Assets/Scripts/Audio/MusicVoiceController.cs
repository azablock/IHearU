using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.CellularAutomata;
using Models.Voice;
using Models.Voice.Harmony.Model;
using Models.Voice.Rhythm.Model;
using Scriptable_Objects_Definitions.Voice.Harmony;
using Scriptable_Objects_Definitions.Voice.Rhythm;
using UnityEngine;

namespace Audio {
  public class MusicVoiceController : MonoBehaviour {
    
    public string deviceName;

    public RhythmProvider rhythmProvider;
    public HarmonyProvider harmonyProvider;
    
    private GameOfLifeCellularAutomataHolder _gameOfLifeHolder;
    private MidiSender _midiSender;

    private void Start() {
      _midiSender = new MidiSender(deviceName);
      _gameOfLifeHolder = GetComponent<GameOfLifeCellularAutomataHolder>();

      InvokeRepeating(nameof(PlayNote), 1.0f, 0.254f); //118 BPM -> 0.127 s == 16th length, 0.254f == 8th length
    }

    private void OnDestroy() {
      _midiSender.Destroy();
    }

    public GameOfLifeCellularAutomata GameOfLifeCellularAutomata => _gameOfLifeHolder.Automata;

    public MusicVoice Voice { get; } = new MusicVoice(OctaveNoteRange.C0_C1);

    private Task PlayNote() {
      if (Voice.PhraseAlreadyPlayed) {
        Voice.AddMusicPhrase(GeneratedPhrase());
      }

      return _midiSender.PlayNoteAsync(Voice.NextNote());
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
        ? Note.Pause(0.254f, 0.0f)                                                 //todo
        : Note.Of(harmony.Dequeue() + Voice.NoteRange.Offset, 0.254f, 0.0f);  //todo
    }
  }
}