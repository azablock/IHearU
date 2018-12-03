using System.Collections.Generic;
using Models;
using Models.CellularAutomata;
using UnityEngine;

public class GameOfLifeCellularAutomataController : MonoBehaviour {

  public int SizeX;

  public int SizeY;

  public GameObject GameOfLifeCellPrefab;

  private GameOfLifeCellularAutomata _automata;

  private readonly List<GameOfLifeCellController> _cellControllers = new List<GameOfLifeCellController>();

  private void Start() {
    _automata = new GameOfLifeCellularAutomata(new Vector2D(SizeX, SizeY));
    var cells = new List<CellularAutomataCell>(_automata.State().Values);

    cells.ForEach(cell => {
      var cellController = Instantiate(GameOfLifeCellPrefab, new Vector3(cell.X, 0, cell.Y), Quaternion.identity).GetComponent<GameOfLifeCellController>();
      cellController.Cell = cell;

      _cellControllers.Add(cellController);
    });

    InvokeRepeating("UpdateCellularAutomata", 0.5f, 0.5f);
  }

  private void UpdateCellularAutomata() {
    _automata.Update();
    _cellControllers.ForEach(ctrl => ctrl.UpdateState());
  }
}