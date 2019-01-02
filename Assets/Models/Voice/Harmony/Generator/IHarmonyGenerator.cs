namespace Models.Voice.Harmony.Generator {

  public interface IHarmonyGenerator<in T, out R> {
    R Generate(T input);
  }
}