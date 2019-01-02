namespace Models.Voice.Rhythm.Util {

  public static class Metronome {
    
    //todo to be resolved
    private const float Tempo = 118.0f; //80 4th notes in minute

    public static float FourthNoteLengthMillis() {
      return 508.0f;
//      return NoteLengthMillis(4.0f);
    }

    public static float EighthNoteLengthMillis() {
      return 254.0f;
//      return NoteLengthMillis(8.0f);
    }

    public static float SixteenthNoteLengthMillis() {
      return 127.0f;
//      return NoteLengthMillis(8.0f);
    }

    private static float NoteLengthMillis(float noteDivision) {
      return 4.0f * (60.0f / Tempo * noteDivision) * 1000.0f;
    }
  }
}