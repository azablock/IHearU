using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Models.Voice.Util;

namespace Models.Voice.Harmony.Model {

  public class MusicKey {

    public readonly NoteSymbol KeyRoot;
    public readonly int MidiOffset;

    private static readonly ImmutableList<MusicKey> MusicKeys = ImmutableList.Create(
      Of(NoteSymbol.C, 0),
      Of(NoteSymbol.C, 1),
      Of(NoteSymbol.Db, 2),
      Of(NoteSymbol.D, 3),
      Of(NoteSymbol.Eb, 4),
      Of(NoteSymbol.E, 5),
      Of(NoteSymbol.F, 6),
      Of(NoteSymbol.Gb, 7),
      Of(NoteSymbol.G, 8),
      Of(NoteSymbol.Ab, 9),
      Of(NoteSymbol.A, 10),
      Of(NoteSymbol.Bb, 11),
      Of(NoteSymbol.B, 12)
    );

    private MusicKey(NoteSymbol keyRoot, int midiOffset) {
      KeyRoot = keyRoot;
      MidiOffset = midiOffset;
    }

    private static MusicKey Of(NoteSymbol keyCenter, int midiOffset) {
      return new MusicKey(keyCenter, midiOffset);
    }

    public static MusicKey Of(NoteSymbol keyRoot) {
      return MusicKeys.Find(key => key.KeyRoot == keyRoot);
    }

    public static int IntervalBy(int sourceMidiValue, int targetMidiValue) {
      return Math.Abs(targetMidiValue - sourceMidiValue);
    }

    public static int IntervalBy(string sourceNoteName, string targetNoteName) {
      var sourceMidiValue = NoteNameMapper.FromNoteName(sourceNoteName);
      var targetMidiValue = NoteNameMapper.FromNoteName(targetNoteName);

      return IntervalBy(sourceMidiValue, targetMidiValue);
    }
  }
}