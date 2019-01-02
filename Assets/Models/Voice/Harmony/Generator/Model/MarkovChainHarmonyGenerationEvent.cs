namespace Models.Voice.Harmony.Generator.Model {

  public class MarkovChainHarmonyGenerationEvent {

    public readonly MusicVoice Voice;
    public readonly int NoteCount;

    private MarkovChainHarmonyGenerationEvent(MusicVoice voice, int noteCount) {
      Voice = voice;
      NoteCount = noteCount;
    }

    public static MarkovChainHarmonyGenerationEvent Of(MusicVoice voice, int noteCount) {
      return new MarkovChainHarmonyGenerationEvent(voice, noteCount);
    }
  }
}