using Models.Voice;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio {
  
  public class MidiSenderController : MonoBehaviour {

    [FormerlySerializedAs("MidiSender")]
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