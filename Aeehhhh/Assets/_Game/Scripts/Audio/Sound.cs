using Unity.Audio;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Aeehhhh/Sound")]
public class Sound : ScriptableObject
{
    public string name;
    
    public AudioClip clip;
    
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;
}
