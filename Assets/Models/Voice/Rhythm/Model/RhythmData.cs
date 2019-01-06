using Models.Voice.Rhythm.Util;

namespace Models.Voice.Rhythm.Model {

  public class RhythmData {
  
    private RhythmData(bool isPause, RhythmMeasure measure) {
      IsPause = isPause;
      Measure = measure;
    }

    public static RhythmData QuarterNote(bool isPause) {
      return new RhythmData(isPause, RhythmMeasure.QuarterNote);
    }
    
    public static RhythmData EighthNote(bool isPause) {
      return new RhythmData(isPause, RhythmMeasure.EightNote);
    }

    public static RhythmData SixteenthNote(bool isPause) {
      return new RhythmData(isPause, RhythmMeasure.SixteenthNote);
    }

    public static RhythmData Of(bool isPause, RhythmMeasure measure) {
      return new RhythmData(isPause, measure);
    }

    public bool IsPause { get; }

    public float LengthMillis => Metronome.LengthMillisByMeasure(Measure);

    private RhythmMeasure Measure { get; }
  }
}