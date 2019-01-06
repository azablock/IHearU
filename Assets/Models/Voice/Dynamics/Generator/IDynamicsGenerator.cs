using System.Collections.Generic;

namespace Models.Voice.Dynamics.Generator {
  
  public interface IDynamicsGenerator<in T> {
    Queue<int> Generate(T input);
  }
}