using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : Singleton<ParticleManager>
{
    public GameObject bloodParticle;

    public void PlayBlood(Vector2 position)
    {
        Instantiate(bloodParticle, position, Quaternion.identity);
    }
}
