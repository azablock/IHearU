namespace Models.Voice.Rhythm.Model {

  public class RhythmData {
  
    private RhythmData(bool isPause, RhythmMeasure measure) {
      IsPause = isPause;
      Measure = measure;
    }

    public static RhythmData QuarterNote(bool isPause) {
      return new RhythmData(isPause, RhythmMeasure.QUARTER_NOTE);
    }
    
    public static RhythmData EighthNote(bool isPause) {
      return new RhythmData(isPause, RhythmMeasure.EIGHT_NOTE);
    }

    public static RhythmData SixteenthNote(bool isPause) {
      return new RhythmData(isPause, RhythmMeasure.SIXTEENTH_NOTE);
    }

    public bool IsPause { get; }

    public RhythmMeasure Measure { get; }
  }
}