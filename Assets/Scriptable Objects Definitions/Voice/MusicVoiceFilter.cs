using Audio;
using Models.Voice;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice {
  
  public abstract class MusicVoiceFilter : ScriptableObject {

    public abstract void Filter(MusicVoiceController musicVoiceController);
  }
}