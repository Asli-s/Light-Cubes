using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (GameManager.Instance?.endlessLevel == true && s.name == "success")
        {
            s.volume = 0.2f;
            s.pitch = 1.98f;
        }

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
