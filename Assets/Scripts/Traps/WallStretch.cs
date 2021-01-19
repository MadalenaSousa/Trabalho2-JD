using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStretch : MonoBehaviour
{
    SpriteRenderer wallSprite;
    float maxWallWidth, minWallWidth;
    float newWidth;
    public float inc = 1;
    float healthValue = 1;


    AudioSource[] audioSources;
    AudioSource sound1;
    AudioSource sound2;

    AudioSource currentSound;

    void Start()
    {
        wallSprite = GetComponent<SpriteRenderer>();
        wallSprite.drawMode = SpriteDrawMode.Sliced;
        maxWallWidth = wallSprite.size.x;
        minWallWidth = 2;
        newWidth = minWallWidth;

        audioSources = GetComponentsInParent<AudioSource>();
        sound1 = audioSources[0];
        sound2 = audioSources[1];

        currentSound = sound1;
        currentSound.Play();
    }

    
    void Update()
    {
        //Colide and switch direction algorithm
        if(wallSprite.size.x >= maxWallWidth)
        {
            inc = - Mathf.Abs(inc);
            currentSound.Stop();

            if (currentSound.Equals(sound1))
            {
                currentSound = sound2;
            }
            else
            {
                currentSound = sound1;
            }
            currentSound.Play();
        }
        else if(wallSprite.size.x <= minWallWidth)
        {
            inc = Mathf.Abs(inc);
            currentSound.Stop();

            if (currentSound.Equals(sound1))
            {
                currentSound = sound2;
            }
            else
            {
                currentSound = sound1;
            }
            currentSound.Play();
        }

        newWidth = newWidth + inc;
        wallSprite.size = new Vector2(newWidth, wallSprite.size.y);
    }

    private void OnCollisionStay2D(Collision2D info)
    {
        if (info.gameObject.tag == "Player")
        {
            PlayerControl.instance.currentPlayer.decreaseHealth(healthValue);
        }
    }
}
