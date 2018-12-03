using System.Collections.Generic;
using JetBrains.Annotations;

namespace Models.CellularAutomata {

  public interface ICellularAutomata<T> {

    void Update();
    
    [NotNull]
    List<CellularAutomataRule<T>> Rules();
    
    [NotNull]
    Dictionary<Vector2D, CellularAutomataCell> State();

    [NotNull]
    IEnumerable<KeyValuePair<Vector2D, CellularAutomataCell>> Neighbours(CellularAutomataCell target);

    [NotNull]
    Vector2D Dimensions();
    
    int NeighboursCount(CellularAutomataCell cell);
  }
}