using System.Collections.Generic;
using Models.Voice;
using Models.Voice.Rhythm.Util;
using Models.Voice.Util;

namespace Models.MarkovChain.MarkovChainFactory {

  public class TwoNotesScaleMarkovChainFactory : IMarkovChainFactory<ScaleMarkovChain> {

    public ScaleMarkovChain NewInstance() {
      var noteD = Note.Of(NoteNameMapper.FromNoteSymbol("C"), RhythmHelper.SixteenthNoteLengthMillis(), 0.0f);
      var noteFSharp = Note.Of(NoteNameMapper.FromNoteSymbol("G"), RhythmHelper.SixteenthNoteLengthMillis(), 0.0f);
      var transitionDFsharp = new MarkovChainTransition<Note>(noteD, noteFSharp, 1.0f);
      var transitionFsharpD = new MarkovChainTransition<Note>(noteFSharp, noteD, 1.0f);
      
      var noteVertices = new HashSet<Note> {noteD, noteFSharp};

      var transitions = new HashSet<MarkovChainTransition<Note>> {transitionDFsharp, transitionFsharpD};

      return new ScaleMarkovChain(noteVertices, transitions);
    }
  }
}