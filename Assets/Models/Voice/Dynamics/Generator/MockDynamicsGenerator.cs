using System.Collections.Generic;
using System.Linq;
using Audio;

namespace Models.Voice.Dynamics.Generator {
  
  public class MockDynamicsGenerator : IDynamicsGenerator<MusicVoiceController> {

    public Queue<int> Generate(MusicVoiceController input) {
      var dynamicsPattern = input.Voice.RhythmPattern.Select(i => 50);
      return new Queue<int>(dynamicsPattern);
    }
  }
}