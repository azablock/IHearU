using System.Collections.Immutable;
using static Models.Voice.Harmony.Model.NoteInterval;

namespace Models.Voice.Harmony.Model {
  public class MusicScale {

    public ImmutableList<int> Intervals { get; }
    public NoteSymbol Root { get; }

    private MusicScale(ImmutableList<int> intervals, NoteSymbol root) {
      Intervals = intervals;
      Root = root;
    }

    public static MusicScale TestScale(NoteSymbol root) {
      var intervals = ImmutableList.Create(ROOT, FIFTH);
      return new MusicScale(intervals, root);
    }
  }
}