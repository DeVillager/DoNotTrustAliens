using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public AudioClip click;
    public void PlayClick()
    {
        SoundManager.Instance.Play(click);
    }
}
