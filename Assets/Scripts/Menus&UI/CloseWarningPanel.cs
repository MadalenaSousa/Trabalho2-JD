using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWarningPanel : MonoBehaviour
{
    void Update()
    {
        if(gameObject.activeSelf)
        {
            StartCoroutine(ExecuteAfterTime(8));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}
