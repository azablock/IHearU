using System.Collections.Generic;
using Audio;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Dynamics {

  public abstract class DynamicsProvider : ScriptableObject {

    public abstract Queue<int> Provide(MusicVoiceController voiceController);
  }
}