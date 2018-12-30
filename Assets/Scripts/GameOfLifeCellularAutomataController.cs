using System.Collections.Generic;
using Models;
using Models.CellularAutomata;
using UnityEngine;

public class GameOfLifeCellularAutomataController : MonoBehaviour {

  public int SizeX;

  public int SizeY;

//  public GameObject GameOfLifeCellPrefab;

//  private readonly List<GameOfLifeCellController> _cellControllers = new List<GameOfLifeCellController>();

  private void Awake() {
    Automata = new GameOfLifeCellularAutomata(new Vector2D(SizeX, SizeY));
//    var cells = new List<CellularAutomataCell>(_automata.State().Values);

//    cells.ForEach(cell => {
//      var cellController = Instantiate(GameOfLifeCellPrefab, new Vector3(cell.X, 0, cell.Y), Quaternion.identity).GetComponent<GameOfLifeCellController>();
//      cellController.cell = cell;

//      _cellControllers.Add(cellController);
//    });
  }

  public void UpdateCellularAutomata() {
    Automata.Update();
//    _cellControllers.ForEach(ctrl => ctrl.UpdateState());
  }

  public GameOfLifeCellularAutomata Automata { get; private set; }
}