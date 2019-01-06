using System.Collections.Generic;
using Audio;
using Models.Voice.Harmony.Model;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Harmony {
  
  public abstract class HarmonyProvider : ScriptableObject {

    [SerializeField]
    public OctaveNoteRangeId noteRange;

    public abstract Queue<int> Provide(MusicVoiceController voiceController);
  }
}