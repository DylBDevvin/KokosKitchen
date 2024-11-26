using System.Collections;
using UnityEngine;
using UnityEngine.Audio;


    public class MusicController : MonoBehaviour
    {
        public AudioMixerGroup audioMixerGroup;
        public AudioClip audioClip;
        public AudioClip tutelClip;
        public AudioClip titleClip;
        public float crossFadeTime = 3;
        public PlayerInteract pi;
        public PlayerMovement pm;
   

    public float ratMuter = 0.007f;
    public float muter = 0.0001f;
    public float adder = 0.0001f;

    public bool canLower;
    public bool canIncrease;

    AudioSource audioSourceA, audioSourceB;
    public AudioSource audioSourceC;
    float audioSourceAVolumeVelocity, audioSourceBVolumeVelocity;


    public void Start()
    {
        audioSourceA.volume = 0f;

        
        

    }
    public void LowerAudio()
    {
        audioSourceA.volume -= muter;
        if(audioSourceA.volume <= 0)
        {
            Debug.Log("Muted!!!!");
        }
       
    }

    public void MuteButton()
    {
        canLower = true;
    }  
    public void CrossFade(AudioClip audioClip)
    {
      


            canLower = false;
            canIncrease = true;
            var t = audioSourceA;
            audioSourceA = audioSourceB;
            audioSourceB = t;
            audioSourceA.clip = audioClip;


            audioSourceA.Play();
        

        
    
 
    }

        void Update()
        {

        if (!pm.INSTARTSCREEN)
        {
            audioSourceC.volume -= muter;
        }
        audioSourceB.volume = 0f;

        if (canLower)
        {
            LowerAudio();
        }

        if (canIncrease)
        {
            audioSourceA.volume += adder;
            if(audioSourceA.volume >= 0.6f)
            {
                canIncrease = false;
            }
        }

        if (pi.tutelAnim == true)
            {
                audioSourceA.volume = 0;
                //SoundManagerScript.PlaySound("tutelSE");
            }

            if(pi.ratting == true)
            {
                audioSourceA.volume -= ratMuter;
                
            }

            if(pi.tutelAnim == false && pi.ratting == false && !canLower && !canIncrease)
            {
                //audioSourceA.volume = Mathf.SmoothDamp(audioSourceA.volume, 1f, ref audioSourceAVolumeVelocity, crossFadeTime, 1);
               // audioSourceB.volume = Mathf.SmoothDamp(audioSourceB.volume, 0f, ref audioSourceBVolumeVelocity, crossFadeTime, 1);
               audioSourceA.volume = 0.6f;
               audioSourceB.volume = 0f;
            }
           
            

        }

        void OnEnable()
        {
            audioSourceA = gameObject.AddComponent<AudioSource>();
            audioSourceA.spatialBlend = 0;
            audioSourceA.clip = audioClip;
            audioSourceA.loop = true;
            audioSourceA.outputAudioMixerGroup = audioMixerGroup;
        audioSourceA.volume = 0f;
          

            audioSourceB = gameObject.AddComponent<AudioSource>();
            audioSourceB.spatialBlend = 0;
            audioSourceB.loop = true;
            audioSourceB.outputAudioMixerGroup = audioMixerGroup;
        audioSourceB.volume = 0f;

        audioSourceC = gameObject.AddComponent<AudioSource>();
        audioSourceC.spatialBlend = 0;
        audioSourceC.loop = true;
        audioSourceC.outputAudioMixerGroup = audioMixerGroup;
        audioSourceC.volume = 0.4f;
        audioSourceC.clip = titleClip;
        audioSourceC.Play();
    }

        
    }

