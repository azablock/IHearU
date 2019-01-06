using System.Collections.Generic;
using Audio;
using Models.Voice.Rhythm.Generator;
using Models.Voice.Rhythm.Model;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Rhythm {
  [CreateAssetMenu(menuName = "IHearU/Rhythm/Game Of Life Rhythm Provider")]
  public class GameOfLifeRhythmProvider : RhythmProvider {

    private GameOfLifeRhythmGenerator _generator;

    private void OnEnable() {
      _generator = new GameOfLifeRhythmGenerator();
    }

    public override List<RhythmData> Provide(MusicVoiceController voiceController) {
      return _generator.Generate(voiceController);
    }
  }
}