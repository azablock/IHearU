using System.Collections.Generic;
using Audio;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Harmony {
  
  public abstract class HarmonyProvider : ScriptableObject {

    public abstract Queue<int> Provide(MusicVoiceController voiceController);
  }
}