using System.Collections.Generic;
using System.Linq;
using Models.CellularAutomata;

namespace Models.Voice {

  public class SimpleRhythmFilter : IRhythmFilter<GameOfLifeCellularAutomata> {

    public IEnumerable<Note> Filter(GameOfLifeCellularAutomata automata, IEnumerable<Note> notes) {
      //todo example with automata
      return notes.Select((note, i) => {
//        note.IsPause = i > 2; //todo
        return note;
      });
    }
  }
}