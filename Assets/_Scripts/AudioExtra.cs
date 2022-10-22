using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioExtra : MonoBehaviour
{
   
    public Sound[] sounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

    
    }


    public void Play(string name, bool loop = false, bool stop = false)
    {
      
        audioSource = gameObject.GetComponent<AudioSource>();
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        //(sound)
        audioSource.clip = s.audioClip;
        audioSource.pitch = s.pitch;
        audioSource.volume = s.volume;
        audioSource.loop = loop;
     
        if (stop == true)
        {
            print("stop =true");
            audioSource.Stop();

        }
        else if (stop == false && GameManager.Instance.sound == true)
        {

            audioSource.Play();
        }

     

    }
 



}
