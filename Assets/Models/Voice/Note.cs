namespace Models.Voice {

  public class Note {

    public readonly int MidiValue;
    public readonly bool IsPause;
    public readonly float Length;
    public readonly float OffsetTime;
    public bool AlreadyPlayed;

    private const int PauseMidiValue = 0;

    private Note(int midiValue, float length, float offsetTime) {
      MidiValue = midiValue;
      IsPause = midiValue == PauseMidiValue;
      Length = length;
      OffsetTime = offsetTime;
      AlreadyPlayed = false;
    }

    public static Note Of(int midiValue, float length, float offsetTime) {
      return new Note(midiValue,  length, offsetTime);
    }

    public static Note WithMidiValue(Note origin, int midiValue) {
      return new Note(midiValue,  origin.Length, origin.OffsetTime);
    }

    public static Note Pause(float length, float offsetTime) {
      return new Note(PauseMidiValue, length, offsetTime);
    }
  }
}