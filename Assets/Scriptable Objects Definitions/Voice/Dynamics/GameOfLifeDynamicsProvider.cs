using System.Collections.Generic;
using Audio;
using Models.Voice.Dynamics.Generator;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Dynamics {
  
  [CreateAssetMenu(menuName = "IHearU/Dynamics/Game Of Life Dynamics Provider")]
  public class GameOfLifeDynamicsProvider : DynamicsProvider {

    public int baseVelocity;

    private MockDynamicsGenerator _generator;

    private void OnEnable() {
      _generator = new MockDynamicsGenerator();
    }

    public override Queue<int> Provide(MusicVoiceController voiceController) {
      return _generator.Generate(voiceController);
    }
  }
}