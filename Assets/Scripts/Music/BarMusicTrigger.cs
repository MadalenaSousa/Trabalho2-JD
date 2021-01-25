using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BarMusicTrigger : MonoBehaviour
{

    public AudioClip normalBackgorundMusic;
    public AudioClip barBackgroundClip;

    private AudioManagerScript audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(normalBackgorundMusic != null && barBackgroundClip != null)
            {

                if (audioManager.backgroundMusic.clip.Equals(normalBackgorundMusic))
                {
                    audioManager.ChangeBackgroundMusic(barBackgroundClip);
                }
                else
                {
                    audioManager.ChangeBackgroundMusic(normalBackgorundMusic);
                }
            }
        }
    }
}
