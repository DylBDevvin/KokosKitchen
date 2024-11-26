using UnityEngine;
using UnityEngine.Audio;


    public class TutelSongScript : MonoBehaviour
    {
        public AudioMixerGroup audioMixerGroup;
        public AudioClip audioClip;
        public AudioClip tutelClip;
        public float crossFadeTime = 3;
        public PlayerInteract pi;

        AudioSource audioSourceA, audioSourceB;
        float audioSourceAVolumeVelocity, audioSourceBVolumeVelocity;

        public void CrossFade(AudioClip audioClip)
        {
            var t = audioSourceA;
            audioSourceA = audioSourceB;
            audioSourceB = t;
            audioSourceA.clip = audioClip;
            audioSourceA.Play();
        
        }

    public void noPlaySong()
    {
        audioSourceA.Stop();
       
    }
        

    public void playSong()
        {
            audioSourceA = gameObject.AddComponent<AudioSource>();
            audioSourceA.volume = 0.9f;
            audioSourceA.spatialBlend = 0;
            audioSourceA.clip = audioClip;
            audioSourceA.loop = true;
            audioSourceA.outputAudioMixerGroup = audioMixerGroup;
            audioSourceB = gameObject.AddComponent<AudioSource>();
            audioSourceB.volume = 0.9f;
            audioSourceB.spatialBlend = 0;
            audioSourceB.loop = true;
            audioSourceB.outputAudioMixerGroup = audioMixerGroup;
            audioSourceA.Play();

    }
    }

