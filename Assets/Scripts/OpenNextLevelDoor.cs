using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNextLevelDoor : MonoBehaviour
{
    public Sprite doorOpen;
    public GameObject movingCamera;
    GameObject finalCutsceneCam;

    private void Start()
    {
        finalCutsceneCam = GameObject.FindGameObjectWithTag("CutsceneCam");
        finalCutsceneCam.GetComponent<Camera>().enabled = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (/*GameManager.instance.hasAllAnswers &&*/ PlayerControl.instance.checkIfAllPlayersAreAlive()) //Pass to next level conditions
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
                //StartCoroutine(ExecuteAfterTime(3));
                movingCamera.GetComponent<Camera>().enabled = false;
                finalCutsceneCam.GetComponent<Camera>().enabled = true;
                finalCutsceneCam.GetComponentInChildren<Animator>().SetBool("Show", true);
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
