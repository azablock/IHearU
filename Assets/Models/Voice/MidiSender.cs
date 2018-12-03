using NAudio.Midi;
using UnityEngine;

namespace Models.Voice {

  public class MidiSender {

    private MidiOut _bassMidiOut;
    private MidiOut _tenorMidiOut;

    public void Init() {
      _bassMidiOut = new MidiOut(1);   // Device No for "loopMIDI Port" == 1
      _tenorMidiOut = new MidiOut(2);  // Device No for "loopMIDI Port 1" == 2
      
      
      
      for (var device = 0; device < MidiOut.NumberOfDevices; device++) {
        Debug.Log(MidiOut.DeviceInfo(device).ProductName);
      }
    }

    public void Send() {
      //todo https://github.com/naudio/NAudio/blob/master/Docs/MidiInAndOut.md
      _bassMidiOut.Send(new NoteEvent(5, 1, MidiCommandCode.NoteOn, 50, 64).GetAsShortMessage());
      _bassMidiOut.Dispose();

      _tenorMidiOut.Send(new NoteEvent(1000, 1, MidiCommandCode.NoteOn, 58, 64).GetAsShortMessage());
      _tenorMidiOut.Dispose();
    }

    public void Destroy() {
      _bassMidiOut.Close();
      _tenorMidiOut.Close();
    }
  }
}