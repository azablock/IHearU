using System.Collections.Generic;
using System.Linq;
using Models.Voice.Harmony.Model;

namespace Models.Voice.Util {

  public static class NoteNameMapper {

    private static readonly Dictionary<int, string> Notes = new Dictionary<int, string> {    
      {24, "C0"},
      {25, "C#0"},
      {26, "D0"},
      {27, "D#0"},
      {28, "E0"},
      {29, "F0"},
      {30, "F#0"},
      {31, "G0"},
      {32, "G#0"},
      {33, "A0"},
      {34, "A#0"},
      {35, "B0"},
      
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
    
    public static string FromMidiValue(int value) {
      return Notes[value];
    }
    
    public static int FromNoteName(string noteName) {
      return Notes.FirstOrDefault(note => note.Value == noteName).Key;
    }

    public static int FromNoteSymbol(NoteSymbol noteSymbol) {
      return Notes.FirstOrDefault(note => note.Value == $"{noteSymbol.ToString()}0").Key;
    }
  }
}