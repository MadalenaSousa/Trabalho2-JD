using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    public AudioSource backgroundMusic;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeBackgroundMusic(AudioClip newMusic)
    {
        backgroundMusic.Stop();
        backgroundMusic.clip = newMusic;
        backgroundMusic.Play();
    }
}
