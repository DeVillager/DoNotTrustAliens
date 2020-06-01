using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : Singleton<Boss>
{
    public DialogueTrigger dialTrigger;
    public DialogueTrigger dialTrigger2;
    public Animator anim;
    public GameObject theEndScreen;
    public GameObject blackScreen;

    protected override void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        dialTrigger.TriggerDialogue();
    }

    public IEnumerator StartSpeak()
    {
        yield return new WaitForSeconds(1f);
        dialTrigger.TriggerDialogue();
    }

    public void StartDialog2()
    {
        dialTrigger2.TriggerDialogue();
    }


}
