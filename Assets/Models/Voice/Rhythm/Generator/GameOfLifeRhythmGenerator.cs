using System.Collections.Generic;
using System.Linq;
using Audio;
using Models.CellularAutomata;
using Models.Voice.Rhythm.Model;

namespace Models.Voice.Rhythm.Generator {

  public class GameOfLifeRhythmGenerator : IRhythmGenerator<MusicVoiceController> {

    public List<RhythmData> Generate(MusicVoiceController voiceController) {
      var rows = new List<List<CellularAutomataCell>>();
      var automata = voiceController.GameOfLifeCellularAutomata;

      for (var y = 0; y < automata.Dimensions().Y; y++) {
        rows.Add(GameOfLifeRow(automata, y));
      }

      return rows
        .OrderBy(row => row.Count(cell => cell.IsAlive))
        .Last()
        .Select(cell => RhythmData.Of(cell.IsDead, voiceController.rhythmProvider.measure))
        .ToList();
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