using Models.CellularAutomata;
using UnityEngine;

public class GameOfLifeCellController : MonoBehaviour {

  public CellularAutomataCell Cell;

  public Material AliveMaterial;

  public Material DeadMaterial;
  
  private MeshRenderer _meshRenderer;
  
  private void Start() {
    _meshRenderer = GetComponent<MeshRenderer>();
  }

  private void Update() {
//    _meshRenderer.material = Cell.IsAlive ? AliveMaterial : DeadMaterial;
  }

  public void UpdateState() {
    _meshRenderer.material = Cell.IsAlive ? AliveMaterial : DeadMaterial;
  }
}