using System.Collections.Generic;
using Models.Voice;
using Models.Voice.Util;

namespace Models.MarkovChain.MarkovChainFactory {

  public class TwoNotesScaleMarkovChainFactory : IMarkovChainFactory<ScaleMarkovChain> {

    public ScaleMarkovChain NewInstance() {
      var noteD = new Note(NoteNameMapper.fromNoteName("D"));
      var noteFSharp = new Note(NoteNameMapper.fromNoteName("F#"));
      var transitionDFsharp = new MarkovChainTransition<Note>(noteD, noteFSharp, 1.0f);
      var transitionFsharpD = new MarkovChainTransition<Note>(noteFSharp, noteD, 1.0f);
      
      var noteVertices = new HashSet<Note> {noteD, noteFSharp};

      var transitions = new HashSet<MarkovChainTransition<Note>> {transitionDFsharp, transitionFsharpD};

      return new ScaleMarkovChain(noteVertices, transitions);
    }
  }
}