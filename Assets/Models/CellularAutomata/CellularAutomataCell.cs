namespace Models.CellularAutomata {

  public class CellularAutomataCell {

    public CellularAutomataCell(Vector2D position, GameOfLifeCellState state = GameOfLifeCellState.Dead) {
      Position = position;
      State = state;
    }

    public GameOfLifeCellState State { get; set; }

    public Vector2D Position { get; }

    public int X => Position.X;

    public int Y => Position.Y;

    public bool IsAlive => State == GameOfLifeCellState.Alive;

    public bool IsDead => State == GameOfLifeCellState.Dead;
  }
}