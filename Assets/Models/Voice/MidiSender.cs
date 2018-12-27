using System;
using Models.Voice.Util;
using NAudio.Midi;

namespace Models.Voice {

  public class MidiSender {

    private readonly MidiOut _midiOut;

    public MidiSender(string deviceName) {
      _midiOut = MidiDeviceFinder.MidiOutByDeviceName(deviceName);
    }
    
    public void Send(Note note) {
      //todo https://github.com/naudio/NAudio/blob/master/Docs/MidiInAndOut.md
      var midiCommand = note.IsPause ? MidiCommandCode.NoteOff : MidiCommandCode.NoteOn;
      var noteEvent = new NoteEvent(Convert.ToInt64(note.OffsetTime), 1, midiCommand, note.MidiValue, 64);

      _midiOut.Send(noteEvent.GetAsShortMessage());
    }

    public void Destroy() {
      _midiOut.Dispose();
      _midiOut.Close();
    }
  }
}