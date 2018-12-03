using Models.Voice.Util;
using NAudio.Midi;

namespace Models.Voice {

  public class MidiSender {

    private MidiOut _bassMidiOut;
    private MidiOut _tenorMidiOut;

    public void Init() {
      _bassMidiOut = MidiDeviceFinder.MidiOutByDeviceName("loopMIDI Port");
      _tenorMidiOut = MidiDeviceFinder.MidiOutByDeviceName("loopMIDI Port 1");
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