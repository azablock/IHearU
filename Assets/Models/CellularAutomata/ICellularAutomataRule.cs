using System;

namespace Models.CellularAutomata {

  public class CellularAutomataRule<T> {

    private readonly Predicate<CellularAutomataCell> _definition;
    private readonly T _state;

    private CellularAutomataRule(Predicate<CellularAutomataCell> definition, T state) {
      _definition = definition;
      _state = state;
    }

    public static CellularAutomataRule<T> Of(Predicate<CellularAutomataCell> definition, T state) {
      return new CellularAutomataRule<T>(definition, state);
    }

    //conforms
    public bool Matches(CellularAutomataCell cell) {
      return _definition.Invoke(cell);
    }

    public T State {
      get { return _state; }
    }
  }
}