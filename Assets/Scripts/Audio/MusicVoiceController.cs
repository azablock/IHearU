using System.Collections.Generic;
using System.Linq;
using Models.Voice;
using Models.Voice.Rhythm.Generator;
using Models.Voice.Util;
using ScriptableObjectsDefinitions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio {
  public class MusicVoiceController : MonoBehaviour {

    public string deviceName;

//    [FormerlySerializedAs("RhythmProvider")]
//    public RhythmProvider rhythmProvider; //todo
    private MidiSender _midiSender;
    private GameObject _gameOfLifeManager;
    private MusicVoice _voice = new MusicVoice();
    
    private void Start() {
      _gameOfLifeManager = GameObject.FindWithTag("GameOfLifeManager");
      _midiSender = new MidiSender(deviceName);

      InvokeRepeating(nameof(PlayNote), 1.0f, 0.345f); //118 BPM -> 0.127 s == 16th length, 0.254f == 8th length
    }

    private void OnDestroy() {
      _midiSender.Destroy();
    }

    private void PlayNote() {
      if (_voice.IsEmpty) {
        _voice.AddMusicPhrase(NewRhythm());
        var str = "";
        _voice.MusicPhrase.ForEach(note => str += note.IsPause ? "0" : "1");
        Debug.Log(str);
      }
      
      _midiSender.Send(_voice.NextNote());
    }

    private IEnumerable<Note> NewRhythm() {
      var gameOfLifeController = _gameOfLifeManager.GetComponent<GameOfLifeCellularAutomataController>();
      gameOfLifeController.UpdateCellularAutomata();

      return new GameOfLifeRhythmGenerator().Generate(gameOfLifeController.Automata).ToList();
    }
  }
}