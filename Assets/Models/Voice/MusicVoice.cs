using System.Collections.Generic;
using System.Linq;
using Models.Voice.Harmony.Model;
using Models.Voice.Rhythm.Model;

namespace Models.Voice {
  
  public class MusicVoice {
  
    public List<Note> MusicPhrase { get; } = new List<Note>();
    public OctaveNoteRange NoteRange { get; }
    public readonly MusicKey MusicKey;

    public List<RhythmData> RhythmPattern;
    public Queue<int> HarmonyPattern;

    public MusicVoice(OctaveNoteRange noteRange) {
      NoteRange = noteRange;
      MusicKey = MusicKey.Of(NoteSymbol.C);
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

    public bool PhraseAlreadyPlayed => MusicPhrase.All(note => note.AlreadyPlayed);

    public bool IsEmpty => MusicPhrase.Count == 0;

    public int KeyRootMidiValue => NoteRange.Offset + MusicKey.MidiOffset;
  }
}