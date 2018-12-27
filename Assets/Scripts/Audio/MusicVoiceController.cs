using Models.Voice;
using Models.Voice.Rhythm.Generator;
using ScriptableObjectsDefinitions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio {
  
  public class MusicVoiceController : MonoBehaviour {

    public string deviceName;

    [FormerlySerializedAs("RhythmProvider")]
    public RhythmProvider rhythmProvider;

    private MidiSender _midiSender;
    
    private void Start() {
      _midiSender = new MidiSender(deviceName);
//      var rhythm = rhythmProvider.Provide(); //todo
      var rhythm = new SimpleRhythmGenerator().Generate(16);

      foreach (var note in rhythm) {
        _midiSender.Send(note);
      }
    }

    private void OnDestroy() {
      _midiSender.Destroy();
    }
  }
}