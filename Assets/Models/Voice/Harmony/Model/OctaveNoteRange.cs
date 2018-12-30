namespace Models.Voice.Harmony.Model {

  public class OctaveId {

    public string Id { get; }
    public int Offset { get; }

    public OctaveId(string id, int offset) {
      Id = id;
      Offset = offset;
    }
  }
}