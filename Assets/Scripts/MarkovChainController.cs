using Models.MarkovChain;
using Models.MarkovChain.MarkovChainFactory;
using UnityEngine;

public class MarkovChainController : MonoBehaviour {

  private ScaleMarkovChain _chain;

  private void Awake() {
    _chain = new TwoNotesScaleMarkovChainFactory().NewInstance();
  }
}