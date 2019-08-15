using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Music : MonoBehaviour
{
    public AudioClip TutorialMusic;
    public AudioClip LevelMusic;
    public AudioClip BossMusic;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayTutorialMusic()
    {
        source.clip = TutorialMusic;
        source.Play();
    }

    public void PlayLevelMusic()
    {
        source.clip = LevelMusic;
        source.Play();
    }

    public void PlayBossMusic()
    {
        source.clip = BossMusic;
        source.Play();
    }

    public void SetVolume(float volume)
    {
        source.volume = volume;
    }
}
