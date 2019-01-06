using System.Threading.Tasks;
using Models.Voice.Util;
using NAudio.Midi;

namespace Models.Voice {

  public class MidiSender {

    private readonly MidiOut _midiOut;

    private const float StopNoteMillisDelta = 10.0f;

    public MidiSender(string deviceName) {
      _midiOut = MidiDeviceFinder.MidiOutByDeviceName(deviceName);
    }
    
    public async Task PlayNoteAsync(Note note) {
      if (note.IsPause) {
        await Task.Delay((int) note.Length).ConfigureAwait(false);
      }
      else {
        var startNoteTimeMillis = note.Length - StopNoteMillisDelta;
        _midiOut.Send(MidiMessage.StartNote(note.MidiValue, note.Velocity, 1).RawData);
        await Task.Delay((int) startNoteTimeMillis).ConfigureAwait(false);

        _midiOut.Send(MidiMessage.StopNote(note.MidiValue, note.Velocity, 1).RawData);
        await Task.Delay((int) StopNoteMillisDelta).ConfigureAwait(false);
      }
    }

    public void Destroy() {
      _midiOut.Dispose();
      _midiOut.Close();
    }
  }
}