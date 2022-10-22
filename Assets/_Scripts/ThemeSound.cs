using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSound : MonoBehaviour
{
    // Start is called before the first frame update
    public static ThemeSound Instance;
    new public AudioSource audio;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;

        }

        DontDestroyOnLoad(transform.root.gameObject);
        audio = gameObject.GetComponent<AudioSource>();
        AudioSettings.OnAudioConfigurationChanged += OnAudioConfigurationChanged;
    }
    private void Start()
    {

        PlayThemeSong();
    }

    public void PlayThemeSong()
    {
   
            audio.volume = .8f;
            audio.pitch = 1.1f;

            audio.Play();
     

    }
    public void StopThemeSong()
    {
    
            audio.volume = .8f;
            audio.pitch = 1.1f;

            audio.Stop();
     


    }









    void OnAudioConfigurationChanged(bool deviceWasChanged)
    {
        Debug.Log(deviceWasChanged ? "Device was changed" : "Reset was called");
        if (deviceWasChanged)
        {

            PlayThemeSong();
        }
    }



}
