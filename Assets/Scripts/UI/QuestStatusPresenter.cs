using Player;
using Quest;
using UnityEngine;
using UnityEngine.UI;

namespace UI {

  public class QuestStatusPresenter : MonoBehaviour {

    public Text questArtifactsText;
    
    private GameObject _player;
    private ArtifactHolder _artifactHolder;

    private void Start() {
      _player = GameObject.FindWithTag("Player");
      _artifactHolder = _player.GetComponent<ArtifactHolder>();
    }

    private void Update() {
      questArtifactsText.text = QuestArtifactsText;
    }

    private string QuestArtifactsText => $"Quests Artifacts: {_artifactHolder.ArtifactsCount}";
  }
}