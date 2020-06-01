using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShadeOutScreen : Singleton<ShadeOutScreen>
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void ShadeOut()
    {
        anim.SetTrigger("Out");
    }
}
