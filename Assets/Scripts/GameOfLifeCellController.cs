using Models.CellularAutomata;
using UnityEngine;
using UnityEngine.Serialization;

public class GameOfLifeCellController : MonoBehaviour {

  [FormerlySerializedAs("Cell")]
  public CellularAutomataCell cell;

  [FormerlySerializedAs("AliveMaterial")]
  public Material aliveMaterial;

  [FormerlySerializedAs("DeadMaterial")]
  public Material deadMaterial;

  private MeshRenderer _meshRenderer;

  private void Start() {
    _meshRenderer = GetComponent<MeshRenderer>();
  }

  public void UpdateState() {
    _meshRenderer.material = cell.IsAlive ? aliveMaterial : deadMaterial;
  }
}