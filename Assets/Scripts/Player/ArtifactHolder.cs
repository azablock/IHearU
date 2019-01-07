using System.Collections.Generic;
using Quest;
using UnityEngine;

namespace Player {

  public class ArtifactHolder : MonoBehaviour {

    private readonly List<QuestArtifact> _artifacts = new List<QuestArtifact>();

    public void AddArtifact(QuestArtifact artifact) {
      _artifacts.Add(artifact);
    }

    public int ArtifactsCount => _artifacts.Count;
  }
}