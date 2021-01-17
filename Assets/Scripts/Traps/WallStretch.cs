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

    void Start()
    {
        wallSprite = GetComponent<SpriteRenderer>();
        wallSprite.drawMode = SpriteDrawMode.Sliced;
        maxWallWidth = wallSprite.size.x;
        minWallWidth = 2;
        newWidth = minWallWidth;
    }

    
    void Update()
    {
        //Colide and switch direction algorithm
        if(wallSprite.size.x >= maxWallWidth)
        {
            inc = - Mathf.Abs(inc);
        }
        else if(wallSprite.size.x <= minWallWidth)
        {
            inc = Mathf.Abs(inc);
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
