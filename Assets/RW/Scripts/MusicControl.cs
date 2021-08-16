using UnityEngine;

namespace RayWenderlich.SpaceInvadersUnity
{
    public class MusicControl : MonoBehaviour
    {
        private readonly float defaultTempo = 1.33f;
        private float pitchChange;

        [SerializeField]
        internal int pitchChangeSteps = 5;

        [SerializeField]
        private AudioSource source;

        [SerializeField]
        private float maxPitch = 5.25f;

        internal float Tempo { get; private set; }

        internal void StopPlaying() => source.Stop();

        internal void IncreasePitch()
        {
            if (source.pitch == maxPitch)
            {
                return;
            }

            source.pitch = Mathf.Clamp(source.pitch + pitchChange, 1, maxPitch);
            Tempo = Mathf.Pow(2, pitchChange) * Tempo;
        }

        private void Start()
        {
            source.pitch = 1f;
            Tempo = defaultTempo;
            pitchChange = maxPitch / pitchChangeSteps;
        }
    }
}