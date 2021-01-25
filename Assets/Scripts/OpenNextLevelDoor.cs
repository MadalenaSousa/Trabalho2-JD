using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNextLevelDoor : MonoBehaviour
{
    public Sprite doorOpen;
    public GameObject movingCamera;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.hasAllAnswers && PlayerControl.instance.checkIfAllPlayersAreAlive()) //Pass to next level conditions
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
                StartCoroutine(ExecuteAfterTime(3));
            }
            else
            {
                Debug.Log("You need to solve all riddles first!");
            }
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Win");
    }
}
