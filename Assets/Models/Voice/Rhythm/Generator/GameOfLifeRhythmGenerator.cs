using System.Collections.Generic;
using System.Linq;
using Models.CellularAutomata;
using Models.Voice.Rhythm.Util;
using Models.Voice.Util;

namespace Models.Voice.Rhythm.Generator {

  public class GameOfLifeRhythmGenerator : IRhythmGenerator<GameOfLifeCellularAutomata> {

    public IEnumerable<Note> Generate(GameOfLifeCellularAutomata automata) {
      var rows = new List<List<CellularAutomataCell>>();

      for (var y = 0; y < automata.Dimensions().Y; y++) {
        rows.Add(GameOfLifeRow(automata, y));
      }

      var rowWithMostAliveCells = rows.Last(row => row.Count(cell => cell.IsAlive) != 0);

      return rowWithMostAliveCells.Select(RhythmicNote);
    }

    private static Note RhythmicNote(CellularAutomataCell cell, int iterator) {
      return Note.Rhythmic(
        cell.IsAlive,
//        cell.IsDead,
        RhythmHelper.SixteenthNoteLengthMillis(), 
        iterator * RhythmHelper.SixteenthNoteLengthMillis()
      );
    }

    private static List<CellularAutomataCell> GameOfLifeRow(GameOfLifeCellularAutomata automata, int rowIndex) {
      var row = new List<CellularAutomataCell>();

      for (var x = 0; x < automata.Dimensions().X; x++) {
        var cellPosition = new Vector2D(x, rowIndex);
        row.Add(automata.State()[cellPosition]);
      }
      
      return row;
    }
  }
}