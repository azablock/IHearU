namespace Models.Voice.Rhythm.Util {

  public static class RhythmHelper {
    
    private const float Tempo = 80.0f; //80 4th notes in minute

    public static float FourthNoteLengthMillis() {
      return NoteLengthMillis(4.0f);
    }

    public static float EighthNoteLengthMillis() {
      return NoteLengthMillis(8.0f);
    }

    public static float SixteenthNoteLengthMillis() {
      return NoteLengthMillis(8.0f);
    }

    private static float NoteLengthMillis(float noteDivision) {
      return 4.0f * (60.0f / Tempo * noteDivision) * 1000.0f;
    }
  }
}