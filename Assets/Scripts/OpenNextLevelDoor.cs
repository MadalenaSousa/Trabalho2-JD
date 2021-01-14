using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNextLevelDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D info)
    {
        if (info.gameObject.tag == "Player" && GameManager.instance.hasAllAnswers)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            Debug.Log("You need to solve all riddles first!");
        }
    }
}
