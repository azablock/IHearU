using System.Linq;
using Audio;
using Models.Voice;
using UnityEngine;

namespace Scriptable_Objects_Definitions.Voice.Dynamics {
  
  [CreateAssetMenu(menuName = "IHearU/Music Voice Filter/Target Distance Dynamics Filter")]
  public class TargetDistanceDynamicsFilter : MusicVoiceFilter {

    public float maxDistance;

    public int maxVelocityIncrease;
    
    private GameObject _player;
    
    private void OnEnable() {
      _player = GameObject.FindWithTag("Player");
    }

    public override void Filter(MusicVoiceController musicVoiceController) {
      var musicVoice = musicVoiceController.Voice;
      var nextNote = musicVoice.NextNote;
      var artifacts = GameObject.FindGameObjectsWithTag("Quest Artifact").ToList();
      
      var closestArtifact = artifacts
        .OrderBy(ArtifactDistance)
        .FirstOrDefault(artifact => ArtifactDistance(artifact) < maxDistance);

      if (closestArtifact) {
        musicVoice.UpdateNextNote(WithUpdatedVelocity(nextNote, ArtifactDistance(closestArtifact)));
      }
    }

    private Note WithUpdatedVelocity(Note note, float distance) {
      var newVelocity = (1.0f - distance / maxDistance) * maxVelocityIncrease;
      note.Velocity += (int) newVelocity;

      return note;
    }

    private float ArtifactDistance(GameObject artifact) {
      return Vector3.Distance(artifact.transform.position, _player.transform.position);
    }
  }
}