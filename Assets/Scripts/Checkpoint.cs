using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            GameManager.instance.lastCheckpoitPos = transform.position;
        }
    }
}
