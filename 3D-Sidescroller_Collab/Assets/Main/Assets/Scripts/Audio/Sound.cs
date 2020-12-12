using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip Clip;

    [Range(0f,1f)]
    public float Volume;
    [Range(0.1f,3.0f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
    
}
