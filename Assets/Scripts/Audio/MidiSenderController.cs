using Models.Voice;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio {
  
  public class MidiSenderController2 : MonoBehaviour {

    [FormerlySerializedAs("midiSender2")] [FormerlySerializedAs("MidiSender2")]
    public MidiSender midiSender = new MidiSender();

    private void Start() {
      midiSender.Init();
      midiSender.Send();
    }

    private void OnDestroy() {
      midiSender.Destroy();
    }
  }
}