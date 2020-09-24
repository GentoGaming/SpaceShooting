using UnityEngine;

namespace _Scripts.FG.Others
{
    [RequireComponent(typeof(AudioSource))]

    public class PlayAudio : MonoBehaviour
    {
        private AudioSource _countdownAudioSource;
        // Start is called before the first frame update
        void Start()
        {
            _countdownAudioSource = GetComponent<AudioSource>();
            Invoke($"PlayCountdown", 0.5f);

        }

        private void PlayCountdown()
        {
            _countdownAudioSource.Play();
        }
    }
}
