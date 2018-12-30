using System.Collections.Generic;
using System.Linq;
using Models.MarkovChain;

namespace Models.Voice {

  public class MusicVoice {

    public ScaleMarkovChain MarkovChain;

    public List<Note> MusicPhrase { get; } = new List<Note>();

    public void AddMusicPhrase(IEnumerable<Note> phrase) {
      var harmonizedPhrase = phrase
        .Where(note => !note.IsPause)
        .ToList()
        .Select(note => Note.WithMidiValue(note, MarkovChain.Decide(note).MidiValue));
      
      MusicPhrase.AddRange(harmonizedPhrase);
    }

    public Note NextNote() {
      var note = MusicPhrase.FirstOrDefault();
      MusicPhrase.RemoveAt(0);
      
      return note;
    }
    
    public bool IsEmpty => MusicPhrase.Count == 0;
  }
}