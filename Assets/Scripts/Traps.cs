using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    int healthValue = 1;

    private void OnCollisionStay2D(Collision2D info)
    {
        if (info.gameObject.tag == "Player")
        {
            PlayerControl.instance.decreaseHealth(healthValue);
        }
    }
}
