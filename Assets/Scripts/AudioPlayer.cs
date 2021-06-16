using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource musicSource;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        musicSource.volume = musicVolume;
    }

    public void updateMusicVolume(float volume)
    {
        musicVolume = volume;
    }

}
