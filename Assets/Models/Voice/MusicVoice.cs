using System.Collections.Generic;
using System.Linq;
using Models.Voice.Harmony.Model;

namespace Models.Voice {
  
  public class MusicVoice {
  
    public List<Note> MusicPhrase { get; } = new List<Note>();
    public OctaveNoteRange Range { get; }

    public MusicVoice(OctaveNoteRange range) {
      Range = range;
    }

    public void AddMusicPhrase(IEnumerable<Note> phrase) {
      MusicPhrase.Clear();
      MusicPhrase.AddRange(phrase);
    }

    public Note NextNote() {
      var note = MusicPhrase.First(n => !n.AlreadyPlayed);
      note.AlreadyPlayed = true;

      return note;
    }

    public bool IsEmpty => MusicPhrase.All(note => note.AlreadyPlayed);
  }
}