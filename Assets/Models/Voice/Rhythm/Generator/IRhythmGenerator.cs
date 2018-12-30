using System.Collections.Generic;
using Models.Voice.Rhythm.Model;
using NAudio.Midi;

namespace Models.Voice.Rhythm.Generator {
  
  public interface IRhythmGenerator<in T> {
    List<RhythmData> Generate(T input);
  }
}