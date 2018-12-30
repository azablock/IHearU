using System.Collections.Generic;
using System.Linq;

namespace Models.CellularAutomata {

  public class GameOfLifeCellularAutomata : ICellularAutomata<GameOfLifeCellState> {
    
    private readonly Dictionary<Vector2D, CellularAutomataCell> _state = new Dictionary<Vector2D, CellularAutomataCell>();
    private readonly List<CellularAutomataRule<GameOfLifeCellState>> _rules = new List<CellularAutomataRule<GameOfLifeCellState>>();
    private readonly Vector2D _dimensions;
    private readonly List<Vector2D> _neighbourPositions;
    
    public GameOfLifeCellularAutomata(Vector2D dimensions) {
      _dimensions = dimensions;

      for (var y = 0; y < _dimensions.Y; y++) {
        for (var x = 0; x < _dimensions.X; x++) {
          var position = new Vector2D(x, y);
          
          _state.Add(position, new CellularAutomataCell(position));
        }
      }

      _rules.Add(CellularAutomataRule<GameOfLifeCellState>.Of(apex => apex.IsDead && NeighboursCount(apex) == 3, GameOfLifeCellState.Alive));
      _rules.Add(CellularAutomataRule<GameOfLifeCellState>.Of(apex => apex.IsAlive && NeighboursCount(apex) < 2, GameOfLifeCellState.Dead));
      _rules.Add(CellularAutomataRule<GameOfLifeCellState>.Of(apex => apex.IsAlive && NeighboursCount(apex) > 3, GameOfLifeCellState.Dead));
      _rules.Add(CellularAutomataRule<GameOfLifeCellState>.Of(apex => apex.IsAlive && Enumerable.Range(2, 3).Contains(NeighboursCount(apex)), GameOfLifeCellState.Alive));

      _neighbourPositions = new List<Vector2D> {
        Vector2D.Up,
        Vector2D.UpRight,
        Vector2D.Right,
        Vector2D.DownRight,
        Vector2D.Down,
        Vector2D.DownLeft,
        Vector2D.Left,
        Vector2D.UpLeft
      };

      ///////////////////////
      _state[new Vector2D(1, 6)].State = GameOfLifeCellState.Alive;
      
      _state[new Vector2D(2, 5)].State = GameOfLifeCellState.Alive;
      _state[new Vector2D(3, 5)].State = GameOfLifeCellState.Alive;

      _state[new Vector2D(1, 4)].State = GameOfLifeCellState.Alive;
      _state[new Vector2D(2, 4)].State = GameOfLifeCellState.Alive;
      ///////////////////////
    }

    public void Update() {
      var newState = _state.Select(pair => UpdatedCell(pair.Value)).ToList();

      foreach (var cell in newState) {
        _state[cell.Position].State = cell.State;
      }
    }

    public List<CellularAutomataRule<GameOfLifeCellState>> Rules() {
      return _rules;
    }

    public Dictionary<Vector2D, CellularAutomataCell> State() {
      return _state;
    }

    public IEnumerable<KeyValuePair<Vector2D, CellularAutomataCell>> Neighbours(CellularAutomataCell target) {
      var neighbourPositions = _neighbourPositions.Select(pos => pos.Add(target.Position));
      return _state.Where(pair => neighbourPositions.Contains(pair.Key) && pair.Value.IsAlive);
    }

    public int NeighboursCount(CellularAutomataCell cell) {
      return Neighbours(cell).Count();
    }

    public Vector2D Dimensions() {
      return _dimensions;
    }

    private CellularAutomataCell UpdatedCell(CellularAutomataCell cell) {
      var matchedRule = _rules.FirstOrDefault(rule => rule.Matches(cell));
      var cellState = matchedRule?.State ?? cell.State;

      return new CellularAutomataCell(cell.Position, cellState);
    }
  }
}