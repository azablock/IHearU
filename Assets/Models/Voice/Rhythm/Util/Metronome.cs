using Models.Voice.Rhythm.Model;

namespace Models.Voice.Rhythm.Util {

  public static class Metronome {
    
    //todo to be resolved
    //118 BPM -> 0.127 s == 16th length, 0.254f == 8th length
    private const float Tempo = 118.0f; //118 4th notes in minute

    public static float WholeNoteLengthMillis() {
      return 4064.0f;
    }

    public static float HalfNoteLengthMillis() {
      return 2032.0f;
    }
    
    public static float FourthNoteLengthMillis() {
      return 1016.0f;
    }

    public static float EighthNoteLengthMillis() {
      return 508.0f;
    }

    public static float SixteenthNoteLengthMillis() {
      return 254.0f;
    }

    //todo to be refactored
    public static float LengthMillisByMeasure(RhythmMeasure measure) {
      return measure == RhythmMeasure.WholeNote ? WholeNoteLengthMillis()
        : measure == RhythmMeasure.HalfNote ? HalfNoteLengthMillis()
        : measure == RhythmMeasure.QuarterNote ? FourthNoteLengthMillis()
        : measure == RhythmMeasure.EightNote ? EighthNoteLengthMillis()
        : SixteenthNoteLengthMillis();
    }

    private static float NoteLengthMillis(float noteDivision) {
      return 4.0f * (60.0f / Tempo * noteDivision) * 1000.0f;
    }
  }
}