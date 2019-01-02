using System;
using Models.Voice.Util;

namespace Models.Voice.Harmony.Model {
  
  public class NoteInterval {
    
    public static int ROOT => 0;
    
    public static int MIN_2ND => 1;
    
    public static int MAJ_2ND => 2;

    public static int MIN_3RD => 3;

    public static int MAJ_3RD => 4;

    public static int FORTH => 5;
    
    public static int TRITONE => 6;

    public static int FIFTH => 7;

    public static int MIN_6TH => 8;

    public static int MAJ_6TH => 9;

    public static int MIN_7TH => 10;

    public static int MAJ_7TH => 11;

    public static int OCTAVE => 12;
    
    public static int IntervalBy(int sourceMidiValue, int targetMidiValue) {
      return Math.Abs(targetMidiValue - sourceMidiValue);
    }

    public static int IntervalBy(string sourceNoteName, string targetNoteName) {
      var sourceMidiValue = NoteNameMapper.FromNoteName(sourceNoteName);
      var targetMidiValue = NoteNameMapper.FromNoteName(targetNoteName);

      return IntervalBy(sourceMidiValue, targetMidiValue);
    }
  }
}