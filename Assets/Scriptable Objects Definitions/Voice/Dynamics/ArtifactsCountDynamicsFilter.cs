using Audio;
using Models.Voice;
using Player;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Dynamics {

  [CreateAssetMenu(menuName = "IHearU/Music Voice Filter/Artifacts Count Dynamics Filter")]
  public class ArtifactsCountDynamicsFilter : MusicVoiceFilter {

    private GameObject _player;

    [Header("Velocity increase per each collected quest artifact")]
    public int velocityDelta = 10;

    private void OnEnable() {
      _player = GameObject.FindWithTag("Player");
    }

    public override void Filter(MusicVoiceController musicVoiceController) {
      var musicVoice = musicVoiceController.Voice;
      musicVoice.UpdateNextNote(WithUpdatedVelocity(musicVoice.NextNote));
    }

    private Note WithUpdatedVelocity(Note note) {
      var artifactHolder = _player.GetComponent<ArtifactHolder>();
      note.Velocity += velocityDelta * artifactHolder.ArtifactsCount;

      return note;
    }
  }
}