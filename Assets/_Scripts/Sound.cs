using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    // Start is called before the first frame update
    public string name;
    public AudioClip audioClip;

    [Range(0, 3)]
    public float volume;
    [Range(0.1f, 3)]
    public float pitch;
    public bool loop;

    [HideInInspector]
    public AudioSource source;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
