using Models;
using Models.CellularAutomata;
using UnityEngine;

public class GameOfLifeCellularAutomataController : MonoBehaviour {

  public int SizeX;

  public int SizeY;

  private int _randomDistributionCounter;

  private void Awake() {
    Automata = new GameOfLifeCellularAutomata(new Vector2D(SizeX, SizeY));
  }

  public void UpdateCellularAutomata() {
    if (_randomDistributionCounter % 4 == 0) {
      Automata.DistributeRandomly();
    }
    else {
      Automata.Update();
      _randomDistributionCounter++;
    }
  }

  public GameOfLifeCellularAutomata Automata { get; private set; }
}