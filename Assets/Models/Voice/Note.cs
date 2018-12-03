namespace Models.Voice {

  public class Note {
    //todo to be filled
    public bool Alive;

    public readonly int MidiValue;

    public Note(int midiValue) {
      MidiValue = midiValue;
      Alive = false;
    }
  }
}