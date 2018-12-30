namespace Models.Voice.Harmony.Model {

  public class OctaveNoteRange {

    public OctaveNoteRangeId Id { get; }
    public int Offset { get; }

    private const int SingleOctaveOffset = 12;
    
    private OctaveNoteRange(OctaveNoteRangeId id, int offset) {
      Id = id;
      Offset = offset;
    }

    public static OctaveNoteRange C0_C1 => new OctaveNoteRange(OctaveNoteRangeId.C0_C1, SingleOctaveOffset * 2);
  }

  public enum OctaveNoteRangeId {
    C0_C1
  }
}