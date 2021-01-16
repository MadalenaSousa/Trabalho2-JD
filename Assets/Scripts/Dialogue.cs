using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string startingSpeaker;

    [TextArea(2, 10)]
    public string[] sentences;

    public Sprite[] icon;
}
