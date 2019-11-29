using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityAtoms;
using Random = System.Random;

public class PlayerAudio : MonoBehaviour
{
    private AudioManager _audioManager;

    public float maxTime;
    public float minTime;

    public Sound[] sounds;

    public Sound[] hitSounds;
    
    private bool _isSoundPlaying = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isSoundPlaying && sounds.Length != 0)
        {
            _isSoundPlaying = true;
            StartCoroutine(StartPlayingSound());
        }
    }

    IEnumerator StartPlayingSound()
    {
        float timeTillNext = UnityEngine.Random.Range(minTime, maxTime);
        
        yield return new WaitForSeconds(timeTillNext);
        
        Sound sound = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        _audioManager.Play(sound.name);
        _isSoundPlaying = false;
    }

    public void StartHitSound()
    {    
        if (hitSounds == null) return;
        if (hitSounds.Length == 0) return;
        ;
        Sound sound = hitSounds[UnityEngine.Random.Range(0, hitSounds.Length)];
        _audioManager.Play(sound.name);
    }
}
