using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.MarkovChain.MarkovChainFactory;
using Models.Voice;
using Models.Voice.Harmony.Generator;
using Models.Voice.Harmony.Model;
using Models.Voice.Rhythm.Generator;
using Models.Voice.Rhythm.Model;
using UnityEngine;

namespace Audio {
  public class MusicVoiceController : MonoBehaviour {
    
    public string deviceName;

    private MidiSender _midiSender;
    private GameObject _gameOfLifeManager;
    private MusicVoice _voice = new MusicVoice(OctaveNoteRange.C0_C1);

    private void Start() {
      _gameOfLifeManager = GameObject.FindWithTag("GameOfLifeManager");
      _midiSender = new MidiSender(deviceName);

      InvokeRepeating(nameof(PlayNote), 1.0f, 0.254f); //118 BPM -> 0.127 s == 16th length, 0.254f == 8th length
    }

    private void OnDestroy() {
      _midiSender.Destroy();
    }

    private Task PlayNote() {
      if (_voice.PhraseAlreadyPlayed) {
        _voice.AddMusicPhrase(GeneratedPhrase());
        var str = "";
        _voice.MusicPhrase.ForEach(note => str += note.IsPause ? "0" : "1");
        Debug.Log(str);
      }

      return _midiSender.PlayNoteAsync(_voice.NextNote());
    }
    
    private IEnumerable<Note> GeneratedPhrase() {
      var gameOfLifeController = _gameOfLifeManager.GetComponent<GameOfLifeCellularAutomataController>();
      gameOfLifeController.UpdateCellularAutomata();

      var harmonyGenerator = new MarkovChainHarmonyGenerator(new TwoNotesScaleMarkovChainFactory().NewInstance());
      var rhythmPattern = new GameOfLifeRhythmGenerator().Generate(gameOfLifeController.Automata);

      var harmonyGenerationEvent = MarkovChainHarmonyGenerationEvent.Of(_voice, rhythmPattern.Count(rhythmData => !rhythmData.IsPause));
      var harmony = harmonyGenerator.Generate(harmonyGenerationEvent);

      return rhythmPattern.Select(rhythmData => NoteFrom(rhythmData, harmony));
    }

    private Note NoteFrom(RhythmData rhythmData, Queue<int> harmony) {
      return rhythmData.IsPause
        ? Note.Pause(0.254f, 0.0f)                                                 //todo
        : Note.Of(harmony.Dequeue() + _voice.NoteRange.Offset, 0.254f, 0.0f);  //todo
    }
  }
}