using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[System.Serializable]
public class Dialogue
{
    public string name;
    public DialogueType type;
    [TextArea(3, 10)]
    public string[] sentences;

}
