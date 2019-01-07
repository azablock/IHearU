using Player;
using UnityEngine;

namespace Quest {
  
  public class QuestArtifact : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
      var otherGameObject = other.gameObject;

      if (!otherGameObject.CompareTag("Player")) return;

      otherGameObject.GetComponent<ArtifactHolder>().AddArtifact(this);
      Destroy(gameObject);
    }
  }
}