namespace Models.CellularAutomata {

  public class CellularAutomataCell {

    private readonly Vector2D _position;

    public CellularAutomataCell(Vector2D position, GameOfLifeCellState state = GameOfLifeCellState.Dead) {
      _position = position;
      State = state;
    }

    public GameOfLifeCellState State { get; set; }

    public Vector2D Position {
      get { return _position; }
    }

    public int X {
      get { return _position.X; }
    }

    public int Y {
      get { return _position.Y; }
    }

    public bool IsAlive {
      get { return State == GameOfLifeCellState.Alive; }
    }

    public bool IsDead {
      get { return State == GameOfLifeCellState.Dead; }
    }
  }
}