using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [HideInInspector]
    public float time;
    public float timer = 1f;

    public void Awake()
    {
        time = timer;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Destroy(gameObject);
        }
    }

}
