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
      var midiCommand = note.IsPause ? MidiCommandCode.NoteOff : MidiCommandCode.NoteOn;
      var velocity = 50 + new Random().Next(0, 10);
      var noteEvent = new NoteEvent(Convert.ToInt64(note.OffsetTime), 1, midiCommand, note.MidiValue, velocity);

      _midiOut.Send(noteEvent.GetAsShortMessage());
    }

    public void Destroy() {
      _midiOut.Dispose();
      _midiOut.Close();
    }
  }
}