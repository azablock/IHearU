namespace Models.Voice {

  public class Note {

    public readonly int MidiValue;
    public readonly float Length;
    public int Velocity;
    public readonly float OffsetTime;
    public readonly bool IsPause;
    public bool AlreadyPlayed;

    private const int PauseMidiValue = 0;

    private Note(int midiValue, float length, int velocity, float offsetTime) {
      MidiValue = midiValue;
      Length = length;
      Velocity = velocity;
      OffsetTime = offsetTime;
      IsPause = midiValue == PauseMidiValue;
      AlreadyPlayed = false;
    }

    public static Note Of(int midiValue, float length, int velocity, float offsetTime) {
      return new Note(midiValue, length, velocity, offsetTime);
    }

    public static Note Pause(float length, float offsetTime) {
      return new Note(PauseMidiValue, length, 127, offsetTime);
    }
  }
}