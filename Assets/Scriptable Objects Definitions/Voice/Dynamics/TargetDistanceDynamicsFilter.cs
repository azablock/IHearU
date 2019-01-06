using System.Collections.Generic;
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
    private List<GameObject> _totems;
    
    private void OnEnable() {
      _player = GameObject.FindWithTag("Player");
      _totems = GameObject.FindGameObjectsWithTag("Totem").ToList();
    }

    public override void Filter(MusicVoiceController musicVoiceController) {
      var musicVoice = musicVoiceController.Voice;
      var nextNote = musicVoice.NextNote;
      var closestTotem = _totems
        .OrderBy(TotemDistance)
        .FirstOrDefault(totem => TotemDistance(totem) < maxDistance);

      if (closestTotem) {
        musicVoice.UpdateNextNote(WithUpdatedVelocity(nextNote, TotemDistance(closestTotem)));
      }
    }

    private Note WithUpdatedVelocity(Note note, float distance) {
      var newVelocity = (1.0f - distance / maxDistance) * maxVelocityIncrease;
      note.Velocity += (int) newVelocity;

      return note;
    }

    private float TotemDistance(GameObject totem) {
      return Vector3.Distance(totem.transform.position, _player.transform.position);
    }
  }
}