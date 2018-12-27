using System.Collections.Generic;
using NAudio.Midi;

namespace Models.Voice.Rhythm.Generator {
  
  public interface IRhythmGenerator<in T> {
    IEnumerable<Note> Generate(T input);
  }
}