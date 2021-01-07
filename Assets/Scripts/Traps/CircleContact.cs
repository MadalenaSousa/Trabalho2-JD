using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleContact : MonoBehaviour
{
    float healthValue = 1f;

    private void OnCollisionStay2D(Collision2D info)
    {
        if (info.gameObject.tag == "Player")
        {
            PlayerControl.instance.currentPlayer.decreaseHealth(healthValue);
        }
    }
}
