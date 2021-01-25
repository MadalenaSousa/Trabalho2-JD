﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenNextLevelDoor : MonoBehaviour
{
    public Sprite doorOpen;
    Sprite doorClosed;
    public GameObject movingCamera;
    GameObject finalCutsceneCam;
    bool startCutscene;

    private void Start()
    {
        finalCutsceneCam = GameObject.FindGameObjectWithTag("CutsceneCam");
        finalCutsceneCam.GetComponent<Camera>().enabled = false;
        doorClosed = GetComponent<SpriteRenderer>().sprite;
        startCutscene = false;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.hasAllAnswers && PlayerControl.instance.checkIfAllPlayersAreAlive()) //Pass to next level conditions
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = doorOpen;
                startCutscene = true;
            }
            else
            {
                Debug.Log("You need to solve all riddles first!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PlayerControl.instance.currentPlayer.tag && startCutscene)
        {
            movingCamera.GetComponent<Camera>().enabled = false;
            finalCutsceneCam.GetComponent<Camera>().enabled = true;
            PlayerControl.instance.animator.SetBool("Fade", true);
            StartCoroutine(StartCutsceneAfter(0.45f));
        }
    }

    IEnumerator StartCutsceneAfter(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.GetComponent<SpriteRenderer>().sprite = doorClosed;
        finalCutsceneCam.GetComponentInChildren<Animator>().SetBool("Show", true);
        StartCoroutine(LoadWinAfter(3));
    }

    IEnumerator LoadWinAfter(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Win");
    }
}
