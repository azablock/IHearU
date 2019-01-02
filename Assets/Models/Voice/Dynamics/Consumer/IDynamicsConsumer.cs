using System.Collections.Generic;

namespace Models.Voice.Dynamics.Consumer {
  
  public interface IDynamicsConsumer {

    void Accept(MusicVoice musicVoice);
  }
}