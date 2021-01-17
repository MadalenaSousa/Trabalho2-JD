using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D info)
    {
        if (info.gameObject.tag == "Player")
        {
            PlayerControl.instance.currentPlayer.setHealth(0);
        }
    }
}
