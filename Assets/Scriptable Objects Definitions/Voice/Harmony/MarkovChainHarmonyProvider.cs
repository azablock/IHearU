using System.Collections.Generic;
using Audio;
using Models.MarkovChain.MarkovChainFactory;
using Models.Voice.Harmony.Generator;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Harmony {

  [CreateAssetMenu(menuName = "IHearU/Harmony/Markov Chain Harmony Provider")]
  public class MarkovChainHarmonyProvider : HarmonyProvider {
    
    private MarkovChainHarmonyGenerator _harmonyGenerator;

    private void OnEnable() {
      _harmonyGenerator = new MarkovChainHarmonyGenerator(new TwoNotesScaleMarkovChainFactory().NewInstance());
    }

    public override Queue<int> Provide(MusicVoiceController voiceController) {
      return _harmonyGenerator.Generate(voiceController.Voice);
    }
  }
}