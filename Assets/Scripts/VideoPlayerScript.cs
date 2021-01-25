using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayerScript : MonoBehaviour
{
    public GameObject videoPlayer;
    private int videoTime = 48;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        coroutine = WaitAndLaodLevel(videoTime);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndLaodLevel(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Object.Destroy(videoPlayer);
            SceneManager.LoadScene("Level1");
        }
    }
}
