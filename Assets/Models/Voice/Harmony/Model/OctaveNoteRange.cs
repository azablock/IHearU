using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Models.Voice.Harmony.Model {

  public class OctaveNoteRange {

    public OctaveNoteRangeId Id { get; }
    public int Offset { get; }

    private const int SingleOctaveOffset = 12;
    
    private static readonly ImmutableDictionary<OctaveNoteRangeId, int> Ranges = new Dictionary<OctaveNoteRangeId, int> {
      {OctaveNoteRangeId.C0, SingleOctaveOffset * 2},
      {OctaveNoteRangeId.C1, SingleOctaveOffset * 3},
      {OctaveNoteRangeId.C2, SingleOctaveOffset * 4},
    }.ToImmutableDictionary();
    
    private OctaveNoteRange(OctaveNoteRangeId id, int offset) {
      Id = id;
      Offset = offset;
    }

    public static OctaveNoteRange From(OctaveNoteRangeId id) {
      var range = Ranges.First(pair => pair.Key == id);
      return new OctaveNoteRange(range.Key, range.Value);
    }
  }

  public enum OctaveNoteRangeId {
    C0,
    C1,
    C2
  }
}