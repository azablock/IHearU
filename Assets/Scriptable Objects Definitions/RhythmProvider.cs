using System.Collections.Generic;
using Models.Voice;
using Models.Voice.Rhythm.Generator;
using UnityEngine;

namespace ScriptableObjectsDefinitions {
  [CreateAssetMenu(menuName = "IHearU/Rhythm/Rhythm Provider")]
  public class RhythmProvider : ScriptableObject {

    private SimpleRhythmGenerator _generator;

    private void Awake() {
      _generator = new SimpleRhythmGenerator();
    }

    public IEnumerable<Note> Provide() {
      return _generator.Generate(16);
    }
  }
}