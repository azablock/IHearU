using System.Collections.Generic;
using Audio;
using Models.Voice.Rhythm.Model;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Rhythm {
  
  public abstract class RhythmProvider : ScriptableObject {

    public abstract List<RhythmData> Provide(MusicVoiceController voiceController);
  }
}