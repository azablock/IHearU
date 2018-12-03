using System.Collections.Generic;
using System.Linq;

namespace Models.Voice.Util {

  public class NoteNameMapper {

    private static readonly Dictionary<int, string> Notes = new Dictionary<int, string> {
      {50, "D"},
      {54, "F#"}
    };
    
    public static string fromMidiValue(int value) {
      return Notes[value];
    }
    
    //todo to refactor - different octaves
    public static int fromNoteName(string noteName) {
      return Notes.FirstOrDefault(name => name.Value == noteName).Key;
    }
  }
}