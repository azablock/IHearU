using System.Collections.Generic;
using Models.Voice.Rhythm.Util;
using Models.Voice.Util;

namespace Models.Voice.Rhythm.Generator {

  public class SimpleRhythmGenerator : IRhythmGenerator<int> {
    public IEnumerable<Note> Generate(int input) {
      var rhythmNotes = new List<Note>();

      for (var i = 0; i < input; i++)
        rhythmNotes.Add(Note.Rhythmic(
          i % 2 == 1,
          RhythmHelper.SixteenthNoteLengthMillis(),
          (long) (RhythmHelper.SixteenthNoteLengthMillis() * i))
        );

      return rhythmNotes;
    }
  }
}