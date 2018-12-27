using System.Collections.Generic;
using System.Linq;

namespace Models.Voice.Util {

  public static class NoteNameMapper {

    private static readonly Dictionary<int, string> Notes = new Dictionary<int, string> {
      {24, "C1"},
      {25, "C#1"},
      {26, "D1"},
      {27, "D#1"},
      {28, "E1"},
      {29, "F1"},
      {30, "F#1"},
      {31, "G1"},
      {32, "G#1"},
      {33, "A1"},
      {34, "A#1"},
      {35, "B1"},
      
      {36, "C2"},
      {37, "C#2"},
      {38, "D2"},
      {39, "D#2"},
      {40, "E2"},
      {41, "F2"},
      {42, "F#2"},
      {43, "G2"},
      {44, "G#2"},
      {45, "A2"},
      {46, "A#2"},
      {47, "B2"}
    };
    
    public static string fromMidiValue(int value) {
      return Notes[value];
    }
    
    //todo to refactor - different octaves
    public static int FromNoteName(string noteName) {
      return Notes.FirstOrDefault(name => name.Value == noteName).Key;
    }
  }
}