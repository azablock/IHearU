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
    public Queue<int> DynamicsPattern;
    public Queue<int> HarmonyPattern;

    public MusicVoice(OctaveNoteRange noteRange) {
      NoteRange = noteRange;
      MusicKey = MusicKey.Of(NoteSymbol.C);
    }

    public MusicVoice AddMusicPhrase() {
      var newMusicPhrase = RhythmPattern.Select((rhythmData, iterator) => NoteFrom(
        rhythmData,
        DynamicsPattern.ElementAt(iterator), 
        HarmonyPattern.ElementAt(iterator))
      );

      MusicPhrase.Clear();
      MusicPhrase.AddRange(newMusicPhrase);

      return this;
    }
    
    public void UpdateNextNote(Note newNote) {
      MusicPhrase[NextNoteIndex] = newNote;
    }

    public Note NextNote => MusicPhrase.First(n => !n.AlreadyPlayed);

    public Note UseNextNote() {
      var note = MusicPhrase.First(n => !n.AlreadyPlayed);
      note.AlreadyPlayed = true;

      return note;
    }

    public bool PhraseAlreadyPlayed => MusicPhrase.All(note => note.AlreadyPlayed);

    public bool IsEmpty => MusicPhrase.Count == 0;

    public int KeyRootMidiValue => NoteRange.Offset + MusicKey.MidiOffset;

    private int NextNoteIndex => MusicPhrase.FindIndex(n => !n.AlreadyPlayed);
    
    private Note NoteFrom(RhythmData rhythmData, int velocity, int interval) {
      return rhythmData.IsPause
        ? Note.Pause(rhythmData.LengthMillis, 0.0f)
        : Note.Of(
          interval + NoteRange.Offset,
          rhythmData.LengthMillis,
          velocity,
          0.0f
        );
    }
  }
}