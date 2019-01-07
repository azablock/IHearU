using UnityEngine;

namespace Player {

  public class FootstepAudioEmitter : MonoBehaviour {

//    public AudioClip[] footstepClips;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private bool IsWalking => _rigidbody.velocity.magnitude > 0.0f;
    private readonly System.Random _random = new System.Random();
    
    private void Start() {
      _rigidbody = GetComponent<Rigidbody>();
      _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
      if (!_audioSource.isPlaying && IsWalking) {
       PlayRandomFootstep();
      }
    }

    private void PlayRandomFootstep() {
//      var audioClip = footstepClips[_random.Next(0, footstepClips.Length - 1)];
//      _audioSource.clip = audioClip;
      _audioSource.pitch = Random.Range(0.5f, 0.7f);
      _audioSource.Play();
    }
  }
}