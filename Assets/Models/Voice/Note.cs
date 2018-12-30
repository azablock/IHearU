namespace Models.Voice {

  public class Note {

    public readonly int MidiValue;
    public readonly bool IsPause;
    public readonly float Length;
    public readonly float OffsetTime;

    private Note(int midiValue, bool isPause, float length, float offsetTime) {
      MidiValue = midiValue;
      IsPause = isPause;
      Length = length;
      OffsetTime = offsetTime;
    }

    public static Note Of(int midiValue, float length, float offsetTime) {
      return new Note(midiValue, false, length, offsetTime);
    }

    public static Note WithMidiValue(Note origin, int midiValue) {
      return new Note(midiValue, origin.IsPause, origin.Length, origin.OffsetTime);
    }

    public static Note Rhythmic(bool isPause, float length, float offsetTime) {
      //todo midiValue = 0
      return new Note(24, isPause, length, offsetTime);
    }

    public static Note Pause(int midiValue, float length, float offsetTime) {
      return new Note(midiValue, true, length, offsetTime);
    }
  }
}