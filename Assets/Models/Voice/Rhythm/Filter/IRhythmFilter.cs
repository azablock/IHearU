using System.Collections.Generic;

namespace Models.Voice {

  public interface IRhythmFilter<in T> {

    IEnumerable<Note> Filter(T model, IEnumerable<Note> notes);
  }
}